public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseMiddleware<GlobalExceptionHandlerMiddleware>();  

    app.UseExceptionHandler("/Home/Error"); 
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}"); 

    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
}
