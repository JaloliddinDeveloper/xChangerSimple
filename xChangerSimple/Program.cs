using Importer.Services.Orchestrations;
using xChangerSimple.Brokers.Sheet;
using xChangerSimple.Brokers.Storage;
using xChangerSimple.Services.Foundations;
using xChangerSimple.Services.Spreadsheets;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<IStorageBroker, StorageBroker>();
builder.Services.AddTransient<ISheetBroker, SheetBroker>();
builder.Services.AddTransient<ISheetBroker, SheetBroker>();
builder.Services.AddTransient<ITalabaService, TalabaService>();
builder.Services.AddTransient<IOrchestrationService, OrchestrationService>();
builder.Services.AddTransient<ISheetService, SheetService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
