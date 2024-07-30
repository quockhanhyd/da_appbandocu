using DA_AppBanDoCu.Services;
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5000); // L?ng nghe tr�n IP 0.0.0.0 v� port 5000
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IChatService, ChatService>();
builder.Services.AddTransient<IOrderDetailService, OrderDetailService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IProductFavoriteService, ProductFavoriteService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IUserService, UserService>();

// Thay đổi cấu hình để lắng nghe trên tất cả các IP
builder.WebHost.UseUrls("http://0.0.0.0:5009", "https://0.0.0.0:7156");
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAll");
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();
