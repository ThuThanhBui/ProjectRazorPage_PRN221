using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PRN221.Pages.OrderMember
{
    public class FeedbackModel : PageModel
    {
        private readonly Data.Entities.PRNDbContext _context;


        public FeedbackModel(Data.Entities.PRNDbContext context)
        {
            _context = context;
        
        }

        [BindProperty]
        public ProductFeedback Feedback { get; set; }
        public void OnGet(Guid? id)
        {
            Feedback = new ProductFeedback(); // Kh?i t?o Feedback trong constructor
            if (id.HasValue)
            {
                HttpContext.Session.SetString("ProductId", id.Value.ToString());
                Feedback.ProductId = id.Value;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // L?y ProductId t? session
            var productIdString = HttpContext.Session.GetString("ProductId");
            if (productIdString != null && Guid.TryParse(productIdString, out Guid productId))
            {
                Feedback.ProductId = productId;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Product ID is not valid or not found.");
                return Page();
            }

            var userId = HttpContext.Session.GetString("userId");
            if (userId != null && Guid.TryParse(userId, out Guid parsedUserId))
            {
                Feedback.UserId = parsedUserId;
               
            }
            else
            {
                ModelState.AddModelError(string.Empty, "User ID is not valid.");
            }
            Feedback.CreatedDate = DateTime.UtcNow;
            Feedback.LastUpdatedDate = DateTime.UtcNow;
            Feedback.IsDeleted = false;

            try
            {
                _context.ProductFeedbacks.Add(Feedback);
                int affectedRows = await _context.SaveChangesAsync();
                if (affectedRows > 0)
                {
                    return RedirectToPage("/OrderMember");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to save feedback.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) details
                ModelState.AddModelError(string.Empty, "An error occurred while saving feedback.");
            }
            return Page();
        }
    }
}