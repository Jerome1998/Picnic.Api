using Picnic.Api.Configuration;
using Picnic.Api.Internal;
using Picnic.Api.Models.Auth;
using Picnic.Api.Services;
using Picnic.Api.Services.Interfaces;

namespace Picnic.Api;

/// <summary>
/// Provides the main entry point for interacting with the Picnic API.
/// </summary>
public sealed class PicnicClient : IDisposable
{
    private readonly PicnicHttpClient _httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="PicnicClient"/> class.
    /// </summary>
    /// <param name="options">Optional API configuration. Defaults are used when omitted.</param>
    /// <param name="httpMessageHandler">Optional HTTP message handler to customize HTTP behavior.</param>
    public PicnicClient(PicnicApiOptions? options = null, HttpMessageHandler? httpMessageHandler = null)
    {
        options ??= new PicnicApiOptions();

        _httpClient = new PicnicHttpClient(options, httpMessageHandler);

        Auth = new AuthService(_httpClient);
        App = new AppService(_httpClient);
        User = new UserService(_httpClient);
        Catalog = new CatalogService(_httpClient);
        Cart = new CartService(_httpClient);
        Delivery = new DeliveryService(_httpClient);
        Payment = new PaymentService(_httpClient);
        Consent = new ConsentService(_httpClient);
    }

    /// <summary>
    /// Gets authentication-related operations.
    /// </summary>
    public IAuthService Auth { get; }

    /// <summary>
    /// Gets app and page-related operations.
    /// </summary>
    public IAppService App { get; }

    /// <summary>
    /// Gets user-related operations.
    /// </summary>
    public IUserService User { get; }

    /// <summary>
    /// Gets catalog and product discovery operations.
    /// </summary>
    public ICatalogService Catalog { get; }

    /// <summary>
    /// Gets cart-related operations.
    /// </summary>
    public ICartService Cart { get; }

    /// <summary>
    /// Gets delivery-related operations.
    /// </summary>
    public IDeliveryService Delivery { get; }

    /// <summary>
    /// Gets payment and wallet operations.
    /// </summary>
    public IPaymentService Payment { get; }

    /// <summary>
    /// Gets consent-related operations.
    /// </summary>
    public IConsentService Consent { get; }

    /// <summary>
    /// Gets a value indicating whether the current client instance has an authentication token.
    /// </summary>
    public bool IsAuthenticated => _httpClient.IsAuthenticated;

    /// <summary>
    /// Gets the current authentication token.
    /// </summary>
    public string? AuthToken => _httpClient.AuthToken;

    /// <summary>
    /// Authenticates a user with username and password.
    /// </summary>
    /// <param name="username">The Picnic account username.</param>
    /// <param name="password">The Picnic account password.</param>
    /// <param name="cancellationToken">A token to cancel the authentication request.</param>
    /// <returns>The login result containing authentication details.</returns>
    public Task<LoginResult> LoginAsync(string username, string password, CancellationToken cancellationToken = default)
        => Auth.LoginAsync(username, password, cancellationToken);

    /// <summary>
    /// Releases resources used by the client.
    /// </summary>
    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
