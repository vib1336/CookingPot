namespace CookingPot.Web.Areas.Administration.Controllers
{
    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.Administration.Dashboard;
    using CookingPot.Web.ViewModels.Recipes;

    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;

        public DashboardController(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View(viewModel);
        }
    }
}
