using CMS.Data.Repository.Interfaces;
using Common.Enums;
using Data_Access_Layer;
using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FoodItemType = Common.Enums.FoodItemType;

namespace CMS.Data.Repository
{
    public class SentimentAnalyzerRepository : ISentimentAnalyzerRepository
    {
        protected readonly CMSDbContext _context;

        public SentimentAnalyzerRepository(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<List<FoodItem>> GetNextDayMenuRecommendation()
        {
            DateTime yesterday = DateTime.Now.AddDays(-1);
            Expression<Func<FoodItem, bool>> predicate = foodItem =>
                       foodItem.StatusId == (int)Status.Available &&
                       !_context.WeeklyMenu.Any(weeklyMenu =>
                           weeklyMenu.FoodItemId == foodItem.Id &&
                           weeklyMenu.IsSelected && weeklyMenu.CreatedDateTime.Date == yesterday.Date);


            var allAvailableFoodItems = await _context.FoodItem.Include(u => u.FoodItemFeedback).Where(predicate).OrderByDescending(u => u.SentimentScore).Take(15).ToListAsync() ;
            var mainCourseOptions = allAvailableFoodItems.Where(fi => fi.FoodItemTypeId == (int)FoodItemType.MainCourses).Take(5).ToList();
            var otherItemOptions = allAvailableFoodItems
                                   .Where(fi => fi.FoodItemTypeId != (int)FoodItemType.MainCourses)
                                   .GroupBy(fi => fi.FoodItemTypeId)
                                   .SelectMany(g => g.Take(2))
                                   .Take(10)
                                   .ToList();
            if (otherItemOptions.Count < 10)
            {
                otherItemOptions.AddRange(
                    allAvailableFoodItems
                    .Except(mainCourseOptions)
                    .Except(otherItemOptions)
                    .Take(10 - otherItemOptions.Count)
                );
            }
            var combinedOptions = mainCourseOptions.Concat(otherItemOptions).OrderByDescending(u => u.SentimentScore).ToList();

            return combinedOptions;
        }
    }
}
