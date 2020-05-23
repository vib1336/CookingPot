namespace CookingPot.Web.Controllers
{
    using System;

    using CookingPot.Services.Data;
    using CookingPot.Web.ViewModels.MainCourses;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static CookingPot.Common.GlobalConstants;

    public class MaincoursesController : Controller
    {
        private readonly ISubcategoriesService subcategoriesService;
        private readonly IRecipesService recipesService;

        public MaincoursesController(ISubcategoriesService subcategoriesService, IRecipesService recipesService)
        {
            this.subcategoriesService = subcategoriesService;
            this.recipesService = recipesService;
        }

        public IActionResult Subcategories()
        {
            var mainCoursesSubcategoryViewModel = new MainCoursesSubcategoryViewModel
            {
                MeatMainCourses = this.subcategoriesService.GetSubcategory<MeatMainCoursesSubcategoryViewModel>(MeatMainCourses),
                VegetarianMainCourses = this.subcategoriesService.GetSubcategory<VegetarianMainCoursesSubcategoryViewModel>(VegetarianMainCourses),
            };
            return this.View(mainCoursesSubcategoryViewModel);
        }

        [Authorize]
        public IActionResult AllMeatMainCourses(int page = 1)
        {
            int subcategoryId = this.subcategoriesService.GetSubcategoryId(MeatMainCourses);

            int totalRecipes = this.recipesService.GetTotalRecipesFromSubcategory(subcategoryId);
            double maxPage = Math.Ceiling(((double)totalRecipes) / RecipesPerPage);
            if (maxPage == 0)
            {
                return this.View("EmptySubcategory");
            }

            if (page > maxPage)
            {
                return this.View("InvalidPage");
            }

            var allMeatMainCourses = new AllMeatMainCoursesViewModel
            {
                AllMeatMainCourses = this.recipesService.GetRecipes<MeatMainCoursesViewModel>(subcategoryId, page),
                Total = this.recipesService.GetTotalRecipesFromSubcategory(subcategoryId),
                CurrentPage = page,
            };

            return this.View(allMeatMainCourses);
        }

        [Authorize]
        public IActionResult AllVegetarianMainCourses(int page = 1)
        {
            int subcategoryId = this.subcategoriesService.GetSubcategoryId(VegetarianMainCourses);

            int totalRecipes = this.recipesService.GetTotalRecipesFromSubcategory(subcategoryId);
            double maxPage = Math.Ceiling(((double)totalRecipes) / RecipesPerPage);
            if (maxPage == 0)
            {
                return this.View("EmptySubcategory");
            }

            if (page > maxPage)
            {
                return this.View("InvalidPage");
            }

            var allVegetarianMainCourses = new AllVegetarianMainCoursesViewModel
            {
                AllVegetarianMainCourses = this.recipesService.GetRecipes<VegetarianMainCoursesViewModel>(subcategoryId, page),
                Total = this.recipesService.GetTotalRecipesFromSubcategory(subcategoryId),
                CurrentPage = page,
            };

            return this.View(allVegetarianMainCourses);
        }
    }
}
