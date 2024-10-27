using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System;
using Delivery.Model;
using Delivery.DataBase;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Delivery.Core;

class DatabaseController
{
    LogWriter logWriter;
    public DatabaseController(LogWriter logWriter)
    {
        this.logWriter = logWriter;
        AutofillDatabase();
    }
    private static string ToLower(string property) => string.IsNullOrEmpty(property) ? string.Empty : property.ToLower();

    private static string ToUpperFirstChar(string property) => string.IsNullOrEmpty(property) ? string.Empty : char.ToUpper(property[0]) + property.Substring(1);

    private async Task AutofillDatabase()
    {
        try
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                if (context.Orders.Any())
                {
                    return;
                }

                var orders = new List<Order>();

                for (int i = 0; i < 10; i++)
                {
                    orders.Add(new Order
                    {
                        NumberOrder = $"KO-{i + 1:00}",
                        Kg = (float)(i + 1) * 1.5f,
                        District = "куковка",
                        DateOrder = DateTime.Today.AddHours(12).AddMinutes(i * 18)
                    });
                }

                for (int i = 0; i < 10; i++)
                {
                    orders.Add(new Order
                    {
                        NumberOrder = $"GO-{i + 1:00}",
                        Kg = (float)(i + 1) * 2.0f,
                        District = "голиковка",
                        DateOrder = DateTime.Today.AddHours(16).AddMinutes(i * 18)
                    });
                }

                await context.Orders.AddRangeAsync(orders);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            logWriter.WriteLog($"Произошла ошибка при автозаполнении базы данных: {ex}");
            MessageBox.Show("Произошла ошибка при автозаполнении базы данных");
        }
    }

    public async Task<List<Order>> SearchPatients(OrderFilter orderFilter)
    {
        try
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var startDate = orderFilter.DateOrder; // Начальная дата
                var endDate = startDate.AddMinutes(30); // Конечная дата (+30 минут)

                var query = context.Orders.Where(p => p.District.StartsWith(ToLower(orderFilter.District)) && (p.DateOrder >= startDate && p.DateOrder <= endDate));

                var result = await query.ToListAsync();

                foreach (var item in result)
                {
                    item.District = ToUpperFirstChar(item.District);
                }

                logWriter.WriteLog($"При сортировке было найдено {result.Count} заказов");
                return result;
            }
        }
        catch (Exception ex)
        {
            logWriter.WriteLog($"Произошла ошибка при сортировке заказов: {ex}");
            return null;
        }
    }
}
