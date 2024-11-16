using Amazon.S3;
using EnzoTournaAPI.ClassS3;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAWSService<IAmazonS3>();


builder.Services.AddSingleton<ItournaS3, TournaS3>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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