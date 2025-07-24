using System.Data;
using System.Data.SqlClient;
using TNCWWB_Form.IService;
using TNCWWB_Form.MainForm;
using TNCWWB_Form.Models.BindModel;
using TNCWWB_Form.Models.NewFolder2;
using TNCWWB_Form.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IOrgService, OrgServices>();
builder.Services.AddSingleton<IMemberService, MemberPerDtlsService>();
builder.Services.AddSingleton<IDocumentDtls, DocumentDtlsService>();
builder.Services.AddSingleton<IBankAccDtls, BankAccDtlsService>();
builder.Services.AddSingleton<IFamilyMDtls, FamilyMDtlService>();
builder.Services.AddScoped<IFullMemberService, FullMemberService>();
builder.Services.AddScoped<IAddressService, AddressDtlsService>();

builder.Services.Configure<ProfileImgUpload>(
    builder.Configuration.GetSection("ImageUploadSettings"));

builder.Services.Configure<DocumentsUpload>(
    builder.Configuration.GetSection("DocumentUploadSettings"));

builder.Services.AddSingleton<IDbConnection>(sp =>
{
    var connection = builder.Configuration.GetConnectionString("DefaultConnection");
    if (string.IsNullOrEmpty(connection))
    {
        throw new InvalidOperationException("Connection string is not found");
    }
    return new SqlConnection(connection);
});

builder.Services.AddCors(options => options.AddPolicy(name: "FrontUI",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseCors("FrontUI");

app.UseAuthorization();

app.MapControllers();

app.Run();
