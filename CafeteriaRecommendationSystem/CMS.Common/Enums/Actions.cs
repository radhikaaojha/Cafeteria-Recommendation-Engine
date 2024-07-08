using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Enums
{
    public enum Actions
    {
        Auth=1,
        AddFoodItem,
        RemoveFoodItem,
        UpdateFoodItemPrice,
        UpdateFoodItemStatus,
        ViewMenu,
        Logout,
        TopRecommendations,
        ViewNotifications,
        PlanNextDayMenu,
        FinalizeMenu,
        ViewVotes,
        SubmitFeedback,
        VoteForMenu,
        ViewRolledOutItems,
        ViewTodaysMenu,
        GenerateDiscardList,
        RollOutDetailedFeedbackQuestions,
        SubmitDetailedFeedback,
        RemoveDiscardedFoodItem,
        UserPreference,
        DiscardFoodItem
    }
}
