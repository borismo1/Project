using FrontEnd.DTOs.Item;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FrontEnd.Model
{
    public static class ShoppingCart
    {
        public static List<ShoppingCartItemDto> Items { get; set; } = new List<ShoppingCartItemDto>();

        public static double TotalPrice 
        {
            get 
            {
                return Items.Sum(i => i.TotalPrice);
            }
        }

        public static string ItemCount
        {
            get
            {
                return Items.Sum(i => i.Qty).ToString();
            }
        }

        public static string GetItemsIds 
        {
            get 
            {
                return string.Join(',', Items.Select(i => i.Id.ToString()));
            }
        }

        public static List<GetItemDto> GetAsGetItemDto 
        {
            get 
            {
                List<GetItemDto> itemList = new List<GetItemDto>();
                foreach (ShoppingCartItemDto item in Items)
                    itemList.AddRange(item.GetItemDtoListFromCartDto());

                return itemList;
            }
        }

    }
}
