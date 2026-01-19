# Звіт з аналізу SOLID принципів (SRP, OCP) в Open-Source проєкті
# 1. Обраний проєкт
Назва: MediatR
GitHub: https://github.com/jbogard/MediatR
Опис: Бібліотека, що реалізує патерн Mediator для .NET, відома своєю чистою архітектурою та дотриманням SOLID принципів.

# 2. Аналіз SRP (Single Responsibility Principle)
MediatR чудово демонструє дотримання принципу єдиної відповідальності. Головний клас Mediator має лише одну відповідальність — координувати відправку повідомлень до відповідних обробників. Він не займається логуванням, валідацією чи створенням обробників.

csharp
public class Mediator : IMediator
{
    private readonly ServiceFactory _serviceFactory;
    
    public Task<TResponse> Send<TResponse>(
        IRequest<TResponse> request, 
        CancellationToken cancellationToken = default)
    {
        var handler = GetHandler(request);
        return handler.Handle(request, cancellationToken);
    }
    
    private RequestHandlerWrapper<TResponse> GetHandler<TResponse>(
        IRequest<TResponse> request)
    {
        return request switch
        {
            IRequest<TResponse> => 
                (RequestHandlerWrapper<TResponse>)_serviceFactory(
                    typeof(RequestHandlerWrapper<,>)
                    .MakeGenericType(request.GetType(), typeof(TResponse))),
            _ => throw new InvalidOperationException()
        };
    }
}
Клас RequestHandlerWrapper відповідає виключно за безпечне виконання запитів:

csharp
internal abstract class RequestHandlerWrapper<TResponse>
{
    public abstract Task<TResponse> Handle(
        IRequest<TResponse> request, 
        CancellationToken cancellationToken);
}
Однак у реальних проєктах часто зустрічаються порушення SRP, коли розробники створюють кастомні реалізації, які об'єднують логування, валідацію, кешування та метрики в одному класі. Це створює "God Object", що ускладнює тестування та підтримку.

# 3. Аналіз OCP (Open/Closed Principle)
Бібліотека відмінно дотримується принципу відкритості/закритості через систему інтерфейсів. Можна додавати нові обробники запитів без жодних змін у MediatR:

csharp

public record CreateProductCommand(string Name, decimal Price) 
    : IRequest<ProductResponse>;


public class CreateProductHandler 
    : IRequestHandler<CreateProductCommand, ProductResponse>
{
    public Task<ProductResponse> Handle(
        CreateProductCommand request, 
        CancellationToken ct)
    {
        
        return Task.FromResult(new ProductResponse(Guid.NewGuid()));
    }
}
Ключовим механізмом розширення є пайплайн поведінки (IPipelineBehavior), що дозволяє додавати нову функціональність без змін існуючого коду:

csharp
public class LoggingBehavior<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger _logger;
    
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken ct)
    {
        _logger.LogInformation($"Handling {typeof(TRequest).Name}");
        var response = await next();
        _logger.LogInformation($"Handled {typeof(TRequest).Name}");
        return response;
    }
}
Ранні версії мали порушення OCP з умовними конструкціями:

csharp

public Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
{
    if (request is IRequest<Unit>) // Потрібно змінювати для нових типів
    {
        // Спеціальна обробка
    }
}
# 4. Загальні висновки
MediatR є відмінним прикладом практичного застосування SRP та OCP у реальному open-source проєкті. Бібліотека демонструє, як правильне дотримання цих принципів призводить до гнучкої, легко розширюваної та підтримуваної архітектури. Основні переваги включають простоту тестування, легке розширення через інтерфейси та можливість додавання нової функціональності без ризику для існуючого коду.

Проте аналіз показує, що навіть у добре спроектованих бібліотеках можуть бути порушення принципів, особливо в ранніх версіях або в користувацьких реалізаціях. Рекомендацією є використання вбудованих механізмів розширення (як Pipeline Behaviors) замість створення монолітних класів з множинними відповідальностями.

Загалом, MediatR слугує якісним зразком того, як SOLID принципи можуть покращити архітектуру програмного забезпечення, зробивши його більш гнучким, підтримуваним та масштабованим.