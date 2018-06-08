﻿using System.Collections;
using PokemonUnity;
using PokemonUnity.Item;


public class Item
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Price { get; private set; }
    
    public Items ItemId { get; private set; }
    public ItemFlags[] ItemFlags { get; private set; }
    public ItemCategory ItemCategory { get; private set; }
    public ItemPockets? ItemPocket { get {
            ItemPockets? itemPocket;
            switch (this.ItemCategory)
            {//([\w]*) = [\d]*, //PocketId = ([\d]*)
                case ItemCategory.COLLECTIBLES: itemPocket = (ItemPockets)1; break;
                case ItemCategory.EVOLUTION: itemPocket = (ItemPockets)1; break;
                case ItemCategory.SPELUNKING: itemPocket = (ItemPockets)1; break;
                case ItemCategory.HELD_ITEMS: itemPocket = (ItemPockets)1; break;
                case ItemCategory.CHOICE: itemPocket = (ItemPockets)1; break;
                case ItemCategory.EFFORT_TRAINING: itemPocket = (ItemPockets)1; break;
                case ItemCategory.BAD_HELD_ITEMS: itemPocket = (ItemPockets)1; break;
                case ItemCategory.TRAINING: itemPocket = (ItemPockets)1; break;
                case ItemCategory.PLATES: itemPocket = (ItemPockets)1; break;
                case ItemCategory.SPECIES_SPECIFIC: itemPocket = (ItemPockets)1; break;
                case ItemCategory.TYPE_ENHANCEMENT: itemPocket = (ItemPockets)1; break;
                case ItemCategory.LOOT: itemPocket = (ItemPockets)1; break;
                case ItemCategory.MULCH: itemPocket = (ItemPockets)1; break;
                case ItemCategory.DEX_COMPLETION: itemPocket = (ItemPockets)1; break;
                case ItemCategory.SCARVES: itemPocket = (ItemPockets)1; break;
                case ItemCategory.JEWELS: itemPocket = (ItemPockets)1; break;
                case ItemCategory.MEGA_STONES: itemPocket = (ItemPockets)1; break;

                case ItemCategory.VITAMINS: itemPocket = (ItemPockets)2; break;
                case ItemCategory.HEALING: itemPocket = (ItemPockets)2; break;
                case ItemCategory.PP_RECOVERY: itemPocket = (ItemPockets)2; break;
                case ItemCategory.REVIVAL: itemPocket = (ItemPockets)2; break;
                case ItemCategory.STATUS_CURES: itemPocket = (ItemPockets)2; break;

                case ItemCategory.SPECIAL_BALLS: itemPocket = (ItemPockets)3; break;
                case ItemCategory.STANDARD_BALLS: itemPocket = (ItemPockets)3; break;
                case ItemCategory.APRICORN_BALLS: itemPocket = (ItemPockets)3; break;

                case ItemCategory.ALL_MACHINES: itemPocket = (ItemPockets)4; break;

                case ItemCategory.EFFORT_DROP: itemPocket = (ItemPockets)5; break;
                case ItemCategory.MEDICINE: itemPocket = (ItemPockets)5; break;
                case ItemCategory.OTHER: itemPocket = (ItemPockets)5; break;
                case ItemCategory.IN_A_PINCH: itemPocket = (ItemPockets)5; break;
                case ItemCategory.PICKY_HEALING: itemPocket = (ItemPockets)5; break;
                case ItemCategory.TYPE_PROTECTION: itemPocket = (ItemPockets)5; break;
                case ItemCategory.BAKING_ONLY: itemPocket = (ItemPockets)5; break;

                case ItemCategory.ALL_MAIL: itemPocket = (ItemPockets)6; break;

                case ItemCategory.STAT_BOOSTS: itemPocket = (ItemPockets)7; break;
                case ItemCategory.FLUTES: itemPocket = (ItemPockets)7; break;
                case ItemCategory.MIRACLE_SHOOTER: itemPocket = (ItemPockets)7; break;

                case ItemCategory.EVENT_ITEMS: itemPocket = (ItemPockets)8; break;
                case ItemCategory.GAMEPLAY: itemPocket = (ItemPockets)8; break;
                case ItemCategory.PLOT_ADVANCEMENT: itemPocket = (ItemPockets)8; break;
                case ItemCategory.UNUSED: itemPocket = (ItemPockets)8; break;
                case ItemCategory.APRICORN_BOX: itemPocket = (ItemPockets)8; break;
                case ItemCategory.DATA_CARDS: itemPocket = (ItemPockets)8; break;
                case ItemCategory.XY_UNKNOWN: itemPocket = (ItemPockets)8; break;
                default:
                    itemPocket = null;
                    break;
            }
            return itemPocket;
        } }
    public ItemFlingEffect ItemFlingEffect { get; private set; }

    Item(Items itemId) {
        //this.Price = ItemData.getIndexOf(itemId);
    }

    /// <summary>
    /// Returns int value of Pokemon from PokemonData[] <see cref="Database"/>
    /// </summary>
    public int ArrayId
    {//(Pokemon ID)
        get
        {
            //Debug.Log("Get Pokemons");
            /*PokemonData result = null;
			int i = 1;
			while(result == null){
				if(Database[i].ID == ID){
					//Debug.Log("Pokemon DB Success");
					return result = Database[i];
				}
				i += 1;
				if(i >= Database.Length){
					Debug.Log("Pokemon DB Fail");
					return null;}
			}
			return result;*/
            /*foreach(PokemonData pokemon in Database)
			{
				if (pokemon.ID == ID) return pokemon;
			}*/
            for (int i = 0; i < Database.Length; i++)
            {
                if (Database[i].ItemId == this.ItemId)
                {
                    return i;
                }
            }
            throw new System.Exception("Pokemon ID doesnt exist in the database. Please check PokemonData constructor.");
        }
    }

    private Item(Items itemId, ItemCategory itemCategory = ItemCategory.UNUSED, /*BattleType battleType, string description,*/ int price = 0, int? flingPower = null,
        ItemFlingEffect? itemEffect = null, /*string stringParameter, float floatParameter,*/ ItemFlags[] flags = null)
    {
        //this.name = name;
        //this.itemType = itemType;
        //this.battleType = battleType;
        //this.description = description;
        this.Price = price;
        //this.itemEffect = itemEffect;
        //this.stringParameter = stringParameter;
        //this.floatParameter = floatParameter;
    }

    private Item(int itemId, int itemCategory, /*BattleType battleType, string description,;*/ int price, int? flingPower,
        int? itemEffect, /*string stringParameter, float floatParameter,*/ int[] flags = null) : this((Items)itemId, (ItemCategory)itemCategory, price, flingPower, (ItemFlingEffect)itemEffect, System.Array.ConvertAll(flags, item => (ItemFlags)item))
    {
        //return 
        //new Item((Items)itemId, (ItemCategory)itemCategory, price, flingPower, (ItemFlingEffect)itemEffect, System.Array.ConvertAll(flags, item => (ItemFlags)item));
    }

    #region ItemDatabase
    /// <summary>
    /// Replaces <see cref="oldItems"/>
    /// </summary>
    /// <remarks>
    /// \((\d*)\s*(\d*)\s*(\d*)\s*([\d\w]*)\s*([\d\w]*)\s*
    /// </remarks>
    private static readonly Item[] Database = new Item[] {
new Item(1,     34,     0, null, null, new int[]{1,2,4,5}),
new Item(2,     34,     1200, null, null, new int[]{1,2,4,5}),
new Item(3,     34,     600, null, null, new int[]{1,2,4,5}),
new Item(4,     34,     200, null, null, new int[]{1,2,4,5}),
new Item(5,     34,     0, null, null, new int[]{1,2,4,5}),
new Item(6,     33,     1000, null, null, new int[]{1,2,4,5}),
new Item(7,     33,     1000, null, null, new int[]{1,2,4,5}),
new Item(8,     33,     1000, null, null, new int[]{1,2,4,5}),
new Item(9,     33,     1000, null, null, new int[]{1,2,4,5}),
new Item(10,    33,     1000, null, null, new int[]{1,2,4,5}),
new Item(11,    33,     1000, null, null, new int[]{1,2,4,5}),
new Item(12,    33,     200, null, null, new int[]{1,2,4,5}),
new Item(13,    33,     1000, null, null, new int[]{1,2,4,5}),
new Item(14,    33,     300, null, null, new int[]{1,2,4,5}),
new Item(15,    33,     1000, null, null, new int[]{1,2,4,5}),
new Item(16,    33,     200, null, null, new int[]{1,2,4,5}),
new Item(17,    27,     300, 30, null, new int[]{1,2,3,4,5}),
new Item(18,    30,     100, 30, null, new int[]{1,2,3,4,5}),
new Item(19,    30,     250, 30, null, new int[]{1,2,3,4,5}),
new Item(20,    30,     250, 30, null, new int[]{1,2,3,4,5}),
new Item(21,    30,     250, 30, null, new int[]{1,2,3,4,5}),
new Item(22,    30,     200, 30, null, new int[]{1,2,3,4,5}),
new Item(23,    27,     3000, 30, null, new int[]{1,2,3,4,5}),
new Item(24,    27,     2500, 30, null, new int[]{1,2,3,4,5}),
new Item(25,    27,     1200, 30, null, new int[]{1,2,3,4,5}),
new Item(26,    27,     700, 30, null, new int[]{1,2,3,4,5}),
new Item(27,    30,     600, 30, null, new int[]{1,2,3,4,5}),
new Item(28,    29,     1500, 30, null, new int[]{1,2,3,4,5,8}),
new Item(29,    29,     4000, 30, null, new int[]{1,2,3,4,5,8}),
new Item(30,    27,     200, 30, null, new int[]{1,2,3,4,5}),
new Item(31,    27,     300, 30, null, new int[]{1,2,3,4,5}),
new Item(32,    27,     350, 30, null, new int[]{1,2,3,4,5}),
new Item(33,    27,     500, 30, null, new int[]{1,2,3,4,5}),
new Item(34,    27,     500, 30, null, new int[]{1,2,3,4,5}),
new Item(35,    27,     800, 30, null, new int[]{1,2,3,4,5}),
new Item(36,    30,     450, 30, null, new int[]{1,2,3,4,5}),
new Item(37,    29,     2800, 30, null, new int[]{1,2,3,4,5}),
new Item(38,    28,     1200, 30, null, new int[]{1,2,3,4,5}),
new Item(39,    28,     2000, 30, null, new int[]{1,2,3,4,5}),
new Item(40,    28,     3000, 30, null, new int[]{1,2,3,4,5}),
new Item(41,    28,     4500, 30, null, new int[]{1,2,3,4,5}),
new Item(42,    30,     200, 30, null, new int[]{1,2,3,4,5}),
new Item(43,    27,     100, 30, null, new int[]{1,2,3,4,5}),
new Item(44,    29,     200, 30, null, new int[]{1,2,3,4,5}),
new Item(45,    26,     9800, 30, null, new int[]{1,2,3,4,5}),
new Item(46,    26,     9800, 30, null, new int[]{1,2,3,4,5}),
new Item(47,    26,     9800, 30, null, new int[]{1,2,3,4,5}),
new Item(48,    26,     9800, 30, null, new int[]{1,2,3,4,5}),
new Item(49,    26,     9800, 30, null, new int[]{1,2,3,4,5}),
new Item(50,    26,     4800, 30, null, new int[]{1,2,3,4,5}),
new Item(51,    26,     9800, 30, null, new int[]{1,2,3,4,5}),
new Item(52,    26,     9800, 30, null, new int[]{1,2,3,4,5}),
new Item(53,    26,     9800, 30, null, new int[]{1,2,3,4,5}),
new Item(54,    30,     200, 30, null, new int[]{1,2,3,4,5}),
new Item(55,    1,      700, 30, null, new int[]{1,2,4,5}),
new Item(56,    1,      650, 30, null, new int[]{1,2,4,5}),
new Item(57,    1,      500, 30, null, new int[]{1,2,4,5}),
new Item(58,    1,      550, 30, null, new int[]{1,2,4,5}),
new Item(59,    1,      350, 30, null, new int[]{1,2,4,5}),
new Item(60,    1,      950, 30, null, new int[]{1,2,4,5}),
new Item(61,    1,      350, 30, null, new int[]{1,2,4,5}),
new Item(62,    1,      350, 30, null, new int[]{1,2,4,5}),
new Item(63,    11,     1000, 30, null, new int[]{1,2,4,5}),
new Item(64,    11,     1000, 30, null, new int[]{1,2,4,5}),
new Item(65,    38,     100, 30, null, new int[]{1,2,3,4,5}),
new Item(66,    38,     200, 30, null, new int[]{1,2,4,5}),
new Item(67,    38,     300, 30, null, new int[]{1,2,4,5}),
new Item(68,    11,     400, 30, null, new int[]{1,2,3,5}),
new Item(69,    11,     500, 30, null, new int[]{1,2,3,5}),
new Item(70,    9,      20, 30, null, new int[]{1}),
new Item(71,    9,      20, 30, null, new int[]{1}),
new Item(72,    9,      200, 30, null, new int[]{8}),
new Item(73,    9,      200, 30, null, new int[]{8}),
new Item(74,    9,      200, 30, null, new int[]{8}),
new Item(75,    9,      200, 30, null, new int[]{8}),
new Item(76,    11,     500, 30, null, null    ),
new Item(77,    11,     700, 30, null, null    ),
new Item(78,    11,     550, 30, null, null    ),
new Item(79,    11,     350, 30, null, null    ),
new Item(80,    10,     2100, 30, null, new int[]{8}),
new Item(81,    10,     2100, 30, null, new int[]{8}),
new Item(82,    10,     2100, 30, null, new int[]{8}),
new Item(83,    10,     2100, 30, null, new int[]{8}),
new Item(84,    10,     2100, 30, null, new int[]{8}),
new Item(85,    10,     2100, 30, null, new int[]{8}),
new Item(86,    24,     500, 30, null, null    ),
new Item(87,    24,     5000, 30, null, null    ),
new Item(88,    24,     1400, 30, null, null    ),
new Item(89,    24,     7500, 30, null, null    ),
new Item(90,    24,     2000, 30, null, null    ),
new Item(91,    24,     9800, 30, null, new int[]{8}),
new Item(92,    24,     10000, 30, null, null    ),
new Item(93,    9,      100, 30, null, new int[]{8}),
new Item(94,    35,     100, 30, null, null    ),
new Item(95,    32,     200, 30, null, null    ),
new Item(96,    32,     200, 30, null, null    ),
new Item(97,    32,     200, 30, null, null    ),
new Item(98,    32,     200, 30, null, null    ),
new Item(99,    35,     1000, 100, null, new int[]{8}),
new Item(100,   35,     1000, 100, null, new int[]{8}),
new Item(101,   35,     1000, 100, null, new int[]{8}),
new Item(102,   35,     1000, 100, null, new int[]{8}),
new Item(103,   35,     1000, 100, null, new int[]{8}),
new Item(104,   35,     1000, 100, null, new int[]{8}),
new Item(105,   35,     1000, 100, null, new int[]{8}),
new Item(106,   24,     10000, 100, null, new int[]{8}),
new Item(107,   10,     2100, 80, null, null    ),
new Item(108,   10,     2100, 80, null, null    ),
new Item(109,   10,     2100, 80, null, null    ),
new Item(110,   10,     2100, 80, null, new int[]{8}),
new Item(111,   35,     2100, 80, null, new int[]{8}),
new Item(112,   18,     10000, 60, null, new int[]{5}),
new Item(113,   18,     10000, 60, null, new int[]{5}),
new Item(114,   25,     50, null, null, null    ),
new Item(115,   25,     50, null, null, null    ),
new Item(116,   25,     50, null, null, null    ),
new Item(117,   25,     50, null, null, null    ),
new Item(118,   25,     50, null, null, null    ),
new Item(119,   25,     50, null, null, null    ),
new Item(120,   25,     50, null, null, null    ),
new Item(121,   25,     50, null, null, null    ),
new Item(122,   25,     50, null, null, null    ),
new Item(123,   25,     50, null, null, null    ),
new Item(124,   25,     50, null, null, null    ),
new Item(125,   25,     50, null, null, null    ),
new Item(126,   3,      20, 10, 3, new int[]{7}),
new Item(127,   3,      20, 10, 3, new int[]{7}),
new Item(128,   3,      20, 10, 3, new int[]{7}),
new Item(129,   3,      20, 10, 3, new int[]{7}),
new Item(130,   3,      20, 10, 3, new int[]{7}),
new Item(131,   3,      20, 10, 3, new int[]{7}),
new Item(132,   3,      20, 10, 3, new int[]{7}),
new Item(133,   3,      20, 10, 3, new int[]{7}),
new Item(134,   3,      20, 10, 3, new int[]{7}),
new Item(135,   3,      20, 10, 3, new int[]{7}),
new Item(136,   6,      20, 10, 3, new int[]{7}),
new Item(137,   6,      20, 10, 3, new int[]{7}),
new Item(138,   6,      20, 10, 3, new int[]{7}),
new Item(139,   6,      20, 10, 3, new int[]{7}),
new Item(140,   6,      20, 10, 3, new int[]{7}),
new Item(141,   8,      20, 10, null, null    ),
new Item(142,   8,      20, 10, null, null    ),
new Item(143,   8,      20, 10, null, null    ),
new Item(144,   8,      20, 10, null, null    ),
new Item(145,   8,      20, 10, null, null    ),
new Item(146,   2,      20, 10, null, null    ),
new Item(147,   2,      20, 10, null, null    ),
new Item(148,   2,      20, 10, null, null    ),
new Item(149,   2,      20, 10, null, null    ),
new Item(150,   2,      20, 10, null, null    ),
new Item(151,   2,      20, 10, null, null    ),
new Item(152,   8,      20, 10, null, null    ),
new Item(153,   8,      20, 10, null, null    ),
new Item(154,   8,      20, 10, null, null    ),
new Item(155,   8,      20, 10, null, null    ),
new Item(156,   8,      20, 10, null, null    ),
new Item(157,   8,      20, 10, null, null    ),
new Item(158,   8,      20, 10, null, null    ),
new Item(159,   8,      20, 10, null, null    ),
new Item(160,   8,      20, 10, null, null    ),
new Item(161,   7,      20, 10, null, new int[]{7}),
new Item(162,   7,      20, 10, null, new int[]{7}),
new Item(163,   7,      20, 10, null, new int[]{7}),
new Item(164,   7,      20, 10, null, new int[]{7}),
new Item(165,   7,      20, 10, null, new int[]{7}),
new Item(166,   7,      20, 10, null, new int[]{7}),
new Item(167,   7,      20, 10, null, new int[]{7}),
new Item(168,   7,      20, 10, null, new int[]{7}),
new Item(169,   7,      20, 10, null, new int[]{7}),
new Item(170,   7,      20, 10, null, new int[]{7}),
new Item(171,   7,      20, 10, null, new int[]{7}),
new Item(172,   7,      20, 10, null, new int[]{7}),
new Item(173,   7,      20, 10, null, new int[]{7}),
new Item(174,   7,      20, 10, null, new int[]{7}),
new Item(175,   7,      20, 10, null, new int[]{7}),
new Item(176,   7,      20, 10, null, new int[]{7}),
new Item(177,   7,      20, 10, null, new int[]{7}),
new Item(178,   5,      20, 10, 3, new int[]{7}),
new Item(179,   5,      20, 10, 3, new int[]{7}),
new Item(180,   5,      20, 10, 3, new int[]{7}),
new Item(181,   5,      20, 10, 3, new int[]{7}),
new Item(182,   5,      20, 10, 3, new int[]{7}),
new Item(183,   5,      20, 10, 3, new int[]{7}),
new Item(184,   5,      20, 10, 3, new int[]{7}),
new Item(185,   4,      20, 10, null, new int[]{7}),
new Item(186,   5,      20, 10, 3, new int[]{7}),
new Item(187,   5,      20, 10, null, new int[]{7}),
new Item(188,   4,      20, 10, null, new int[]{7}),
new Item(189,   4,      20, 10, null, new int[]{7}),
new Item(190,   12,     10, 10, null, new int[]{5,7}),
new Item(191,   12,     100, 10, 4, new int[]{5,7}),
new Item(192,   14,     3000, 60, null, new int[]{5,7}),
new Item(193,   16,     3000, 30, null, new int[]{5,7}),
new Item(194,   12,     100, 80, null, new int[]{5,7}),
new Item(195,   16,     100, 10, null, new int[]{5,7}),
new Item(196,   12,     100, 10, 4, new int[]{5,7}),
new Item(197,   13,     100, 10, null, new int[]{5,7}),
new Item(198,   12,     100, 30, 7, new int[]{5,7}),
new Item(199,   19,     100, 10, null, new int[]{5,7}),
new Item(200,   16,     100, 30, null, new int[]{5,7}),
new Item(201,   16,     200, 30, null, new int[]{5}),
new Item(202,   18,     200, 30, null, new int[]{5}),
new Item(203,   18,     200, 90, null, new int[]{5}),
new Item(204,   18,     200, 30, null, new int[]{5}),
new Item(205,   12,     200, 30, null, new int[]{5,7}),
new Item(206,   16,     200, 30, null, new int[]{5,7,8}),
new Item(207,   12,     200, 10, null, new int[]{5,7}),
new Item(208,   16,     200, 30, null, new int[]{5,7}),
new Item(209,   12,     200, 30, null, new int[]{5,7}),
new Item(210,   19,     100, 30, null, new int[]{5,7}),
new Item(211,   12,     200, 10, null, new int[]{5,7}),
new Item(212,   10,     2100, 30, null, null    ),
new Item(213,   18,     100, 30, 5, new int[]{5}),
new Item(214,   19,     100, 10, null, new int[]{5,7}),
new Item(215,   19,     100, 100, null, new int[]{5,7,8}),
new Item(216,   19,     100, 30, null, new int[]{5,7}),
new Item(217,   19,     100, 30, null, new int[]{5,7}),
new Item(218,   19,     100, 30, null, new int[]{5,7}),
new Item(219,   19,     100, 30, null, new int[]{5,7}),
new Item(220,   19,     100, 30, null, new int[]{5,7}),
new Item(221,   19,     100, 50, null, new int[]{5,7}),
new Item(222,   19,     100, 70, 6, new int[]{5,7}),
new Item(223,   19,     100, 30, null, new int[]{5,7}),
new Item(224,   19,     100, 30, null, new int[]{5,7}),
new Item(225,   19,     100, 30, null, new int[]{5,7}),
new Item(226,   19,     9800, 30, null, new int[]{5,7}),
new Item(227,   19,     100, 70, null, new int[]{5,7}),
new Item(228,   19,     100, 10, null, new int[]{5,7}),
new Item(229,   10,     2100, 30, null, null    ),
new Item(230,   12,     200, 30, null, new int[]{5,7}),
new Item(231,   19,     9600, 10, null, new int[]{5,7}),
new Item(232,   12,     9600, 10, null, new int[]{5,7}),
new Item(233,   18,     10, 40, null, new int[]{5}),
new Item(234,   18,     10, 10, null, new int[]{5}),
new Item(235,   18,     500, 90, null, new int[]{5}),
new Item(236,   18,     200, 60, null, new int[]{5}),
new Item(237,   36,     100, 10, null, new int[]{7}),
new Item(238,   36,     100, 10, null, new int[]{7}),
new Item(239,   36,     100, 10, null, new int[]{7}),
new Item(240,   36,     100, 10, null, new int[]{7}),
new Item(241,   36,     100, 10, null, new int[]{7}),
new Item(242,   12,     200, 10, null, new int[]{5,7}),
new Item(243,   12,     200, 10, null, new int[]{5,7}),
new Item(244,   12,     200, 10, null, new int[]{5,7}),
new Item(245,   12,     200, 10, null, new int[]{5,7}),
new Item(246,   12,     200, 30, null, new int[]{5,7,8}),
new Item(247,   12,     200, 30, null, new int[]{5,7}),
new Item(248,   12,     100, 10, null, new int[]{5,7}),
new Item(249,   15,     100, 30, 1, new int[]{5,7}),
new Item(250,   15,     100, 30, 2, new int[]{5,7}),
new Item(251,   18,     10, 10, null, new int[]{5}),
new Item(252,   12,     200, 10, null, new int[]{5,7}),
new Item(253,   12,     200, 10, null, new int[]{5,7}),
new Item(254,   12,     200, 30, null, new int[]{5,7}),
new Item(255,   15,     200, 130, null, new int[]{5,7,8}),
new Item(256,   15,     200, 10, null, new int[]{5,7}),
new Item(257,   12,     200, 10, null, new int[]{5,7}),
new Item(258,   12,     200, 30, null, new int[]{5,7}),
new Item(259,   12,     200, 40, null, new int[]{5,7,8}),
new Item(260,   12,     200, 10, null, new int[]{5,7,8}),
new Item(261,   12,     200, 60, null, new int[]{5,7,8}),
new Item(262,   12,     200, 60, null, new int[]{5,7,8}),
new Item(263,   12,     200, 90, null, new int[]{5,7}),
new Item(264,   13,     200, 10, null, new int[]{5,7}),
new Item(265,   15,     200, 80, null, new int[]{5,7}),
new Item(266,   14,     3000, 70, null, new int[]{5,7}),
new Item(267,   14,     3000, 70, null, new int[]{5,7}),
new Item(268,   14,     3000, 70, null, new int[]{5,7}),
new Item(269,   14,     3000, 70, null, new int[]{5,7}),
new Item(270,   14,     3000, 70, null, new int[]{5,7}),
new Item(271,   14,     3000, 70, null, new int[]{5,7}),
new Item(272,   12,     100, 10, null, new int[]{5,7}),
new Item(273,   12,     200, 10, null, new int[]{5,7}),
new Item(274,   13,     200, 10, null, new int[]{5,7}),
new Item(275,   17,     1000, 90, null, new int[]{5,7,8}),
new Item(276,   17,     1000, 90, null, new int[]{5,7,8}),
new Item(277,   17,     1000, 90, null, new int[]{5,7,8}),
new Item(278,   17,     1000, 90, null, new int[]{5,7,8}),
new Item(279,   17,     1000, 90, null, new int[]{5,7,8}),
new Item(280,   17,     1000, 90, null, new int[]{5,7,8}),
new Item(281,   17,     1000, 90, null, new int[]{5,7,8}),
new Item(282,   17,     1000, 90, null, new int[]{5,7,8}),
new Item(283,   17,     1000, 90, null, new int[]{5,7,8}),
new Item(284,   17,     1000, 90, null, new int[]{5,7,8}),
new Item(285,   17,     1000, 90, null, new int[]{5,7,8}),
new Item(286,   17,     1000, 90, null, new int[]{5,7,8}),
new Item(287,   17,     1000, 90, null, new int[]{5,7,8}),
new Item(288,   17,     1000, 90, null, new int[]{5,7,8}),
new Item(289,   17,     1000, 90, null, new int[]{5,7,8}),
new Item(290,   17,     1000, 90, null, new int[]{5,7,8}),
new Item(291,   19,     9600, 10, null, new int[]{5,7}),
new Item(292,   19,     9600, 10, null, new int[]{5,7}),
new Item(293,   15,     9600, 10, null, new int[]{5,7}),
new Item(294,   19,     9600, 10, null, new int[]{5,7}),
new Item(295,   19,     9600, 10, null, new int[]{5,7}),
new Item(296,   16,     9600, 10, null, new int[]{5,7}),
new Item(297,   16,     9600, 10, null, new int[]{5}),
new Item(298,   10,     2100, 80, null, null    ),
new Item(299,   10,     2100, 80, null, null    ),
new Item(300,   10,     2100, 80, null, null    ),
new Item(301,   10,     2100, 50, null, null    ),
new Item(302,   10,     2100, 10, null, null    ),
new Item(303,   12,     2100, 80, null, new int[]{5,7}),
new Item(304,   12,     2100, 30, 7, new int[]{5,7}),
new Item(305,   37,     3000, null, null, null    ),
new Item(306,   37,     3000, null, null, null    ),
new Item(307,   37,     3000, null, null, null    ),
new Item(308,   37,     1500, null, null, null    ),
new Item(309,   37,     1000, null, null, null    ),
new Item(310,   37,     3000, null, null, null    ),
new Item(311,   37,     2000, null, null, null    ),
new Item(312,   37,     1500, null, null, null    ),
new Item(313,   37,     2000, null, null, null    ),
new Item(314,   37,     2000, null, null, null    ),
new Item(315,   37,     2000, null, null, null    ),
new Item(316,   37,     1500, null, null, null    ),
new Item(317,   37,     3000, null, null, null    ),
new Item(318,   37,     5500, null, null, null    ),
new Item(319,   37,     7500, null, null, null    ),
new Item(320,   37,     2000, null, null, null    ),
new Item(321,   37,     2000, null, null, null    ),
new Item(322,   37,     2000, null, null, null    ),
new Item(323,   37,     3000, null, null, null    ),
new Item(324,   37,     2000, null, null, null    ),
new Item(325,   37,     1000, null, null, null    ),
new Item(326,   37,     3000, null, null, null    ),
new Item(327,   37,     3000, null, null, null    ),
new Item(328,   37,     3000, null, null, null    ),
new Item(329,   37,     5500, null, null, null    ),
new Item(330,   37,     3000, null, null, null    ),
new Item(331,   37,     1000, null, null, null    ),
new Item(332,   37,     2000, null, null, null    ),
new Item(333,   37,     3000, null, null, null    ),
new Item(334,   37,     3000, null, null, null    ),
new Item(335,   37,     3000, null, null, null    ),
new Item(336,   37,     1000, null, null, null    ),
new Item(337,   37,     2000, null, null, null    ),
new Item(338,   37,     3000, null, null, null    ),
new Item(339,   37,     3000, null, null, null    ),
new Item(340,   37,     3000, null, null, null    ),
new Item(341,   37,     2000, null, null, null    ),
new Item(342,   37,     5500, null, null, null    ),
new Item(343,   37,     2000, null, null, null    ),
new Item(344,   37,     3000, null, null, null    ),
new Item(345,   37,     1500, null, null, null    ),
new Item(346,   37,     3000, null, null, null    ),
new Item(347,   37,     2000, null, null, null    ),
new Item(348,   37,     3000, null, null, null    ),
new Item(349,   37,     3000, null, null, null    ),
new Item(350,   37,     2000, null, null, null    ),
new Item(351,   37,     3000, null, null, null    ),
new Item(352,   37,     3000, null, null, null    ),
new Item(353,   37,     1500, null, null, null    ),
new Item(354,   37,     5500, null, null, null    ),
new Item(355,   37,     2000, null, null, null    ),
new Item(356,   37,     5500, null, null, null    ),
new Item(357,   37,     3000, null, null, null    ),
new Item(358,   37,     2000, null, null, null    ),
new Item(359,   37,     3000, null, null, null    ),
new Item(360,   37,     2000, null, null, null    ),
new Item(361,   37,     3000, null, null, null    ),
new Item(362,   37,     2000, null, null, null    ),
new Item(363,   37,     3000, null, null, null    ),
new Item(364,   37,     3000, null, null, null    ),
new Item(365,   37,     2000, null, null, null    ),
new Item(366,   37,     3000, null, null, null    ),
new Item(367,   37,     2000, null, null, null    ),
new Item(368,   37,     7500, null, null, null    ),
new Item(369,   37,     3000, null, null, null    ),
new Item(370,   37,     3000, null, null, null    ),
new Item(371,   37,     1000, null, null, null    ),
new Item(372,   37,     7500, null, null, null    ),
new Item(373,   37,     1500, null, null, null    ),
new Item(374,   37,     1000, null, null, null    ),
new Item(375,   37,     3000, null, null, null    ),
new Item(376,   37,     3000, null, null, null    ),
new Item(377,   37,     2000, null, null, null    ),
new Item(378,   37,     3000, null, null, null    ),
new Item(379,   37,     1500, null, null, null    ),
new Item(380,   37,     2000, null, null, null    ),
new Item(381,   37,     1500, null, null, null    ),
new Item(382,   37,     1500, null, null, null    ),
new Item(383,   37,     3000, null, null, null    ),
new Item(384,   37,     3000, null, null, null    ),
new Item(385,   37,     3000, null, null, null    ),
new Item(386,   37,     1000, null, null, null    ),
new Item(387,   37,     2000, null, null, null    ),
new Item(388,   37,     3000, null, null, null    ),
new Item(389,   37,     3000, null, null, null    ),
new Item(390,   37,     3000, null, null, null    ),
new Item(391,   37,     1500, null, null, null    ),
new Item(392,   37,     3000, null, null, null    ),
new Item(393,   37,     3000, null, null, null    ),
new Item(394,   37,     2000, null, null, null    ),
new Item(395,   37,     3000, null, null, null    ),
new Item(396,   37,     5500, null, null, null    ),
new Item(397,   37,     0, null, null, null    ),
new Item(398,   37,     0, null, null, null    ),
new Item(399,   37,     0, null, null, null    ),
new Item(400,   37,     0, null, null, null    ),
new Item(401,   37,     0, null, null, null    ),
new Item(402,   37,     0, null, null, null    ),
new Item(403,   37,     0, null, null, null    ),
new Item(404,   37,     0, null, null, null    ),
new Item(405,   21,     0, null, null, null    ),
new Item(406,   23,     0, null, null, null    ),
new Item(407,   23,     0, null, null, null    ),
new Item(408,   21,     0, null, null, null    ),
new Item(409,   21,     0, null, null, null    ),
new Item(410,   21,     0, null, null, null    ),
new Item(411,   21,     0, null, null, null    ),
new Item(412,   21,     0, null, null, null    ),
new Item(413,   23,     0, null, null, null    ),
new Item(414,   21,     0, null, null, null    ),
new Item(415,   22,     0, null, null, null    ),
new Item(416,   22,     0, null, null, null    ),
new Item(417,   22,     0, null, null, null    ),
new Item(418,   23,     0, null, null, null    ),
new Item(419,   21,     0, null, null, null    ),
new Item(420,   21,     0, null, null, null    ),
new Item(421,   21,     0, null, null, null    ),
new Item(422,   21,     0, null, null, null    ),
new Item(423,   21,     0, null, null, null    ),
new Item(424,   21,     0, null, null, null    ),
new Item(425,   21,     0, null, null, null    ),
new Item(426,   21,     0, null, null, null    ),
new Item(427,   21,     0, null, null, null    ),
new Item(428,   20,     0, null, null, null    ),
new Item(429,   20,     0, null, null, null    ),
new Item(430,   20,     0, null, null, null    ),
new Item(431,   20,     0, null, null, null    ),
new Item(432,   20,     0, null, null, null    ),
new Item(433,   22,     0, null, null, null    ),
new Item(434,   21,     0, null, null, null    ),
new Item(435,   22,     0, null, null, null    ),
new Item(436,   22,     0, null, null, null    ),
new Item(437,   22,     0, null, null, null    ),
new Item(438,   22,     0, null, null, null    ),
new Item(439,   22,     0, null, null, null    ),
new Item(440,   22,     0, null, null, null    ),
new Item(441,   22,     0, null, null, null    ),
new Item(442,   18,     10000, null, null, null    ),
new Item(443,   21,     0, null, null, null    ),
new Item(444,   20,     0, null, null, null    ),
new Item(445,   20,     0, null, null, null    ),
new Item(446,   21,     0, null, null, null    ),
new Item(447,   21,     0, null, null, null    ),
new Item(448,   22,     0, null, null, null    ),
new Item(449,   39,     300, null, null, null    ),
new Item(450,   39,     300, null, null, null    ),
new Item(451,   39,     300, null, null, null    ),
new Item(452,   39,     300, null, null, null    ),
new Item(453,   39,     300, null, null, null    ),
new Item(454,   39,     300, null, null, null    ),
new Item(455,   39,     300, null, null, null    ),
new Item(456,   34,     0, null, null, null    ),
new Item(457,   34,     0, null, null, null    ),
new Item(458,   40,     0, null, null, null    ),
new Item(459,   40,     0, null, null, null    ),
new Item(460,   40,     0, null, null, null    ),
new Item(461,   40,     0, null, null, null    ),
new Item(462,   40,     0, null, null, null    ),
new Item(463,   40,     0, null, null, null    ),
new Item(464,   40,     0, null, null, null    ),
new Item(465,   21,     0, null, null, null    ),
new Item(466,   21,     0, null, null, null    ),
new Item(467,   22,     0, null, null, null    ),
new Item(468,   22,     0, null, null, null    ),
new Item(469,   22,     0, null, null, null    ),
new Item(470,   20,     0, null, null, null    ),
new Item(471,   21,     0, null, null, null    ),
new Item(472,   21,     0, null, null, null    ),
new Item(473,   23,     0, null, null, null    ),
new Item(474,   22,     0, null, null, null    ),
new Item(475,   22,     0, null, null, null    ),
new Item(476,   22,     0, null, null, null    ),
new Item(477,   22,     0, null, null, null    ),
new Item(478,   22,     0, null, null, null    ),
new Item(479,   22,     0, null, null, null    ),
new Item(480,   22,     0, null, null, null    ),
new Item(481,   22,     0, null, null, null    ),
new Item(482,   22,     0, null, null, null    ),
new Item(483,   22,     0, null, null, null    ),
new Item(484,   21,     0, null, null, null    ),
new Item(485,   22,     0, null, null, null    ),
new Item(486,   41,     0, null, null, null    ),
new Item(487,   41,     0, null, null, null    ),
new Item(488,   41,     0, null, null, null    ),
new Item(489,   41,     0, null, null, null    ),
new Item(490,   41,     0, null, null, null    ),
new Item(491,   41,     0, null, null, null    ),
new Item(492,   41,     0, null, null, null    ),
new Item(493,   41,     0, null, null, null    ),
new Item(494,   41,     0, null, null, null    ),
new Item(495,   41,     0, null, null, null    ),
new Item(496,   41,     0, null, null, null    ),
new Item(497,   41,     0, null, null, null    ),
new Item(498,   41,     0, null, null, null    ),
new Item(499,   41,     0, null, null, null    ),
new Item(500,   41,     0, null, null, null    ),
new Item(501,   41,     0, null, null, null    ),
new Item(502,   41,     0, null, null, null    ),
new Item(503,   41,     0, null, null, null    ),
new Item(504,   41,     0, null, null, null    ),
new Item(505,   41,     0, null, null, null    ),
new Item(506,   41,     0, null, null, null    ),
new Item(507,   41,     0, null, null, null    ),
new Item(508,   41,     0, null, null, null    ),
new Item(509,   41,     0, null, null, null    ),
new Item(510,   41,     0, null, null, null    ),
new Item(511,   41,     0, null, null, null    ),
new Item(512,   41,     0, null, null, null    ),
new Item(513,   23,     0, null, null, null    ),
new Item(514,   23,     0, null, null, null    ),
new Item(515,   25,     50, null, null, null    ),
new Item(516,   25,     50, null, null, null    ),
new Item(517,   25,     50, null, null, null    ),
new Item(518,   25,     50, null, null, null    ),
new Item(519,   25,     50, null, null, null    ),
new Item(520,   25,     50, null, null, null    ),
new Item(521,   25,     50, null, null, null    ),
new Item(522,   25,     50, null, null, null    ),
new Item(523,   25,     50, null, null, null    ),
new Item(524,   25,     50, null, null, null    ),
new Item(525,   25,     50, null, null, null    ),
new Item(526,   25,     0, null, null, null    ),
new Item(527,   21,     0, null, null, null    ),
new Item(528,   21,     0, null, null, null    ),
new Item(529,   21,     0, null, null, null    ),
new Item(530,   22,     0, null, null, null    ),
new Item(531,   21,     0, null, null, null    ),
new Item(532,   21,     0, null, null, null    ),
new Item(533,   22,     0, null, null, null    ),
new Item(534,   20,     0, null, null, null    ),
new Item(535,   22,     0, null, null, null    ),
new Item(536,   21,     0, null, null, null    ),
new Item(537,   22,     0, null, null, null    ),
new Item(538,   22,     0, null, null, null    ),
new Item(539,   22,     0, null, null, null    ),
new Item(540,   22,     0, null, null, null    ),
new Item(541,   22,     0, null, null, null    ),
new Item(542,   21,     0, null, null, null    ),
new Item(543,   22,     0, null, null, null    ),
new Item(544,   22,     0, null, null, null    ),
new Item(545,   22,     0, null, null, null    ),
new Item(546,   22,     0, null, null, null    ),
new Item(547,   22,     0, null, null, null    ),
new Item(548,   22,     0, null, null, null    ),
new Item(549,   21,     0, null, null, null    ),
new Item(550,   21,     0, null, null, null    ),
new Item(551,   21,     0, null, null, null    ),
new Item(552,   21,     0, null, null, null    ),
new Item(553,   22,     0, null, null, null    ),
new Item(554,   22,     0, null, null, null    ),
new Item(555,   22,     0, null, null, null    ),
new Item(556,   20,     0, null, null, null    ),
new Item(557,   20,     0, null, null, null    ),
new Item(558,   21,     0, null, null, null    ),
new Item(559,   22,     0, null, null, null    ),
new Item(560,   22,     0, null, null, null    ),
new Item(561,   22,     0, null, null, null    ),
new Item(562,   20,     0, null, null, null    ),
new Item(563,   18,     1000, 70, null, null    ),
new Item(564,   18,     1000, 70, null, null    ),
new Item(565,   18,     1000, 70, null, null    ),
new Item(566,   18,     1000, 70, null, null    ),
new Item(567,   27,     100, 30, null, null    ),
new Item(568,   25,     50, null, null, null    ),
new Item(569,   25,     50, null, null, null    ),
new Item(570,   25,     50, null, null, null    ),
new Item(571,   25,     50, null, null, null    ),
new Item(572,   25,     50, null, null, null    ),
new Item(573,   25,     50, null, null, null    ),
new Item(574,   25,     50, null, null, null    ),
new Item(575,   25,     50, null, null, null    ),
new Item(576,   25,     50, null, null, null    ),
new Item(577,   25,     50, null, null, null    ),
new Item(578,   25,     50, null, null, null    ),
new Item(579,   25,     50, null, null, null    ),
new Item(580,   10,     500, 30, null, null    ),
new Item(581,   12,     200, 40, null, null    ),
new Item(582,   12,     200, 30, null, null    ),
new Item(583,   12,     200, 60, null, null    ),
new Item(584,   12,     200, 10, null, null    ),
new Item(585,   12,     200, 10, null, null    ),
new Item(586,   12,     200, 10, null, null    ),
new Item(587,   12,     200, 30, null, null    ),
new Item(588,   12,     200, 30, null, null    ),
new Item(589,   12,     200, 30, null, null    ),
new Item(590,   12,     200, 30, null, null    ),
new Item(591,   42,     200, null, null, null    ),
new Item(592,   42,     200, null, null, null    ),
new Item(593,   42,     200, null, null, null    ),
new Item(594,   42,     200, null, null, null    ),
new Item(595,   42,     200, null, null, null    ),
new Item(596,   42,     200, null, null, null    ),
new Item(597,   42,     200, null, null, null    ),
new Item(598,   42,     200, null, null, null    ),
new Item(599,   42,     200, null, null, null    ),
new Item(600,   42,     200, null, null, null    ),
new Item(601,   42,     200, null, null, null    ),
new Item(602,   42,     200, null, null, null    ),
new Item(603,   42,     200, null, null, null    ),
new Item(604,   42,     200, null, null, null    ),
new Item(605,   42,     200, null, null, null    ),
new Item(606,   26,     3000, 20, null, null    ),
new Item(607,   26,     3000, 20, null, null    ),
new Item(608,   26,     3000, 20, null, null    ),
new Item(609,   26,     3000, 20, null, null    ),
new Item(610,   26,     3000, 20, null, null    ),
new Item(611,   26,     3000, 20, null, null    ),
new Item(612,   24,     200, 20, null, null    ),
new Item(613,   35,     1000, 100, null, null    ),
new Item(614,   35,     1000, 100, null, null    ),
new Item(615,   20,     0, null, null, null    ),
new Item(616,   12,     200, 30, null, null    ),
new Item(617,   33,     0, null, null, null    ),
new Item(618,   11,     1000, 30, null, null    ),
new Item(619,   21,     0, null, null, null    ),
new Item(620,   22,     0, null, null, null    ),
new Item(621,   24,     0, 30, null, null    ),
new Item(622,   24,     0, 30, null, null    ),
new Item(623,   24,     0, 30, null, null    ),
new Item(624,   24,     0, 30, null, null    ),
new Item(625,   24,     0, 30, null, null    ),
new Item(626,   24,     0, 30, null, null    ),
new Item(627,   24,     0, 30, null, null    ),
new Item(628,   24,     0, 30, null, null    ),
new Item(629,   24,     0, 30, null, null    ),
new Item(630,   24,     0, 30, null, null    ),
new Item(631,   24,     0, 30, null, null    ),
new Item(632,   30,     100, 30, null, null    ),
new Item(633,   43,     0, null, null, null    ),
new Item(634,   43,     0, null, null, null    ),
new Item(635,   43,     0, null, null, null    ),
new Item(636,   43,     0, null, null, null    ),
new Item(637,   43,     0, null, null, null    ),
new Item(638,   43,     0, null, null, null    ),
new Item(639,   43,     0, null, null, null    ),
new Item(640,   43,     0, null, null, null    ),
new Item(641,   43,     0, null, null, null    ),
new Item(642,   43,     0, null, null, null    ),
new Item(643,   43,     0, null, null, null    ),
new Item(644,   43,     0, null, null, null    ),
new Item(645,   43,     0, null, null, null    ),
new Item(646,   43,     0, null, null, null    ),
new Item(647,   43,     0, null, null, null    ),
new Item(648,   43,     0, null, null, null    ),
new Item(649,   43,     0, null, null, null    ),
new Item(650,   43,     0, null, null, null    ),
new Item(651,   43,     0, null, null, null    ),
new Item(652,   43,     0, null, null, null    ),
new Item(653,   43,     0, null, null, null    ),
new Item(654,   43,     0, null, null, null    ),
new Item(655,   43,     0, null, null, null    ),
new Item(656,   43,     0, null, null, null    ),
new Item(657,   22,     0, null, null, null    ),
new Item(658,   22,     0, null, null, null    ),
new Item(659,   37,     10000, null, null, null    ),
new Item(660,   37,     10000, null, null, null    ),
new Item(661,   37,     10000, null, null, null    ),
new Item(662,   21,     0, null, null, null    ),
new Item(663,   23,     0, null, null, null    ),
new Item(664,   22,     0, null, null, null    ),
new Item(665,   22,     0, null, null, null    ),
new Item(666,   22,     0, null, null, null    ),
new Item(668,   42,     200, null, null, null    ),
new Item(669,   42,     200, null, null, null    ),
new Item(670,   21,     0, null, null, null    ),
new Item(671,   21,     0, null, null, null    ),
new Item(673,   21,     0, null, null, null    ),
new Item(674,   21,     0, null, null, null    ),
new Item(675,   21,     0, null, null, null    ),
new Item(676,   22,     0, null, null, null    ),
new Item(677,   22,     0, null, null, null    ),
new Item(678,   22,     0, null, null, null    ),
new Item(679,   22,     0, null, null, null    ),
new Item(681,   21,     0, null, null, null    ),
new Item(682,   12,     0, null, null, null    ),
new Item(683,   12,     0, null, null, null    ),
new Item(684,   17,     0, null, null, null    ),
new Item(685,   26,     0, null, null, null    ),
new Item(686,   10,     0, null, null, null    ),
new Item(687,   10,     0, null, null, null    ),
new Item(688,   12,     0, null, null, null    ),
new Item(689,   12,     0, null, null, null    ),
new Item(690,   12,     0, null, null, null    ),
new Item(691,   32,     0, null, null, null    ),
new Item(692,   32,     0, null, null, null    ),
new Item(693,   32,     0, null, null, null    ),
new Item(694,   32,     0, null, null, null    ),
new Item(695,   44,     0, null, null, null    ),
new Item(696,   44,     0, null, null, null    ),
new Item(697,   44,     0, null, null, null    ),
new Item(698,   44,     0, null, null, null    ),
new Item(699,   44,     0, null, null, null    ),
new Item(700,   44,     0, null, null, null    ),
new Item(701,   44,     0, null, null, null    ),
new Item(702,   44,     0, null, null, null    ),
new Item(703,   44,     0, null, null, null    ),
new Item(704,   44,     0, null, null, null    ),
new Item(705,   44,     0, null, null, null    ),
new Item(706,   44,     0, null, null, null    ),
new Item(707,   44,     0, null, null, null    ),
new Item(708,   44,     0, null, null, null    ),
new Item(709,   44,     0, null, null, null    ),
new Item(710,   44,     0, null, null, null    ),
new Item(711,   44,     0, null, null, null    ),
new Item(712,   44,     0, null, null, null    ),
new Item(713,   44,     0, null, null, null    ),
new Item(714,   44,     0, null, null, null    ),
new Item(715,   44,     0, null, null, null    ),
new Item(716,   44,     0, null, null, null    ),
new Item(717,   44,     0, null, null, null    ),
new Item(718,   44,     0, null, null, null    ),
new Item(719,   44,     0, null, null, null    ),
new Item(720,   44,     0, null, null, null    ),
new Item(721,   44,     0, null, null, null    ),
new Item(722,   44,     0, null, null, null    ),
new Item(723,   7,      0, null, null, null    ),
new Item(724,   4,      0, null, null, null    ),
new Item(725,   4,      0, null, null, null    ),
new Item(726,   10001,  0, null, null, null    ),
new Item(727,   10001,  0, null, null, null    ),
new Item(728,   30,     0, null, null, null    ),
new Item(729,   35,     0, null, null, null    ),
new Item(730,   35,     0, null, null, null    ),
new Item(731,   42,     0, null, null, null    ),
new Item(732,   21,     0, null, null, null    ),
new Item(733,   22,     0, null, null, null    ),
new Item(734,   21,     0, null, null, null    ),
new Item(735,   22,     0, null, null, null    ),
new Item(736,   22,     0, null, null, null    ),
new Item(737,   21,     0, null, null, null    ),
new Item(738,   22,     0, null, null, null    ),
new Item(739,   21,     0, null, null, null    ),
new Item(740,   22,     0, null, null, null    ),
new Item(741,   22,     0, null, null, null    ),
new Item(742,   21,     0, null, null, null    ),
new Item(743,   21,     0, null, null, null    ),
new Item(744,   21,     0, null, null, null    ),
new Item(745,   37,     0, null, null, null    ),
new Item(746,   37,     0, null, null, null    ),
new Item(747,   37,     0, null, null, null    ),
new Item(748,   37,     0, null, null, null    ),
new Item(749,   37,     0, null, null, null    )
};
    #endregion
    
}

namespace PokemonUnity.Item
{
    /// <summary>
    /// Item ids are connected to XML file. 
    /// </summary>
    /// <remarks>
    /// Running off of genVI. 
    /// Be sure to overwrite both if modifying.
    /// Replace "[HP]{mechanic:hp}" in summary-tags with
    /// "<see cref="Pokemon.HP"/>" or "<see cref="Pokemon.TotalHP"/>"
    /// </remarks>
    public enum Items
    {
		NONE = 0,
        /// <summary>Used in battle :   [Catches]{mechanic:catch} a wild Pokémon without fail.      If used in a trainer battle, nothing happens and the ball is lost.</summary>
        /// <summary>Used in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon, using a catch rate of 2×.      If used in a trainer battle, nothing happens and the ball is lost.</summary>
        /// <summary>Used in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon, using a catch rate of 1.5×.      If used in a trainer battle, nothing happens and the ball is lost.</summary>
        /// <summary>Used in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon, using a catch rate of 1×.      If used in a trainer battle, nothing happens and the ball is lost.</summary>
        /// <summary>Used in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon, using a catch rate of 1.5×.  This item can only be used in the []{location:great-marsh} or []{location:kanto-safari-zone}.</summary>
        /// <summary>Used in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon.  If the wild Pokémon is []{type:water}- or []{type:bug}-type, this ball has a catch rate of 3×.  Otherwise, it has a catch rate of 1×.      If used in a trainer battle, nothing happens and the ball is lost.</summary>
        /// <summary>Used in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon.  If the wild Pokémon was encountered by surfing or fishing, this ball has a catch rate of 3.5×.  Otherwise, it has a catch rate of 1×.      If used in a trainer battle, nothing happens and the ball is lost.</summary>
        /// <summary>Used in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon.  Has a catch rate of given by `(40 - level) / 10`, where `level` is the wild Pokémon's level, to a maximum of 3.9× for level 1 Pokémon.  If the wild Pokémon's level is higher than 30, this ball has a catch rate of 1×.      If used in a trainer battle, nothing happens and the ball is lost.</summary>
        /// <summary>Used in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon.  If the wild Pokémon's species is marked as caught in the trainer's Pokédex, this ball has a catch rate of 3×.  Otherwise, it has a catch rate of 1×.      If used in a trainer battle, nothing happens and the ball is lost.</summary>
        /// <summary>Used in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon.  Has a catch rate of 1.1× on the first turn of the battle and increases by 0.1× every turn, to a maximum of 4× on turn 30.      If used in a trainer battle, nothing happens and the ball is lost.</summary>
        /// <summary>Used in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon, using a catch rate of 1×.  Whenever the caught Pokémon's [happiness]{mechanic:happiness} increases, it increases by one extra point.      If used in a trainer battle, nothing happens and the ball is lost.</summary>
        /// <summary>Used in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon, using a catch rate of 1×.      If used in a trainer battle, nothing happens and the ball is lost.</summary>
        /// <summary>Used in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon.  If it's currently nighttime or the wild Pokémon was encountered while walking in a cave, this ball has a catch rate of 3.5×.  Otherwise, it has a catch rate of 1×.      If used in a trainer battle, nothing happens and the ball is lost.</summary>
        /// <summary>Used in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon, using a catch rate of 1×.  The caught Pokémon's [HP]{mechanic:hp} is immediately restored, [PP]{mechanic:pp} for all its moves is restored, and any [status ailment]{mechanic:status-ailment} is cured.      If used in a trainer battle, nothing happens and the ball is lost.</summary>
        /// <summary>Used in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon, using a catch rate of 4× on the first turn of a battle, but 1× any other time.      If used in a trainer battle, nothing happens and the ball is lost.</summary>
        /// <summary>Used in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon, using a catch rate of 1×.      If used in a trainer battle, nothing happens and the ball is lost.</summary>
        /// <summary>Used on a friendly Pokémon :   Restores 20 [HP]{mechanic:hp}.</summary>
        /// <summary>Used on a party Pokémon :   Cures [poison]{mechanic:poison}.</summary>
        /// <summary>Used on a party Pokémon :   Cures a [burn]{mechanic:burn}.</summary>
        /// <summary>Used on a party Pokémon :   Cures [freezing]{mechanic:freezing}.</summary>
        /// <summary>Used on a party Pokémon :   Cures [sleep]{mechanic:sleep}.</summary>
        /// <summary>Used on a party Pokémon :   Cures [paralysis]{mechanic:paralysis}.</summary>
        /// <summary>Used on a party Pokémon :   Restores [HP]{mechanic:hp} to full and cures any [status ailment]{mechanic:status-ailment} and [confusion]{mechanic:confusion}.</summary>
        /// <summary>Used on a party Pokémon :   Restores [HP]{mechanic:hp} to full.</summary>
        /// <summary>Used on a party Pokémon :   Restores 200 [HP]{mechanic:hp}.</summary>
        /// <summary>Used on a party Pokémon :   Restores 50 [HP]{mechanic:hp}.</summary>
        /// <summary>Used on a party Pokémon :   Cures any [status ailment]{mechanic:status-ailment} and [confusion]{mechanic:confusion}.</summary>
        /// <summary>Used on a party Pokémon :   Revives the Pokémon and restores half its [HP]{mechanic:hp}.</summary>
        /// <summary>Used on a party Pokémon :   Revives the Pokémon and restores its [HP]{mechanic:hp} to full.</summary>
        /// <summary>Used on a party Pokémon :   Restores 50 [HP]{mechanic:hp}.</summary>
        /// <summary>Used on a party Pokémon :   Restores 60 [HP]{mechanic:hp}.</summary>
        /// <summary>Used on a party Pokémon :   Restores 80 [HP]{mechanic:hp}.</summary>
        /// <summary>Used on a party Pokémon :   Restores 100 [HP]{mechanic:hp}.</summary>
        /// <summary>Used on a party Pokémon :   Restores 50 [HP]{mechanic:hp}.  Decreases [happiness]{mechanic:happiness} by 5/5/10.</summary>
        /// <summary>Used on a party Pokémon :   Restores 200 [HP]{mechanic:hp}.  Decreases [happiness]{mechanic:happiness} by 10/10/15.</summary>
        /// <summary>Used on a party Pokémon :   Cures any [status ailment]{mechanic:status-ailment}.  Decreases [happiness]{mechanic:happiness} by 5/5/10.</summary>
        /// <summary>Used on a party Pokémon :   Revives a [fainted]{mechanic:faint} Pokémon and restores its [HP]{mechanic:hp} to full.  Decreases [happiness]{mechanic:happiness} by 10/10/15.</summary>
        /// <summary>Used on a party Pokémon :   Restores 10 [PP]{mechanic:pp} for a selected move.</summary>
        /// <summary>Used on a party Pokémon :   Restores [PP]{mechanic:pp} to full for a selected move.</summary>
        /// <summary>Used on a party Pokémon :   Restores 10 [PP]{mechanic:pp} for each move.</summary>
        /// <summary>Used on a party Pokémon :   Restores [PP]{mechanic:pp} to full for each move.</summary>
        /// <summary>Used on a party Pokémon :   Cures any [status ailment]{mechanic:status-ailment} and [confusion]{mechanic:confusion}.</summary>
        /// <summary>Used on a party Pokémon :   Restores 20 [HP]{mechanic:hp}.</summary>
        /// <summary>Used :   Revives all [fainted]{mechanic:faint} Pokémon in the party and restores their [HP]{mechanic:hp} to full.</summary>
        /// <summary>Used on a party Pokémon :   Increases [HP]{mechanic:hp} [effort]{mechanic:effort} by 10, but won't increase it beyond 100.  Increases [happiness]{mechanic:happiness} by 5/3/2.</summary>
        /// <summary>Used on a party Pokémon :   Increases [Attack]{mechanic:attack} [effort]{mechanic:effort} by 10, but won't increase it beyond 100.  Increases [happiness]{mechanic:happiness} by 5/3/2.</summary>
        /// <summary>Used on a party Pokémon :   Increases [Defense]{mechanic:defense} [effort]{mechanic:effort} by 10, but won't increase it beyond 100.  Increases [happiness]{mechanic:happiness} by 5/3/2.</summary>
        /// <summary>Used on a party Pokémon :   Increases [Speed]{mechanic:speed} [effort]{mechanic:effort} by 10, but won't increase it beyond 100.  Increases [happiness]{mechanic:happiness} by 5/3/2.</summary>
        /// <summary>Used on a party Pokémon :   Increases [Special Attack]{mechanic:special-attack} [effort]{mechanic:effort} by 10, but won't increase it beyond 100.  Increases [happiness]{mechanic:happiness} by 5/3/2.</summary>
        /// <summary>Used on a party Pokémon :   Increases level by 1.  Increases [happiness]{mechanic:happiness} by 5/3/2.</summary>
        /// <summary>Used on a party Pokémon :   Increases a selected move's max [PP]{mechanic:pp} by 20% its original max PP, to a maximum of 1.6×.  Increases [happiness]{mechanic:happiness} by 5/3/2.</summary>
        /// <summary>Used on a party Pokémon :   Increases [Special Defense]{mechanic:special-defense} [effort]{mechanic:effort} by 10, but won't increase it beyond 100.  Increases [happiness]{mechanic:happiness} by 5/3/2.</summary>
        /// <summary>Used on a party Pokémon :   Increases a selected move's max [PP]{mechanic:pp} to 1.6× its original max PP.  Increases [happiness]{mechanic:happiness} by 5/3/2.</summary>
        /// <summary>Used on a party Pokémon :   Cures any [status ailment]{mechanic:status-ailment} and [confusion]{mechanic:confusion}.</summary>
        /// <summary>Used on a party Pokémon in battle :   Protects the target's stats from being [lowered]{mechanic:lower} for the next five turns.  Increases happiness by 1/1/0.</summary>
        /// <summary>Used on a party Pokémon in battle :   Increases the target's [critical hit chance]{mechanic:critical-hit-chance} by one stage until it leaves the field.  Increases happiness by 1/1/0.</summary>
        /// <summary>Used on a party Pokémon in battle :   [Raises]{mechanic:raise} the target's [Attack]{mechanic:attack} by one stage.  Increases happiness by 1/1/0.</summary>
        /// <summary>Used on a party Pokémon in battle :   [Raises]{mechanic:raise} the target's [Defense]{mechanic:defense} by one stage.  Increases happiness by 1/1/0.</summary>
        /// <summary>Used on a party Pokémon in battle :   [Raises]{mechanic:raise} the target's [Speed]{mechanic:speed} by one stage.  Increases happiness by 1/1/0.</summary>
        /// <summary>Used on a party Pokémon in battle :   [Raises]{mechanic:raise} the target's [accuracy]{mechanic:accuracy} by one stage.  Increases happiness by 1/1/0.</summary>
        /// <summary>Used on a party Pokémon in battle :   [Raises]{mechanic:raise} the target's [Special Attack]{mechanic:special-attack} by one stage.  Increases happiness by 1/1/0.</summary>
        /// <summary>Used on a party Pokémon in battle :   [Raises]{mechanic:raise} the target's [Special Defense]{mechanic:special-defense} by one stage.  Increases happiness by 1/1/0.</summary>
        /// <summary>Used in battle :   Ends a wild battle.  Cannot be used in trainer battles.</summary>
        /// <summary>Used in battle :   Ends a wild battle.  Cannot be used in trainer battles.</summary>
        /// <summary>Used on a party Pokémon :   Cures [sleep]{mechanic:sleep}.</summary>
        /// <summary>Used on a party Pokémon in battle :   Cures [confusion]{mechanic:confusion}.</summary>
        /// <summary>Used on a party Pokémon in battle :   Cures [attraction]{mechanic:attraction}.</summary>
        /// <summary>Used outside of battle :   Decreases the wild Pokémon encounter rate by 50%.</summary>
        /// <summary>Used outside of battle :   Doubles the wild Pokémon encounter rate.</summary>
        /// <summary>No effect.</summary>
        /// <summary>No effect.</summary>
        /// <summary>No effect.  In Diamond and Pearl, trade ten for a []{move:sunny-day} [TM]{item:tm11} in the house midway along the southern section of []{location:sinnoh-route-212}.  In Platinum, trade to [move tutors]{mechanic:move-tutor} on []{location:sinnoh-route-212}, in []{location:snowpoint-city}, and in the []{location:survival-area}.  Eight shards total are required per tutelage, but the particular combination of colors varies by move.  In HeartGold and SoulSilver, trade one for a []{item:cheri-berry}, a []{item:leppa-berry}, and a []{item:pecha-berry} with the Juggler near the Pokémon Center in []{location:violet-city}.  In HeartGold and SoulSilver, trade one for a []{item:persim-berry}, a []{item:pomeg-berry}, and a []{item:razz-berry} with the Juggler near the []{location:pal-park} entrance in []{location:fuchsia-city}.</summary>
        /// <summary>No effect.  In Diamond and Pearl, trade ten for a []{move:rain-dance} [TM]{item:tm18} in the house midway along the southern section of []{location:sinnoh-route-212}.  In Platinum, trade to [move tutors]{mechanic:move-tutor} on []{location:sinnoh-route-212}, in []{location:snowpoint-city}, and in the []{location:survival-area}.  Eight shards total are required per tutelage, but the particular combination of colors varies by move.  In HeartGold and SoulSilver, trade one for a []{item:chesto-berry}, an []{item:oran-berry}, and a []{item:wiki-berry} with the Juggler near the Pokémon Center in []{location:violet-city}.  In HeartGold and SoulSilver, trade one for a []{item:bluk-berry}, a []{item:cornn-berry}, and a []{item:kelpsy-berry} with the Juggler near the []{location:pal-park} entrance in []{location:fuchsia-city}.</summary>
        /// <summary>No effect.  In Diamond and Pearl, trade ten for a []{move:sandstorm} [TM]{item:tm37} in the house midway along the southern section of []{location:sinnoh-route-212}.  In Platinum, trade to [move tutors]{mechanic:move-tutor} on []{location:sinnoh-route-212}, in []{location:snowpoint-city}, and in the []{location:survival-area}.  Eight shards total are required per tutelage, but the particular combination of colors varies by move.  In HeartGold and SoulSilver, trade one for an []{item:aspear-berry}, a []{item:iapapa-berry}, and a []{item:sitrus-berry} with the Juggler near the Pokémon Center in []{location:violet-city}.  In HeartGold and SoulSilver, trade one for a []{item:grepa-berry}, a []{item:nomel-berry}, and a []{item:pinap-berry} with the Juggler near the []{location:pal-park} entrance in []{location:fuchsia-city}.</summary>
        /// <summary>No effect.  In Diamond and Pearl, trade ten for a []{move:hail} [TM]{item:tm07} in the house midway along the southern section of []{location:sinnoh-route-212}.  In Platinum, trade to [move tutors]{mechanic:move-tutor} on []{location:sinnoh-route-212}, in []{location:snowpoint-city}, and in the []{location:survival-area}.  Eight shards total are required per tutelage, but the particular combination of colors varies by move.  In HeartGold and SoulSilver, trade one for an []{item:aguav-berry}, a []{item:lum-berry}, and a []{item:rawst-berry} with the Juggler near the Pokémon Center in []{location:violet-city}.  In HeartGold and SoulSilver, trade one for a []{item:durin-berry}, a []{item:hondew-berry}, and a []{item:wepear-berry} with the Juggler near the []{location:pal-park} entrance in []{location:fuchsia-city}.</summary>
        /// <summary>Used outside of battle :   Trainer will skip encounters with wild Pokémon of a lower level than the lead party Pokémon.  This effect wears off after the trainer takes 200 steps.</summary>
        /// <summary>Used outside of battle :   Trainer will skip encounters with wild Pokémon of a lower level than the lead party Pokémon.  This effect wears off after the trainer takes 250 steps.</summary>
        /// <summary>Used outside of battle :   Transports the trainer to the last-entered dungeon entrance.  Cannot be used outside, in buildings, or in []{location:distortion-world}, []{location:sinnoh-hall-of-origin-1}, []{location:spear-pillar}, or []{location:turnback-cave}.</summary>
        /// <summary>Used outside of battle :   Trainer will skip encounters with wild Pokémon of a lower level than the lead party Pokémon.  This effect wears off after the trainer takes 100 steps.</summary>
        /// <summary>Used on a party Pokémon :   Evolves a []{pokemon:cottonee} into []{pokemon:whimsicott}, a []{pokemon:gloom} into []{pokemon:bellossom}, a []{pokemon:petilil} into []{pokemon:lilligant}, or a []{pokemon:sunkern} into []{pokemon:sunflora}.</summary>
        /// <summary>Used on a party Pokémon :   Evolves a []{pokemon:clefairy} into []{pokemon:clefable}, a []{pokemon:jigglypuff} into []{pokemon:wigglytuff}, a []{pokemon:munna} into []{pokemon:musharna}, a []{pokemon:nidorina} into []{pokemon:nidoqueen}, a []{pokemon:nidorino} into []{pokemon:nidoking}, or a []{pokemon:skitty} into []{pokemon:delcatty}.</summary>
        /// <summary>Used on a party Pokémon :   Evolves an []{pokemon:eevee} into []{pokemon:flareon}, a []{pokemon:growlithe} into []{pokemon:arcanine}, a []{pokemon:pansear} into []{pokemon:simisear}, or a []{pokemon:vulpix} into []{pokemon:ninetales}.</summary>
        /// <summary>Used on a party Pokémon :   Evolves an []{pokemon:eelektrik} into []{pokemon:eelektross}, an []{pokemon:eevee} into []{pokemon:jolteon}, or a []{pokemon:pikachu} into []{pokemon:raichu}.</summary>
        /// <summary>Used on a party Pokémon :   Evolves an []{pokemon:eevee} into []{pokemon:vaporeon}, a []{pokemon:lombre} into []{pokemon:ludicolo}, a []{pokemon:panpour} into []{pokemon:simipour}, a []{pokemon:poliwhirl} into []{pokemon:poliwrath}, a []{pokemon:shellder} into []{pokemon:cloyster}, or a []{pokemon:staryu} into []{pokemon:starmie}.</summary>
        /// <summary>Used on a party Pokémon :   Evolves an []{pokemon:exeggcute} into []{pokemon:exeggutor}, a []{pokemon:gloom} into []{pokemon:vileplume}, a []{pokemon:nuzleaf} into []{pokemon:shiftry}, a []{pokemon:pansage} into []{pokemon:simisage}, or a []{pokemon:weepinbell} into []{pokemon:victreebel}.</summary>
        /// <summary>Vendor trash.</summary>
        /// <summary>Vendor trash.</summary>
        /// <summary>Vendor trash.</summary>
        /// <summary>Vendor trash.</summary>
        /// <summary>Vendor trash.</summary>
        /// <summary>Vendor trash.</summary>
        /// <summary>Vendor trash.</summary>
        /// <summary>Trade one to the Move Relearner near the shore in []{location:pastoria-city} or with the Move Deleter in []{location:blackthorn-city} to teach one party Pokémon a prior level-up move.</summary>
        /// <summary>Used outside of battle :   Immediately triggers a wild Pokémon battle, as long as the trainer is somewhere with wild Pokémon—i.e., in tall grass, in a cave, or surfing.  Can be smeared on sweet-smelling trees to attract tree-dwelling Pokémon after six hours.</summary>
        /// <summary>Used on a patch of soil :   Plant's growth stages will each last 25% less time.  Dries soil out more quickly.</summary>
        /// <summary>Used on a patch of soil :   Plant's growth stages will each last 25% more time.  Dries soil out more slowly.</summary>
        /// <summary>Used on a patch of soil :   Fully-grown plant will last 25% longer before dying and possibly regrowing.</summary>
        /// <summary>Used on a path of soil :   Plant will regrow after dying 25% more times.</summary>
        /// <summary>Give to a scientist in the []{location:mining-museum} in []{location:oreburgh-city} or the Museum of Science in []{location:pewter-city} to receive a []{pokemon:lileep}.</summary>
        /// <summary>Give to a scientist in the []{location:mining-museum} in []{location:oreburgh-city} or the Museum of Science in []{location:pewter-city} to receive a []{pokemon:anorith}.</summary>
        /// <summary>Give to a scientist in the []{location:mining-museum} in []{location:oreburgh-city} or the Museum of Science in []{location:pewter-city} to receive a []{pokemon:omanyte}.</summary>
        /// <summary>Give to a scientist in the []{location:mining-museum} in []{location:oreburgh-city} or the Museum of Science in []{location:pewter-city} to receive a []{pokemon:kabuto}.</summary>
        /// <summary>Give to a scientist in the []{location:mining-museum} in []{location:oreburgh-city} or the Museum of Science in []{location:pewter-city} to receive a []{pokemon:aerodactyl}.</summary>
        /// <summary>Give to a scientist in the []{location:mining-museum} in []{location:oreburgh-city} or the Museum of Science in []{location:pewter-city} to receive a []{pokemon:shieldon}.</summary>
        /// <summary>Give to a scientist in the []{location:mining-museum} in []{location:oreburgh-city} or the Museum of Science in []{location:pewter-city} to receive a []{pokemon:cranidos}.</summary>
        /// <summary>Vendor trash.</summary>
        /// <summary>Used on a party Pokémon :   Evolves a []{pokemon:minccino} into []{pokemon:cinccino}, a []{pokemon:roselia} into []{pokemon:roserade}, or a []{pokemon:togetic} into []{pokemon:togekiss}.</summary>
        /// <summary>Used on a party Pokémon :   Evolves a []{pokemon:lampent} into []{pokemon:chandelure}, a []{pokemon:misdreavus} into []{pokemon:mismagius}, or a []{pokemon:murkrow} into []{pokemon:honchkrow}.</summary>
        /// <summary>Used on a party Pokémon :   Evolves a male []{pokemon:kirlia} into []{pokemon:gallade} or a female []{pokemon:snorunt} into []{pokemon:froslass}.</summary>
        /// <summary>Held by []{pokemon:happiny} :   Holder evolves into []{pokemon:chansey} when it levels up during the daytime.</summary>
        /// <summary>Place in the tower on []{location:sinnoh-route-209}.  Check the stone to encounter a []{pokemon:spiritomb}, as long as the trainer's Underground status card counts at least 32 greetings.</summary>
        /// <summary>Held by []{pokemon:dialga} :   Holder's []{type:dragon}- and []{type:steel}-type moves have 1.2× their usual power.</summary>
        /// <summary>Held by []{pokemon:palkia} :   Holder's []{type:dragon}- and []{type:water}-type moves have 1.2× their usual power.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Held in battle :   When the holder is [paralyzed]{mechanic:paralysis}, it consumes this item to cure the paralysis.  Used on a party Pokémon :   Cures [paralysis]{mechanic:paralysis}.</summary>
        /// <summary>Held in battle :   When the holder is [asleep]{mechanic:sleep}, it consumes this item to wake up.  Used on a party Pokémon :   Cures [sleep]{mechanic:sleep}.</summary>
        /// <summary>Held in battle :   When the holder is [poisoned]{mechanic:poison}, it consumes this item to cure the poison.  Used on a party Pokémon :   Cures [poison]{mechanic:poison}.</summary>
        /// <summary>Held in battle :   When the holder is [burned]{mechanic:burn}, it consumes this item to cure the burn.  Used on a party Pokémon :   Cures a [burn]{mechanic:burn}.</summary>
        /// <summary>Held in battle :   When the holder is [frozen]{mechanic:freezing}, it consumes this item to thaw itself.  Used on a party Pokémon :   Cures [freezing]{mechanic:freezing}.</summary>
        /// <summary>Held in battle :   When the holder is out of [PP]{mechanic:pp} for one of its moves, it consumes this item to restore 10 of that move's PP.  Used on a party Pokémon :   Restores 10 [PP]{mechanic:pp} for a selected move.</summary>
        /// <summary>Held in battle :   When the holder has 1/2 its max [HP]{mechanic:hp} remaining or less, it consumes this item to restore 10 HP.  Used on a party Pokémon :   Restores 10 [HP]{mechanic:hp}.</summary>
        /// <summary>Held in battle :   When the holder is [confused]{mechanic:confusion}, it consumes this item to cure the confusion.  Used on a party Pokémon :   Cures [confusion]{mechanic:confusion}.</summary>
        /// <summary>Held in battle :   When the holder is afflicted with a [major status ailment]{mechanic:major-status-ailment}, it consumes this item to cure the ailment.  Used on a party Pokémon :   Cures any [major status ailment]{mechanic:major-status-ailment}.</summary>
        /// <summary>Held in battle :   When the holder has 1/2 its max [HP]{mechanic:hp} remaining or less, it consumes this item to restore 1/4 its max HP.  Used on a party Pokémon :   Restores 1/4 the Pokémon's max [HP]{mechanic:hp}.</summary>
        /// <summary>Held in battle :   When the holder has 1/2 its max [HP]{mechanic:hp} remaining or less, it consumes this item to restore 1/8 its max HP.  If the holder dislikes spicy flavors (i.e., has a nature that lowers [Attack]{mechanic:attack}), it will also become [confused]{mechanic:confusion}.</summary>
        /// <summary>Held in battle :   When the holder has 1/2 its max [HP]{mechanic:hp} remaining or less, it consumes this item to restore 1/8 its max HP.  If the holder dislikes dry flavors (i.e., has a nature that lowers [Special Attack]{mechanic:special-attack}), it will also become [confused]{mechanic:confusion}.</summary>
        /// <summary>Held in battle :   When the holder has 1/2 its max [HP]{mechanic:hp} remaining or less, it consumes this item to restore 1/8 its max HP.  If the holder dislikes sweet flavors (i.e., has a nature that lowers [Speed]{mechanic:speed}), it will also become [confused]{mechanic:confusion}.</summary>
        /// <summary>Held in battle :   When the holder has 1/2 its max [HP]{mechanic:hp} remaining or less, it consumes this item to restore 1/8 its max HP.  If the holder dislikes bitter flavors (i.e., has a nature that lowers [Special Defense]{mechanic:special-defense}), it will also become [confused]{mechanic:confusion}.</summary>
        /// <summary>Held in battle :   When the holder has 1/2 its max [HP]{mechanic:hp} remaining or less, it consumes this item to restore 1/8 its max HP.  If the holder dislikes sour flavors (i.e., has a nature that lowers [Defense]{mechanic:defense}), it will also become [confused]{mechanic:confusion}.</summary>
        /// <summary>No effect; only useful for planting and cooking.</summary>
        /// <summary>No effect; only useful for planting and cooking.</summary>
        /// <summary>No effect; only useful for planting and cooking.</summary>
        /// <summary>No effect; only useful for planting and cooking.</summary>
        /// <summary>No effect; only useful for planting and cooking.</summary>
        /// <summary>Used on a party Pokémon :   Increases [happiness]{mechanic:happiness} by 10/5/2.  Lowers [HP]{mechanic:hp} [effort]{mechanic:effort} by 10.</summary>
        /// <summary>Used on a party Pokémon :   Increases [happiness]{mechanic:happiness} by 10/5/2.  Lowers [Attack]{mechanic:attack} [effort]{mechanic:effort} by 10.</summary>
        /// <summary>Used on a party Pokémon :   Increases [happiness]{mechanic:happiness} by 10/5/2.  Lowers [Defense]{mechanic:defense} [effort]{mechanic:effort} by 10.</summary>
        /// <summary>Used on a party Pokémon :   Increases [happiness]{mechanic:happiness} by 10/5/2.  Lowers [Special Attack]{mechanic:special-attack} [effort]{mechanic:effort} by 10.</summary>
        /// <summary>Used on a party Pokémon :   Increases [happiness]{mechanic:happiness} by 10/5/2.  Lowers [Special Defense]{mechanic:special-defense} [effort]{mechanic:effort} by 10.</summary>
        /// <summary>Used on a party Pokémon :   Increases [happiness]{mechanic:happiness} by 10/5/2.  Lowers [Speed]{mechanic:speed} [effort]{mechanic:effort} by 10.</summary>
        /// <summary>No effect; only useful for planting and cooking.</summary>
        /// <summary>No effect; only useful for planting and cooking.</summary>
        /// <summary>No effect; only useful for planting and cooking.</summary>
        /// <summary>No effect; only useful for planting and cooking.</summary>
        /// <summary>No effect; only useful for planting and cooking.</summary>
        /// <summary>No effect; only useful for planting and cooking.</summary>
        /// <summary>No effect; only useful for planting and cooking.</summary>
        /// <summary>No effect; only useful for planting and cooking.</summary>
        /// <summary>No effect; only useful for planting and cooking.</summary>
        /// <summary>Held in battle :   When the holder would take [super-effective]{mechanic:super-effective} []{type:fire}-type damage, it consumes this item to halve the amount of damage taken.</summary>
        /// <summary>Held in battle :   When the holder would take [super-effective]{mechanic:super-effective} []{type:water}-type damage, it consumes this item to halve the amount of damage taken.</summary>
        /// <summary>Held in battle :   When the holder would take [super-effective]{mechanic:super-effective} []{type:electric}-type damage, it consumes this item to halve the amount of damage taken.</summary>
        /// <summary>Held in battle :   When the holder would take [super-effective]{mechanic:super-effective} []{type:grass}-type damage, it consumes this item to halve the amount of damage taken.</summary>
        /// <summary>Held in battle :   When the holder would take [super-effective]{mechanic:super-effective} []{type:ice}-type damage, it consumes this item to halve the amount of damage taken.</summary>
        /// <summary>Held in battle :   When the holder would take [super-effective]{mechanic:super-effective} []{type:fighting}-type damage, it consumes this item to halve the amount of damage taken.</summary>
        /// <summary>Held in battle :   When the holder would take [super-effective]{mechanic:super-effective} []{type:poison}-type damage, it consumes this item to halve the amount of damage taken.</summary>
        /// <summary>Held in battle :   When the holder would take [super-effective]{mechanic:super-effective} []{type:ground}-type damage, it consumes this item to halve the amount of damage taken.</summary>
        /// <summary>Held in battle :   When the holder would take [super-effective]{mechanic:super-effective} []{type:flying}-type damage, it consumes this item to halve the amount of damage taken.</summary>
        /// <summary>Held in battle :   When the holder would take [super-effective]{mechanic:super-effective} []{type:psychic}-type damage, it consumes this item to halve the amount of damage taken.</summary>
        /// <summary>Held in battle :   When the holder would take [super-effective]{mechanic:super-effective} []{type:bug}-type damage, it consumes this item to halve the amount of damage taken.</summary>
        /// <summary>Held in battle :   When the holder would take [super-effective]{mechanic:super-effective} []{type:rock}-type damage, it consumes this item to halve the amount of damage taken.</summary>
        /// <summary>Held in battle :   When the holder would take [super-effective]{mechanic:super-effective} []{type:ghost}-type damage, it consumes this item to halve the amount of damage taken.</summary>
        /// <summary>Held in battle :   When the holder would take [super-effective]{mechanic:super-effective} []{type:dragon}-type damage, it consumes this item to halve the amount of damage taken.</summary>
        /// <summary>Held in battle :   When the holder would take [super-effective]{mechanic:super-effective} []{type:dark}-type damage, it consumes this item to halve the amount of damage taken.</summary>
        /// <summary>Held in battle :   When the holder would take [super-effective]{mechanic:super-effective} []{type:steel}-type damage, it consumes this item to halve the amount of damage taken.</summary>
        /// <summary>Held in battle :   When the holder would take []{type:normal}-type damage, it consumes this item to halve the amount of damage taken.</summary>
        /// <summary>Held in battle :   When the holder has 1/4 its max [HP]{mechanic:hp} remaining or less, it consumes this item to [raise]{mechanic:raise} its [Attack]{mechanic:attack} by one stage.</summary>
        /// <summary>Held in battle :   When the holder has 1/4 its max [HP]{mechanic:hp} remaining or less, it consumes this item to [raise]{mechanic:raise} its [Defense]{mechanic:defense} by one stage.</summary>
        /// <summary>Held in battle :   When the holder has 1/4 its max [HP]{mechanic:hp} remaining or less, it consumes this item to [raise]{mechanic:raise} its [Speed]{mechanic:speed} by one stage.</summary>
        /// <summary>Held in battle :   When the holder has 1/4 its max [HP]{mechanic:hp} remaining or less, it consumes this item to [raise]{mechanic:raise} its [Special Attack]{mechanic:special-attack} by one stage.</summary>
        /// <summary>Held in battle :   When the holder has 1/4 its max [HP]{mechanic:hp} remaining or less, it consumes this item to [raise]{mechanic:raise} its [Special Defense]{mechanic:special-defense} by one stage.</summary>
        /// <summary>Held in battle :   When the holder has 1/4 its max [HP]{mechanic:hp} remaining or less, it consumes this item to [raise]{mechanic:raise} its [critical hit chance]{mechanic:critical-hit-chance} by one stage.</summary>
        /// <summary>Held in battle :   When the holder has 1/4 its max [HP]{mechanic:hp} remaining or less, it consumes this item to [raise]{mechanic:raise} a random stat by two stages.</summary>
        /// <summary>Held in battle :   When the holder takes [super-effective]{mechanic:super-effective} damage, it consumes this item to restore 1/4 its max [HP]{mechanic:hp}.</summary>
        /// <summary>Held in battle :   When the holder has 1/4 its max [HP]{mechanic:hp} remaining or less, it consumes this item, and its next used move has 1.2× its normal accuracy.</summary>
        /// <summary>Held in battle :   When the holder has 1/4 its max [HP]{mechanic:hp} remaining or less, it consumes this item.  On the following turn, the holder will act first among moves with the same [priority]{mechanic:priority}, regardless of [Speed]{mechanic:speed}.</summary>
        /// <summary>Held in battle :   When the holder takes [physical]{mechanic:physical} damage, it consumes this item to damage the attacking Pokémon for 1/8 its max [HP]{mechanic:hp}.</summary>
        /// <summary>Held in battle :   When the holder takes [special]{mechanic:special} damage, it consumes this item to damage the attacking Pokémon for 1/8 its max [HP]{mechanic:hp}.</summary>
        /// <summary>Held in battle :   Moves targeting the holder have 0.9× [chance to hit]{mechanic:chance-to-hit}.</summary>
        /// <summary>Held in battle :   At the end of each turn, if any of the holder's stats have a negative [stat modifier]{mechanic:stat-modifier}, the holder consumes this item to remove the modifiers from those stats.</summary>
        /// <summary>Held :   When the holder would gain [effort]{mechanic:effort} due to battle, it gains double that effort instead.  Held in battle :   Holder has half its [Speed]{mechanic:speed}.</summary>
        /// <summary>Held :   [Experience]{mechanic:experience} is split across two groups: Pokémon who participated in battle, and Pokémon holding this item.  Each Pokémon earns experience as though it had battled alone, divided by the number of Pokémon in its group, then divided by the number of groups. Pokémon holding this item who also participated in battle effectively earn experience twice.      [Fainted]{mechanic:fainted} Pokémon never earn experience, and empty groups are ignored; thus, if a single Pokémon is holding this item and the only Pokémon who battled faints from []{move:explosion}, the holder will gain full experience.</summary>
        /// <summary>Held in battle :   Whenever the holder attempts to use a move, it has a 3/16 chance to act first among moves with the same [priority]{mechanic:priority}.  If multiple Pokémon have this effect at the same time, [Speed]{mechanic:speed} is the tie-breaker as normal, but the effect of []{move:trick-room} is ignored.</summary>
        /// <summary>Held :   When the holder would earn [happiness]{mechanic:happiness} for any reason, it earns twice that amount instead.</summary>
        /// <summary>Held in battle :   When the holder is [attracted]{move:attract}, it consumes this item to cure the attraction.</summary>
        /// <summary>Held in battle :   Holder has 1.5× its [Attack]{mechanic:attack}.  When the holder attempts to use a move, all its other moves are disabled until it leaves battle or loses this item.      The restriction ends even if this item is swapped for another Choice item via []{move:trick} or []{move:switcheroo}.</summary>
        /// <summary>Held in battle :   Holder's damaging moves have a 10% chance to make their target [flinch]{mechanic:flinch}.  This chance applies independently to each hit of a multi-hit move.      This item's chance is rolled independently of any other move effects; e.g., a move with a 30% chance to flinch normally will have a 37% total chance to flinch when used with this item, because 3% of the time, both effects activate.  Held by []{pokemon:poliwhirl} or []{pokemon:slowbro} :   Holder evolves into []{pokemon:politoed} or []{pokemon:slowking}, respectively, when traded.</summary>
        /// <summary>Held in battle :   Holder's []{type:bug}-type moves have 1.2× their power. </summary>
        /// <summary>Held :   If the holder participated in a trainer battle, the trainer earns twice the usual prize money.  This effect applies even if the holder [fainted]{mechanic:fainted}.      This effect does not stack with any other similar effect.</summary>
        /// <summary>Held by lead Pokémon: Prevents wild battles with Pokémon that are lower level than the holder.</summary>
        /// <summary>Held by Latias or Latios: Increases the holder's Special Attack and Special Defense by 50%.</summary>
        /// <summary>Held by Clamperl: Doubles the holder's Special Attack.  Evolves the holder into Huntail when traded.</summary>
        /// <summary>Held by Clamperl: Doubles the holder's Special Defense.  Evolves the holder into Gorebyss when traded.</summary>
        /// <summary>Held: In wild battles, attempts to run away on the holder's turn will always succeed.</summary>
        /// <summary>Held: Prevents the holder from evolving naturally.  Evolution initiated by the trainer (Stones, etc) will still work.</summary>
        /// <summary>Held: If the holder is attacked for regular damage that would faint it, this item has a 10% chance to prevent the holder's HP from lowering below 1.</summary>
        /// <summary>Held: Increases any Exp the holder gains by 50%.</summary>
        /// <summary>Held: Raises the holder's critical hit counter by 1.</summary>
        /// <summary>Held: Increases the power of the holder's Steel moves by 20%. Held by Onix or Scyther: Evolves the holder into Steelix or Scizor when traded, respectively.</summary>
        /// <summary>Held: Heals the holder by 1/16 its max HP at the end of each turn.</summary>
        /// <summary>Held by Seadra: Evolves the holder into Kingdra when traded.</summary>
        /// <summary>Held by Pikachu: Doubles the holder's initial Attack and Special Attack.</summary>
        /// <summary>Held: Increases the power of the holder's Ground moves by 20%.</summary>
        /// <summary>Held: Increases the power of the holder's Rock moves by 20%.</summary>
        /// <summary>Held: Increases the power of the holder's Grass moves by 20%.</summary>
        /// <summary>Held: Increases the power of the holder's Dark moves by 20%.</summary>
        /// <summary>Held: Increases the power of the holder's Fighting moves by 20%.</summary>
        /// <summary>Held: Increases the power of the holder's Electric moves by 20%.</summary>
        /// <summary>Held: Increases the power of the holder's Water moves by 20%.</summary>
        /// <summary>Held: Increases the power of the holder's Flying moves by 20%.</summary>
        /// <summary>Held: Increases the power of the holder's Poison moves by 20%.</summary>
        /// <summary>Held: Increases the power of the holder's Ice moves by 20%.</summary>
        /// <summary>Held: Increases the power of the holder's Ghost moves by 20%.</summary>
        /// <summary>Held: Increases the power of the holder's Psychic moves by 20%.</summary>
        /// <summary>Held: Increases the power of the holder's Fire moves by 20%.</summary>
        /// <summary>Held: Increases the power of the holder's Dragon moves by 20%.</summary>
        /// <summary>Held: Increases the power of the holder's Normal moves by 20%.</summary>
        /// <summary>Held by Porygon: Evolves the holder into Porygon2 when traded.</summary>
        /// <summary>Held: Heals the holder by 1/8 of any damage it inflicts.</summary>
        /// <summary>Held: Increases the power of the holder's Water moves by 20%.</summary>
        /// <summary>Held: Increases the holder's Evasion by 5%.</summary>
        /// <summary>Held by Chansey: Raises the holder's critical hit counter by 2.</summary>
        /// <summary>Held by Ditto: Increases the holder's initial Defense and Special Defense by 50%.</summary>
        /// <summary>Held by Cubone or Marowak: Doubles the holder's Attack.</summary>
        /// <summary>Held by Farfetch'd: Raises the holder's critical hit counter by 2.</summary>
        /// <summary>Held: Increases the holder's Coolness during a Super Contest's Visual Competition.</summary>
        /// <summary>Held: Increases the holder's Beauty during a Super Contest's Visual Competition.</summary>
        /// <summary>Held: Increases the holder's Cuteness during a Super Contest's Visual Competition.</summary>
        /// <summary>Held: Increases the holder's Smartness during a Super Contest's Visual Competition.</summary>
        /// <summary>Held: Increases the holder's Toughness during a Super Contest's Visual Competition.</summary>
        /// <summary>Held: Increases the accuracy of any move the holder uses by 10% (multiplied; i.e. 70% accuracy is increased to 77%).</summary>
        /// <summary>Held: Increases the power of the holder's physical moves by 10%.</summary>
        /// <summary>Held: Increases the power of the holder's special moves by 10%.</summary>
        /// <summary>Held: When the holder hits with a super-effective move, its power is raised by 20%.</summary>
        /// <summary>Held: The holder's Reflect and Light Screen will create effects lasting for eight turns rather than five.  As this item affects the move rather than the barrier itself, the effect is not lost if the holder leaves battle or drops this item.</summary>
        /// <summary>Held: Damage from the holder's moves is increased by 30%.  On each turn the holder uses a damage-inflicting move, it takes 10% its max HP in damage.</summary>
        /// <summary>Held: Whenever the holder uses a move that requires a turn to charge first (Bounce, Dig, Dive, Fly, Razor Wind, Skull Bash, Sky Attack, or Solarbeam), this item is consumed and the charge is skipped.  Skull Bash still provides a Defense boost.</summary>
        /// <summary>Held: Badly poisons the holder at the end of each turn.</summary>
        /// <summary>Held: Burns the holder at the end of each turn.</summary>
        /// <summary>Held by Ditto: Doubles the holder's initial Speed.</summary>
        /// <summary>Held: If the holder has full HP and is attacked for regular damage that would faint it, this item is consumed and prevents the holder's HP from lowering below 1.  This effect works against multi-hit attacks, but does not work against the effects of Doom Desire or Future Sight.</summary>
        /// <summary>Held: Raises the holder's Accuracy by 20% when it goes last. Ingame description is incorrect.</summary>
        /// <summary>Held: Each time the holder uses the same move consecutively, its power is increased by another 10% of its original, to a maximum of 100%.</summary>
        /// <summary>Held: Decreases the holder's Speed by 50%.  If the holder is Flying or has Levitate, it takes regular damage from Ground attacks and is suspectible to Spikes and Toxic Spikes.</summary>
        /// <summary>Held: The holder will go last within its move's priority bracket, regardless of Speed.  If multiple Pokémon within the same priority bracket are subject to this effect, the slower Pokémon will go first.  The holder will move after Pokémon with Stall.  If the holder has Stall, Stall is ignored.  This item ignores Trick Room.</summary>
        /// <summary>Held: When the holder becomes Attracted, the Pokémon it is Attracted to becomes Attracted back.</summary>
        /// <summary>Held: If the holder is Poison-type, restores 1/16 max HP at the end of each turn.  Otherwise, damages the holder by 1/16 its max HP at the end of each turn.</summary>
        /// <summary>Held: The holder's Hail will create a hailstorm lasting for eight turns rather than five.  As this item affects the move rather than the weather itself, the effect is not lost if the holder leaves battle or drops this item.</summary>
        /// <summary>Held: The holder's Sandstorm will create a sandstorm lasting for eight turns rather than five.  As this item affects the move rather than the weather itself, the effect is not lost if the holder leaves battle or drops this item.</summary>
        /// <summary>Held: The holder's Sunny Day will create sunshine lasting for eight turns rather than five.  As this item affects the move rather than the weather itself, the effect is not lost if the holder leaves battle or drops this item.</summary>
        /// <summary>Held: The holder's Rain Dance will create rain lasting for eight turns rather than five.  As this item affects the move rather than the weather itself, the effect is not lost if the holder leaves battle or drops this item.</summary>
        /// <summary>Held: Increases the duration of the holder's multiturn (2-5 turn) moves by three turns.</summary>
        /// <summary>Held: Increases the holder's Speed by 50%, but restricts it to the first move it uses until it leaves battle or loses this item.  If this item is swapped for another Choice item via Trick or Switcheroo, the holder's restriction is still lifted, but it will again be restricted to the next move it uses. (Quirk: If the holder is switched in by U-Turn and it also knows U-Turn, U-Turn becomes its restricted move.)</summary>
        /// <summary>Held: Damaged the holder for 1/8 its max HP.  When the holder is struck by a contact move, damages the attacker for 1/8 its max HP; if the attacker is not holding an item, it will take this item.</summary>
        /// <summary>Held: Decreases the holder's Speed by 50%.  Whenever the holder gains Attack effort from battle, increases that effort by 4; this applies before the PokéRUS doubling effect.</summary>
        /// <summary>Held: Decreases the holder's Speed by 50%.  Whenever the holder gains Defense effort from battle, increases that effort by 4; this applies before the PokéRUS doubling effect.</summary>
        /// <summary>Held: Decreases the holder's Speed by 50%.  Whenever the holder gains Special Attack effort from battle, increases that effort by 4; this applies before the PokéRUS doubling effect.</summary>
        /// <summary>Held: Decreases the holder's Speed by 50%.  Whenever the holder gains Special Defense effort from battle, increases that effort by 4; this applies before the PokéRUS doubling effect.</summary>
        /// <summary>Held: Decreases the holder's Speed by 50%.  Whenever the holder gains Speed effort from battle, increases that effort by 4; this applies before the PokéRUS doubling effect.</summary>
        /// <summary>Held: Decreases the holder's Speed by 50%.  Whenever the holder gains HP effort from battle, increases that effort by 4; this applies before the PokéRUS doubling effect.</summary>
        /// <summary>Held: The holder is unaffected by any moves or abilities that would prevent it from actively leaving battle.</summary>
        /// <summary>Held: HP restored from Absorb, Aqua Ring, Drain Punch, Dream Eater, Giga Drain, Ingrain, Leech Life, Leech Seed, and Mega Drain is increased by 30%.  Damage inflicted is not affected.</summary>
        /// <summary>Held: Increases the holder's Special Attack by 50%, but restricts it to the first move it uses until it leaves battle or loses this item.  If this item is swapped for another Choice item via Trick or Switcheroo, the holder's restriction is still lifted, but it will again be restricted to the next move it uses. (Quirk: If the holder is switched in by U-Turn and it also knows U-Turn, U-Turn becomes its restricted move.)</summary>
        /// <summary>Held: Increases the power of the holder's Fire moves by 20%. Held by a Multitype Pokémon: Holder's type becomes Fire.</summary>
        /// <summary>Held: Increases the power of the holder's Water moves by 20%. Held by a Multitype Pokémon: Holder's type becomes Water.</summary>
        /// <summary>Held: Increases the power of the holder's Electric moves by 20%. Held by a Multitype Pokémon: Holder's type becomes Electric.</summary>
        /// <summary>Held: Increases the power of the holder's Grass moves by 20%. Held by a Multitype Pokémon: Holder's type becomes Grass.</summary>
        /// <summary>Held: Increases the power of the holder's Ice moves by 20%. Held by a Multitype Pokémon: Holder's type becomes Ice.</summary>
        /// <summary>Held: Increases the power of the holder's Fighting moves by 20%. Held by a Multitype Pokémon: Holder's type becomes Fighting.</summary>
        /// <summary>Held: Increases the power of the holder's Poison moves by 20%. Held by a Multitype Pokémon: Holder's type becomes Poison.</summary>
        /// <summary>Held: Increases the power of the holder's Ground moves by 20%. Held by a Multitype Pokémon: Holder's type becomes Ground.</summary>
        /// <summary>Held: Increases the power of the holder's Flying moves by 20%. Held by a Multitype Pokémon: Holder's type becomes Flying.</summary>
        /// <summary>Held: Increases the power of the holder's Psychic moves by 20%. Held by a Multitype Pokémon: Holder's type becomes Psychic.</summary>
        /// <summary>Held: Increases the power of the holder's Bug moves by 20%. Held by a Multitype Pokémon: Holder's type becomes Bug.</summary>
        /// <summary>Held: Increases the power of the holder's Rock moves by 20%. Held by a Multitype Pokémon: Holder's type becomes Rock.</summary>
        /// <summary>Held: Increases the power of the holder's Ghost moves by 20%. Held by a Multitype Pokémon: Holder's type becomes Ghost.</summary>
        /// <summary>Held: Increases the power of the holder's Dragon moves by 20%. Held by a Multitype Pokémon: Holder's type becomes Dragon.</summary>
        /// <summary>Held: Increases the power of the holder's Dark moves by 20%. Held by a Multitype Pokémon: Holder's type becomes Dark.</summary>
        /// <summary>Held: Increases the power of the holder's Steel moves by 20%. Held by a Multitype Pokémon: Holder's type becomes Steel.</summary>
        /// <summary>Held: Increases the power of the holder's Psychic moves by 20%.</summary>
        /// <summary>Held: Increases the power of the holder's Rock moves by 20%.</summary>
        /// <summary>Held: The holder will go last within its move's priority bracket, regardless of Speed.  If multiple Pokémon within the same priority bracket are subject to this effect, the slower Pokémon will go first.  The holder will move after Pokémon with Stall.  If the holder has Stall, Stall is ignored.  This item ignores Trick Room.</summary>
        /// <summary>Held: Increases the power of the holder's Water moves by 20%.</summary>
        /// <summary>Held: Increases the power of the holder's Grass moves by 20%.</summary>
        /// <summary>Held: Doubles the money the trainer receives after an in-game trainer battle.  This effect cannot apply more than once to the same battle.</summary>
        /// <summary>Held by lead Pokémon: Prevents wild battles with Pokémon that are lower level than the holder.</summary>
        /// <summary>Held by Rhydon: Evolves the holder into Rhyperior when traded.</summary>
        /// <summary>Held by Electabuzz: Evolves the holder into Electivire when traded.</summary>
        /// <summary>Held by Magmar: Evolves the holder into Magmortar when traded.</summary>
        /// <summary>Held by Porygon2: Evolves the holder into Porygon-Z when traded.</summary>
        /// <summary>Held by Dusclops: Evolves the holder into Dusknoir when traded.</summary>
        /// <summary>Held: Raises the holder's critical hit counter by 1. Held by Sneasel: Evolves the holder into Weavile when it levels up during the night.</summary>
        /// <summary>Held: When the holder attacks with most damaging moves, provides an extra 11.7% (30/256) chance for the target to flinch. Held by Gligar: Evolves the holder into Gliscor when it levels up.</summary>
        /// <summary>Teaches Focus Punch to a compatible Pokémon.</summary>
        /// <summary>Teaches Dragon Claw to a compatible Pokémon.</summary>
        /// <summary>Teaches Water Pulse to a compatible Pokémon.</summary>
        /// <summary>Teaches Calm Mind to a compatible Pokémon.</summary>
        /// <summary>Teaches Roar to a compatible Pokémon.</summary>
        /// <summary>Teaches Toxic to a compatible Pokémon.</summary>
        /// <summary>Teaches Hail to a compatible Pokémon.</summary>
        /// <summary>Teaches Bulk Up to a compatible Pokémon.</summary>
        /// <summary>Teaches Bullet Seed to a compatible Pokémon.</summary>
        /// <summary>Teaches Hidden Power to a compatible Pokémon.</summary>
        /// <summary>Teaches Sunny Day to a compatible Pokémon.</summary>
        /// <summary>Teaches Taunt to a compatible Pokémon.</summary>
        /// <summary>Teaches Ice Beam to a compatible Pokémon.</summary>
        /// <summary>Teaches Blizzard to a compatible Pokémon.</summary>
        /// <summary>Teaches Hyper Beam to a compatible Pokémon.</summary>
        /// <summary>Teaches Light Screen to a compatible Pokémon.</summary>
        /// <summary>Teaches Protect to a compatible Pokémon.</summary>
        /// <summary>Teaches Rain Dance to a compatible Pokémon.</summary>
        /// <summary>Teaches Giga Drain to a compatible Pokémon.</summary>
        /// <summary>Teaches Safeguard to a compatible Pokémon.</summary>
        /// <summary>Teaches Frustration to a compatible Pokémon.</summary>
        /// <summary>Teaches SolarBeam to a compatible Pokémon.</summary>
        /// <summary>Teaches Iron Tail to a compatible Pokémon.</summary>
        /// <summary>Teaches Thunderbolt to a compatible Pokémon.</summary>
        /// <summary>Teaches Thunder to a compatible Pokémon.</summary>
        /// <summary>Teaches Earthquake to a compatible Pokémon.</summary>
        /// <summary>Teaches Return to a compatible Pokémon.</summary>
        /// <summary>Teaches Dig to a compatible Pokémon.</summary>
        /// <summary>Teaches Psychic to a compatible Pokémon.</summary>
        /// <summary>Teaches Shadow Ball to a compatible Pokémon.</summary>
        /// <summary>Teaches Brick Break to a compatible Pokémon.</summary>
        /// <summary>Teaches Double Team to a compatible Pokémon.</summary>
        /// <summary>Teaches Reflect to a compatible Pokémon.</summary>
        /// <summary>Teaches Shock Wave to a compatible Pokémon.</summary>
        /// <summary>Teaches Flamethrower to a compatible Pokémon.</summary>
        /// <summary>Teaches Sludge Bomb to a compatible Pokémon.</summary>
        /// <summary>Teaches Sandstorm to a compatible Pokémon.</summary>
        /// <summary>Teaches Fire Blast to a compatible Pokémon.</summary>
        /// <summary>Teaches Rock Tomb to a compatible Pokémon.</summary>
        /// <summary>Teaches Aerial Ace to a compatible Pokémon.</summary>
        /// <summary>Teaches Torment to a compatible Pokémon.</summary>
        /// <summary>Teaches Facade to a compatible Pokémon.</summary>
        /// <summary>Teaches Secret Power to a compatible Pokémon.</summary>
        /// <summary>Teaches Rest to a compatible Pokémon.</summary>
        /// <summary>Teaches Attract to a compatible Pokémon.</summary>
        /// <summary>Teaches Thief to a compatible Pokémon.</summary>
        /// <summary>Teaches Steel Wing to a compatible Pokémon.</summary>
        /// <summary>Teaches Skill Swap to a compatible Pokémon.</summary>
        /// <summary>Teaches Snatch to a compatible Pokémon.</summary>
        /// <summary>Teaches Overheat to a compatible Pokémon.</summary>
        /// <summary>Teaches Roost to a compatible Pokémon.</summary>
        /// <summary>Teaches Focus Blast to a compatible Pokémon.</summary>
        /// <summary>Teaches Energy Ball to a compatible Pokémon.</summary>
        /// <summary>Teaches False Swipe to a compatible Pokémon.</summary>
        /// <summary>Teaches Brine to a compatible Pokémon.</summary>
        /// <summary>Teaches Fling to a compatible Pokémon.</summary>
        /// <summary>Teaches Charge Beam to a compatible Pokémon.</summary>
        /// <summary>Teaches Endure to a compatible Pokémon.</summary>
        /// <summary>Teaches Dragon Pulse to a compatible Pokémon.</summary>
        /// <summary>Teaches Drain Punch to a compatible Pokémon.</summary>
        /// <summary>Teaches Will-O-Wisp to a compatible Pokémon.</summary>
        /// <summary>Teaches Silver Wind to a compatible Pokémon.</summary>
        /// <summary>Teaches Embargo to a compatible Pokémon.</summary>
        /// <summary>Teaches Explosion to a compatible Pokémon.</summary>
        /// <summary>Teaches Shadow Claw to a compatible Pokémon.</summary>
        /// <summary>Teaches Payback to a compatible Pokémon.</summary>
        /// <summary>Teaches Recycle to a compatible Pokémon.</summary>
        /// <summary>Teaches Giga Impact to a compatible Pokémon.</summary>
        /// <summary>Teaches Rock Polish to a compatible Pokémon.</summary>
        /// <summary>Teaches Flash to a compatible Pokémon.</summary>
        /// <summary>Teaches Stone Edge to a compatible Pokémon.</summary>
        /// <summary>Teaches Avalanche to a compatible Pokémon.</summary>
        /// <summary>Teaches Thunder Wave to a compatible Pokémon.</summary>
        /// <summary>Teaches Gyro Ball to a compatible Pokémon.</summary>
        /// <summary>Teaches Swords Dance to a compatible Pokémon.</summary>
        /// <summary>Teaches Stealth Rock to a compatible Pokémon.</summary>
        /// <summary>Teaches Psych Up to a compatible Pokémon.</summary>
        /// <summary>Teaches Captivate to a compatible Pokémon.</summary>
        /// <summary>Teaches Dark Pulse to a compatible Pokémon.</summary>
        /// <summary>Teaches Rock Slide to a compatible Pokémon.</summary>
        /// <summary>Teaches X-Scissor to a compatible Pokémon.</summary>
        /// <summary>Teaches Sleep Talk to a compatible Pokémon.</summary>
        /// <summary>Teaches Natural Gift to a compatible Pokémon.</summary>
        /// <summary>Teaches Poison Jab to a compatible Pokémon.</summary>
        /// <summary>Teaches Dream Eater to a compatible Pokémon.</summary>
        /// <summary>Teaches Grass Knot to a compatible Pokémon.</summary>
        /// <summary>Teaches Swagger to a compatible Pokémon.</summary>
        /// <summary>Teaches Pluck to a compatible Pokémon.</summary>
        /// <summary>Teaches U-Turn to a compatible Pokémon.</summary>
        /// <summary>Teaches Substitute to a compatible Pokémon.</summary>
        /// <summary>Teaches Flash Cannon to a compatible Pokémon.</summary>
        /// <summary>Teaches Trick Room to a compatible Pokémon.</summary>
        /// <summary>Teaches Cut to a compatible Pokémon.</summary>
        /// <summary>Teaches Fly to a compatible Pokémon.</summary>
        /// <summary>Teaches Surf to a compatible Pokémon.</summary>
        /// <summary>Teaches Strength to a compatible Pokémon.</summary>
        /// <summary>Teaches Defog to a compatible Pokémon.</summary>
        /// <summary>Teaches Rock Smash to a compatible Pokémon.</summary>
        /// <summary>Teaches Waterfall to a compatible Pokémon.</summary>
        /// <summary>Teaches Rock Climb to a compatible Pokémon.</summary>
        /// <summary>Sends the trainer to the Underground.  Only usable outside.</summary>
        /// <summary>Unused.</summary>
        /// <summary>Unused.</summary>
        /// <summary>Designates several nearby patches of grass as containing Pokémon, some of which may be special radar-only Pokémon.  Successive uses in a certain way create chains of encounters with the same species; longer chains increase the chance that a shiny Pokémon of that species will appear.</summary>
        /// <summary>Tracks Battle Points.</summary>
        /// <summary>Records some of the trainer's activities for the day.</summary>
        /// <summary>Contains Seals used for decorating Pokéballs.</summary>
        /// <summary>Contains Pokémon Accessories.</summary>
        /// <summary>Unused.</summary>
        /// <summary>Contains friend codes for up to 32 other players, as well as their sprite, gender, and basic statistics for those that have been seen on WFC.</summary>
        /// <summary>Opens the front door of the Valley Windworks.  Reusable.</summary>
        /// <summary>Given to Cynthia's grandmother to get the Surf HM.</summary>
        /// <summary>Grants access to Galactic HQ in Veilstone City.</summary>
        /// <summary>Unused.</summary>
        /// <summary>Displays a map of the region including the trainer's position, location names, visited towns, gym locations, and where the trainer has been walking recently.</summary>
        /// <summary>Reveals trainers who want a rematch, by showing !! over their heads.  Each use drains the battery; requires 100 steps to charge.</summary>
        /// <summary>Contains the Coins used by the Game Corner, to a maximum of 50,000.</summary>
        /// <summary>Used to find Pokémon on the Old Rod list for an area, which are generally Magikarp or similar.</summary>
        /// <summary>Used to find Pokémon on the Good Rod list for an area, which are generally mediocre.</summary>
        /// <summary>Used to find Pokémon on the Super Rod list for an area, which are generally the best available there.</summary>
        /// <summary>Waters Berry plants.</summary>
        /// <summary>Contains up to 100 Poffins.</summary>
        /// <summary>Increases movement speed outside or in caves.  In high gear, allows the trainer to hop over some rocks and ascend muddy slopes.</summary>
        /// <summary>Opens the locked building in the lakeside resort.</summary>
        /// <summary>Grants access to Flower Paradise and Shaymin.</summary>
        /// <summary>Cures the sailor's son of his nightmares; no reward, only a side effect of seeing Cresselia.</summary>
        /// <summary>Provides access to Newmoon Island and Darkrai.</summary>
        /// <summary>Supposedly related to t</summary>
        /// <summary>Allows passage on a ferry.  The same item is used for different ferries between different games.</summary>
        /// <summary>Allows the trainer to enter Contests.</summary>
        /// <summary>Causes Heatran to appear at Reversal Mountain.  Unused prior to Black and White 2.</summary>
        /// <summary>Given to the trainer's rival in Jubilife City.  Contains two Town Maps, one of which is given to the trainer upon delivery.</summary>
        /// <summary>One of three coupons needed to receive a Pokétch.</summary>
        /// <summary>One of three coupons needed to receive a Pokétch.</summary>
        /// <summary>One of three coupons needed to receive a Pokétch.</summary>
        /// <summary>Grants access to the Team Galactic warehouse in Veilstone City.</summary>
        /// <summary>Required to cure the Psyducks blocking Route 210 of their chronic headaches.</summary>
        /// <summary>Held by []{pokemon:giratina} :   Holder's []{type:dragon} and []{type:ghost} moves have 1.2× their base power.      Holder is in Origin Forme.  This item cannot be held by any Pokémon but Giratina.  When you enter the Union Room or connect to Wi-Fi, this item returns to your bag.</summary>
        /// <summary>Optionally records wireless, Wi-Fi, and Battle Frontier battles.  Tracks Battle Points earned in the Battle Frontier, and stores commemorative prints.</summary>
        /// <summary>Used by trainer on a []{pokemon:shaymin} :   Changes the target Shaymin from Land Forme to Sky Forme.      This item cannot be used on a [frozen]{mechanic:freezing} Shaymin or at night.  Sky Forme Shaymin will revert to Land Forme overnight, when frozen, and upon entering a link battle.  This item must be used again to change it back.</summary>
        /// <summary>Used by trainer in the Galactic Eterna Building, on the ground floor, to the left of the TV :   Unlocks the secret []{pokemon:rotom} room, in which there are five appliances which can change Rotom's form.</summary>
        /// <summary>Stores Apricorns.</summary>
        /// <summary>Contains four portable pots of soil suitable for growing berries.</summary>
        /// <summary>Required to water berries within the []{item:berry-pots}.  Required to battle the []{pokemon:sudowoodo} on []{location:johto-route-36}.  This item cannot be directly used from the bag.</summary>
        /// <summary>Used by trainer in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon.  If used in a trainer battle, nothing happens and the ball is lost.      If the wild Pokémon was encountered by fishing, the wild Pokémon's catch rate is 3× normal.</summary>
        /// <summary>Used by trainer in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon.  If used in a trainer battle, nothing happens and the ball is lost.      If the trainer's Pokémon's level is higher than:      * four times the wild Pokémon's, the wild Pokémon's catch rate is 8× normal.     * than twice the wild Pokémon's, the wild Pokémon's catch rate is 4× normal.     * the wild Pokémon's, the wild Pokémon's catch rate is 2× normal.</summary>
        /// <summary>Used by trainer in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon.  If used in a trainer battle, nothing happens and the ball is lost.      If the wild Pokémon is a []{pokemon:clefairy}, []{pokemon:nidoran-m}, []{pokemon:nidoran-f}, []{pokemon:jigglypuff}, []{pokemon:skitty}, or any evolution thereof, the wild Pokémon has 4× its catch rate.</summary>
        /// <summary>Used by a trainer in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon.  If used in a trainer battle, nothing happens and the ball is lost.      If the wild Pokémon weighs:      * 409.6 kg (903.0 lb) or more, its catch rate is 40 more than normal.     * 307.2 kg (677.3 lb) or more, its catch rate is 30 more than normal.     * 204.8 kg (451.5 lb) or more, its catch rate is 20 more than normal.     * less than 204.8 kg (451.5 lb), its catch rate is 20 less than normal.</summary>
        /// <summary>Used by a trainer in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon.  If used in a trainer battle, nothing happens and the ball is lost.  :   If the wild Pokémon's base [speed]{mechanic:speed} is 100 or more, its catch rate is 4× normal.</summary>
        /// <summary>Used by a trainer in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon.  If used in a trainer battle, nothing happens and the ball is lost.      If caught, the wild Pokémon's [happiness]{mechanic:happiness} starts at 200.</summary>
        /// <summary>Used by a trainer in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon.  If used in a trainer battle, nothing happens and the ball is lost.      If the trainer's Pokémon and wild Pokémon are of the same species but opposite genders, the wild Pokémon's catch rate is 8× normal.</summary>
        /// <summary>Used by a trainer in battle :   [Catches]{mechanic:catch} a wild Pokémon.  This item can only be used in []{location:pal-park}.</summary>
        /// <summary>Used by a trainer in battle :   Attempts to [catch]{mechanic:catch} a wild Pokémon.      The wild Pokémon's catch rate is 1.5× normal.</summary>
        /// <summary>May be given to Kurt in []{location:azalea-town} to produce a []{item:level-ball}.</summary>
        /// <summary>May be given to Kurt in []{location:azalea-town} to produce a []{item:lure-ball}.</summary>
        /// <summary>May be given to Kurt in []{location:azalea-town} to produce a []{item:moon-ball}.</summary>
        /// <summary>May be given to Kurt in []{location:azalea-town} to produce a []{item:friend-ball}.</summary>
        /// <summary>May be given to Kurt in []{location:azalea-town} to produce a []{item:love-ball}.</summary>
        /// <summary>May be given to Kurt in []{location:azalea-town} to produce a []{item:fast-ball}.</summary>
        /// <summary>May be given to Kurt in []{location:azalea-town} to produce a []{item:heavy-ball}.</summary>
        /// <summary>Used by trainer outside of battle :   Searches for hidden items.</summary>
        /// <summary>May be traded for a []{item:tm64} in the vertical Underground Path.</summary>
        /// <summary>Causes []{pokemon:groudon} to appear in the []{location:embedded-tower}.</summary>
        /// <summary>Causes []{pokemon:kyogre} to appear in the []{location:embedded-tower}.</summary>
        /// <summary>Causes []{pokemon:rayquaza} to appear in the []{location:embedded-tower}.</summary>
        /// <summary>When taken to the []{location:pewter-city} museum, causes []{pokemon:latias} or []{pokemon:latios} to attack the trainer.  The Pokémon to appear will be whicher can't be encountered roaming in the wild.</summary>
        /// <summary>Lists which []{pokemon:unown} forms the trainer has caught.</summary>
        /// <summary>Allows the trainer to answer the daily question on Buena's radio show.  Records the points earned for correct answers.</summary>
        /// <summary>Does nothing.</summary>
        /// <summary>May be given to the Kimono Girls to summon []{pokemon:ho-oh} to the top of the []{location:bell-tower}.</summary>
        /// <summary>Used by trainer outside of battle :   Opens doors in the []{location:goldenrod-city} Radio Tower.</summary>
        /// <summary>Used by trainer outside of battle :   Opens the door to the basement tunnel under []{location:goldenrod-city}.</summary>
        /// <summary>May be traded to Mr. Pokémon for an []{item:exp-share}.</summary>
        /// <summary>May be traded to the Copycat for a []{item:pass}.</summary>
        /// <summary>Allows the trainer to ride the Magnet Train between []{location:goldenrod-city} and []{location:saffron-city}.</summary>
        /// <summary>Must be replaced in the []{location:power-plant} to power the Magnet Train.</summary>
        /// <summary>Causes []{pokemon:lugia} to appear in the []{location:whirl-islands}.</summary>
        /// <summary>Causes []{pokemon:ho-oh} to appear at the top of []{location:bell-tower}.</summary>
        /// <summary>Must be obtained to trigger the break-in at Professor Elm's lab, the first rival battle, and access to []{location:johto-route-31}.</summary>
        /// <summary>Used by trainer outside of battle :   Changes the background music to the equivalent 8-bit music.</summary>
        /// <summary>May be given to the Kimono Girls to summon []{pokemon:lugia} to the top of the []{location:bell-tower}.</summary>
        /// <summary>Records the number of times the trainer has come in first place overall in the Pokéathlon.</summary>
        /// <summary>Records the number of times the trainer has come in last place overall in the Pokéathlon.</summary>
        /// <summary>Records the number of times the trainer's Pokémon have dashed in the Pokéathlon.</summary>
        /// <summary>Records the number of times the trainer's Pokémon have jumped in the Pokéathlon.</summary>
        /// <summary>Records the number of times the trainer has come in first in the Pokéathlon Hurdle Dash.</summary>
        /// <summary>Records the number of times the trainer has come in first in the Pokéathlon Relay Run.</summary>
        /// <summary>Records the number of times the trainer has come in first in the Pokéathlon Pennant Capture.</summary>
        /// <summary>Records the number of times the trainer has come in first in the Pokéathlon Block Smash.</summary>
        /// <summary>Records the number of times the trainer has come in first in the Pokéathlon Disc Catch.</summary>
        /// <summary>Records the number of times the trainer has come in first in the Pokéathlon Snow Throw.</summary>
        /// <summary>Records the number of points the trainer has earned in the Pokéathlon.</summary>
        /// <summary>Records the number of times the trainer's Pokémon have messed up in the Pokéathlon.</summary>
        /// <summary>Records the number of times the trainer's Pokémon have defeated themselves in the Pokéathlon.</summary>
        /// <summary>Records the number of times the trainer's Pokémon have tackled in the Pokéathlon.</summary>
        /// <summary>Records the number of times the trainer's Pokémon have fallen in the Pokéathlon.</summary>
        /// <summary>Records the number of times the trainer has come in first in the Pokéathlon Ring Drop.</summary>
        /// <summary>Records the number of times the trainer has come in first in the Pokéathlon Lamp Jump.</summary>
        /// <summary>Records the number of times the trainer has come in first in the Pokéathlon Circle Push.</summary>
        /// <summary>Records the number of times the trainer has come in first place overall in the Pokéathlon over wirelss.</summary>
        /// <summary>Records the number of times the trainer has come in last place overall in the Pokéathlon over wireless.</summary>
        /// <summary>Records the number of times the trainer has come in first across all Pokéathlon events.</summary>
        /// <summary>Records the number of times the trainer has come in last across all Pokéathlon events.</summary>
        /// <summary>Records the number of times the trainer has switched Pokémon in the Pokéathlon.</summary>
        /// <summary>Records the number of times the trainer has come in first in the Pokéathlon Goal Roll.</summary>
        /// <summary>Records the number of times the trainer's Pokémon received prizes in the Pokéathlon.</summary>
        /// <summary>Records the number of times the trainer has instructed Pokémon in the Pokéathlon.</summary>
        /// <summary>Records the total time spent in the Pokéathlon.</summary>
        /// <summary>Does nothing.</summary>
        /// <summary>Does nothing.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Increases movement speed outside or in caves.  Faster than the []{item:acro-bike}.  Allows the trainer to ascend muddy slopes.</summary>
        /// <summary>Increases movement speed outside or in caves.  Slower than the []{item:mach-bike}.  Can perform various tricks, allowing the trainer to reach certain special areas.</summary>
        /// <summary>Waters Berry plants.</summary>
        /// <summary>Contains a machine part to be delivered to Captain Stern.</summary>
        /// <summary>Collects soot when walking through tall grass on []{location:hoenn-route-113}.</summary>
        /// <summary>Stores Pokéblocks.</summary>
        /// <summary>Contains a letter to be delivered to Steven.</summary>
        /// <summary>Provides access to []{location:southern-island} and either []{pokemon:latias} or []{pokemon:latios}, whichever is not available roaming around Hoenn.</summary>
        /// <summary>May be traded to Captain Stern for a []{item:deep-sea-tooth} or a []{item:deep-sea-scale}.</summary>
        /// <summary>Allows the trainer to enter the desert on []{location:hoenn-route-111}.</summary>
        /// <summary>RSE: May be traded to Professor Cozmo for []{item:tm27}.  FRLG: A meteorite to be delivered to Lostelle's father.</summary>
        /// <summary>Unlocks room 1 on the []{location:abandoned-ship}.</summary>
        /// <summary>Unlocks room 2 on the []{location:abandoned-ship}.</summary>
        /// <summary>Unlocks room 4 on the []{location:abandoned-ship}.</summary>
        /// <summary>Unlocks room 6 on the []{location:abandoned-ship}.</summary>
        /// <summary>Reveals invisble []{pokemon:kecleon} on the overworld.</summary>
        /// <summary>A parcel to be delivered to Professor Oak for a Pokédex.</summary>
        /// <summary>Wakes up [sleeping]{mechanic:sleep} Pokémon.  Required to wake up sleeping []{pokemon:snorlax} on the overworld.</summary>
        /// <summary>May be traded for a []{item:bicycle}.</summary>
        /// <summary>The Safari Zone warden's teeth, to be returned to him for []{item:hm04}.</summary>
        /// <summary>Operates the elevator in the Celadon Rocket Hideout.</summary>
        /// <summary>Identifies ghosts in []{location:pokemon-tower}.</summary>
        /// <summary>Records information on various famous people.</summary>
        /// <summary>Stores TMs and HMs.</summary>
        /// <summary>Stores Berries.</summary>
        /// <summary>Teaches beginning trainers basic information.</summary>
        /// <summary>Provides access to the first three Sevii Islands.</summary>
        /// <summary>Provides access to the Sevii Islands.</summary>
        /// <summary>Used to bribe the []{location:saffron-city} guards for entry to the city.</summary>
        /// <summary>Provides access to Navel Rock, []{pokemon:ho-oh}, and []{pokemon:lugia}.</summary>
        /// <summary>Provides access to Birth Island and []{pokemon:deoxys}.</summary>
        /// <summary>Holds Berry Powder from Berry Crushing.</summary>
        /// <summary>Deliver to Celio for use in the Network Machine.</summary>
        /// <summary>Deliver to Celio for use in the Network Machine.</summary>
        /// <summary>Provides access to the []{location:magma-hideout} in the []{location:jagged-pass}.</summary>
        /// <summary>Provides access to Faraway Island and []{pokemon:mew}.</summary>
        /// <summary>Held by []{pokemon:genesect} :   Holder's buster is blue, and its []{move:techno-blast} is []{type:water}-type.</summary>
        /// <summary>Held by []{pokemon:genesect} :   Holder's buster is yellow, and its []{move:techno-blast} is []{type:electric}-type.</summary>
        /// <summary>Held by []{pokemon:genesect} :   Holder's buster is red, and its []{move:techno-blast} is []{type:fire}-type.</summary>
        /// <summary>Held by []{pokemon:genesect} :   Holder's buster is white, and its []{move:techno-blast} becomes []{type:ice}-type.</summary>
        /// <summary>Used on a friendly Pokémon :   Restores 20 [HP]{mechanic:hp}.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Used to send short messages to other players via Pokémon trading.  Trainer may compose a message from a finite list of words when giving this item to a Pokémon.  Once taken and read, a message may be erased and this item can be reused, or the message may be stored in the trainer's PC.  Held :   Holder cannot be placed in the PC.  Any move attempting to remove this item from the holder will fail.</summary>
        /// <summary>Held by []{pokemon:feebas} :   Holder evolves into []{pokemon:milotic} when traded.</summary>
        /// <summary>Held by a Pokémon that is not fully evolved :   Holder has 1.5× [Defense]{mechanic:defense} and [Special Defense]{mechanic:special-defense}.</summary>
        /// <summary>Held :   Holder has 0.5× weight.</summary>
        /// <summary>Held :   When the holder is hit by a [contact]{mechanic:contact} move, the attacking Pokémon takes 1/6 its max [HP]{mechanic:hp} in damage.</summary>
        /// <summary>Held :   Holder is immune to []{type:ground}-type moves, []{move:spikes}, []{move:toxic-spikes}, and []{ability:arena-trap}.      This effect does not apply during []{move:gravity} or []{move:ingrain}.      When the holder takes damage from a move, this item is consumed.</summary>
        /// <summary>Held :   When the holder takes damage directly from a move and does not faint, it [switches out]{mechanic:switching-out} for another random, non-fainted Pokémon in its party. This effect does not activate if another effect prevents the holder from switching out.</summary>
        /// <summary>Held :   When one of the user's types would render it immune to damage, that type is ignored for damage calculation.</summary>
        /// <summary>Held :   Moves used by the holder that trap and damage a target for multiple turns (e.g. []{move:bind}, []{move:fire-spin}) inflict twice their usual per-turn damage.</summary>
        /// <summary>Held :   When the holder takes []{type:water}-type damage from a move, its [Special Attack]{mechanic:special-attack} rises by one [stage]{mechanic:stage} and this item is consumed.</summary>
        /// <summary>Held :   When the holder takes []{type:electric}-type damage from a move, its [Attack]{mechanic:attack} rises by one [stage]{mechanic:stage} and this item is consumed.</summary>
        /// <summary>Held :   When the holder takes damage directly from a move and does not faint, it [switches out]{mechanic:switching-out} for another non-fainted Pokémon in its party, as chosen by the Trainer. This effect does not activate if another effect prevents the holder from switching out.</summary>
        /// <summary>Held :   When the holder uses a damaging []{type:fire}-type move, the move has 1.5× power and this item is consumed.</summary>
        /// <summary>Held :   When the holder uses a damaging []{type:water}-type move, the move has 1.5× power and this item is consumed.</summary>
        /// <summary>Held :   When the holder uses a damaging []{type:electric}-type move, the move has 1.5× power and this item is consumed.</summary>
        /// <summary>Held :   When the holder uses a damaging []{type:grass}-type move, the move has 1.5× power and this item is consumed.</summary>
        /// <summary>Held :   When the holder uses a damaging []{type:ice}-type move, the move has 1.5× power and this item is consumed.</summary>
        /// <summary>Held :   When the holder uses a damaging []{type:fighting}-type move, the move has 1.5× power and this item is consumed.</summary>
        /// <summary>Held :   When the holder uses a damaging []{type:poison}-type move, the move has 1.5× power and this item is consumed.</summary>
        /// <summary>Held :   When the holder uses a damaging []{type:ground}-type move, the move has 1.5× power and this item is consumed.</summary>
        /// <summary>Held :   When the holder uses a damaging []{type:flying}-type move, the move has 1.5× power and this item is consumed.</summary>
        /// <summary>Held :   When the holder uses a damaging []{type:psychic}-type move, the move has 1.5× power and this item is consumed.</summary>
        /// <summary>Held :   When the holder uses a damaging []{type:bug}-type move, the move has 1.5× power and this item is consumed.</summary>
        /// <summary>Held :   When the holder uses a damaging []{type:rock}-type move, the move has 1.5× power and this item is consumed.</summary>
        /// <summary>Held :   When the holder uses a damaging []{type:ghost}-type move, the move has 1.5× power and this item is consumed.</summary>
        /// <summary>Held :   When the holder uses a damaging []{type:dark}-type move, the move has 1.5× power and this item is consumed.</summary>
        /// <summary>Held :   When the holder uses a damaging []{type:steel}-type move, the move has 1.5× power and this item is consumed.</summary>
        /// <summary>Used on a party Pokémon :   Increases the target's [HP]{mechanic:hp} [effort]{mechanic:effort} by 1.</summary>
        /// <summary>Used on a party Pokémon :   Increases the target's [Attack]{mechanic:attack} [effort]{mechanic:effort} by 1.</summary>
        /// <summary>Used on a party Pokémon :   Increases the target's [Defense]{mechanic:defense} [effort]{mechanic:effort} by 1.</summary>
        /// <summary>Used on a party Pokémon :   Increases the target's [Special Attack]{mechanic:special-attack} [effort]{mechanic:effort} by 1.</summary>
        /// <summary>Used on a party Pokémon :   Increases the target's [Special Defense]{mechanic:special-defense} [effort]{mechanic:effort} by 1.</summary>
        /// <summary>Used on a party Pokémon :   Increases the target's [Speed]{mechanic:speed} [effort]{mechanic:effort} by 1.</summary>
        /// <summary>Vendor trash.</summary>
        /// <summary>Give to a scientist in a museum to receive a []{pokemon:tirtouga}.</summary>
        /// <summary>Give to a scientist in a museum to receive a []{pokemon:archen}.</summary>
        /// <summary>Allows passage on the []{location:castelia-city} ship, which leads to []{location:liberty-garden} and []{pokemon:victini}.</summary>
        /// <summary>Acts as currency to activate Pass Powers in the Entralink.</summary>
        /// <summary>Can only be used in Entree Forest, to catch Pokémon encountered in the Dream World.  Used in battle :   [Catches]{mechanic:catch} a wild Pokémon without fail.</summary>
        /// <summary>Used in battle :   Ends a wild battle.  Cannot be used in trainer battles.</summary>
        /// <summary>Stores props for the Pokémon Musical.</summary>
        /// <summary>Only used as a plot point; this item is given to the player and taken away in the same cutscene.</summary>
        /// <summary>Cult vendor trash.</summary>
        /// <summary>Cult vendor trash.</summary>
        /// <summary>Cult vendor trash.</summary>
        /// <summary>Cult vendor trash.</summary>
        /// <summary>Cult vendor trash.</summary>
        /// <summary>Cult vendor trash.</summary>
        /// <summary>Cult vendor trash.</summary>
        /// <summary>Cult vendor trash.</summary>
        /// <summary>Cult vendor trash.</summary>
        /// <summary>Cult vendor trash.</summary>
        /// <summary>Cult vendor trash.</summary>
        /// <summary>Used on a party Pokémon :   Cures any [status ailment]{mechanic:status-ailment} and [confusion]{mechanic:confusion}.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [critical hit]{mechanic:critical-hit} rate by two [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [Speed]{mechanic:speed} by two [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [Special Attack]{mechanic:special-attack} by two [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [Special Defense]{mechanic:special-defense} by two [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [Defense]{mechanic:defense} by two [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [Attack]{mechanic:attack} by two [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [accuracy]{mechanic:accuracy} by two [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [Speed]{mechanic:speed} by three [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [Special Attack]{mechanic:special-attack} by three [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [Special Defense]{mechanic:special-defense} by three [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [Defense]{mechanic:defense} by three [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [Attack]{mechanic:attack} by three [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [accuracy]{mechanic:accuracy} by three [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [Speed]{mechanic:speed} by six [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [Special Attack]{mechanic:special-attack} by six [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [Special Defense]{mechanic:special-defense} by six [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [Defense]{mechanic:defense} by six [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [Attack]{mechanic:attack} by six [stages]{mechanic:stage}.  This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [accuracy]{mechanic:accuracy} by six [stages]{mechanic:stage}.  This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Selects another friendly Pokémon at random.  If that Pokémon's ability is normally activated by some condition—i.e., is not continuous and passive—its effect is forcibly activated.  This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Selects another friendly Pokémon at random.  If that Pokémon is holding an item, that item is removed for the duration of the battle.  This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Selects another friendly Pokémon at random.  If that Pokémon is holding an item normally activated by some condition—i.e., not continuous and passive—its effect is forcibly activated.  This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Selects another friendly Pokémon at random.  Removes all of that Pokémon's stat changes.  This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Used on a party Pokémon in battle :   Raises the target's [critical hit]{mechanic:critical-hit} rate by three [stages]{mechanic:stage}. This item can only be obtained or used via the Wonder Launcher.</summary>
        /// <summary>Summons []{pokemon:reshiram} for the final battle against N.</summary>
        /// <summary>Summons []{pokemon:zekrom} for the final battle against N.</summary>
        /// <summary>Teaches []{move:wild-charge} to a compatible Pokémon.</summary>
        /// <summary>Teaches []{move:rock-smash} to a compatible Pokémon.</summary>
        /// <summary>Teaches []{move:snarl} to a compatible Pokémon.</summary>
        /// <summary>Makes four-way video calls.  Used for plot advancement in-game, but also works with other players via the C-Gear.</summary>
        /// <summary>Unknown.  Currently unused.</summary>
        /// <summary>Give to the []{pokemon:wingull} on []{location:unova-route-13}, along with []{item:gram-2} and []{item:gram-3}, to receive []{item:tm89}.</summary>
        /// <summary>Give to the []{pokemon:wingull} on []{location:unova-route-13}, along with []{item:gram-1} and []{item:gram-3}, to receive []{item:tm89}.</summary>
        /// <summary>Give to the []{pokemon:wingull} on []{location:unova-route-13}, along with []{item:gram-1} and []{item:gram-2}, to receive []{item:tm89}.</summary>
        /// <summary>Held :   When the holder uses a damaging []{type:dragon}-type move, the move has 1.5× power and this item is consumed.</summary>
        /// <summary>Held :   When the holder uses a damaging []{type:normal}-type move, the move has 1.5× power and this item is consumed.</summary>
        /// <summary>Holds medals recieved in the medal rally.</summary>
        /// <summary>Fuses Kyurem with Reshiram or Zekrom, or splits them apart again.</summary>
        /// <summary>Grants access to the Nature Preserve.</summary>
        /// <summary>Doubles the chance of two Pokémon producing an egg at the daycare every 255 steps.</summary>
        /// <summary>Raises the chance of finding a shiny Pokémon.</summary>
        /// <summary>Required to progress in the Plasma Frigate.</summary>
        /// <summary>Appears in the Café Warehouse on Sunday; return to the customer with a Patrat on Thursday.</summary>
        /// <summary>Wakes up the Crustle blocking the way in Seaside Cave.</summary>
        /// <summary>Returned to Curtis or Yancy as part of a sidequest.</summary>
        /// <summary>Switches Tornadus, Thundurus, and Landorus between Incarnate and Therian Forme.</summary>
        /// <summary>An item to be held by a Pokémon. Attack and Sp. Atk sharply increase if the holder is hit with a move it’s weak to.</summary>
        /// <summary>An item to be held by a Pokémon. This offensive vest raises Sp. Def but prevents the use of status moves.</summary>
        /// <summary>An item to be held by a Pokémon. It is a stone tablet that boosts the power of Fairy-type moves.</summary>
        /// <summary>A capsule that allows a Pokémon with two Abilities to switch between these Abilities when it is used.</summary>
        /// <summary>A soft and sweet treat made of fluffy, puffy, whipped and whirled cream. It’s loved by a certain Pokémon.</summary>
        /// <summary>A sachet filled with fragrant perfumes that are just slightly too overwhelming. Yet it’s loved by a certain Pokémon.</summary>
        /// <summary>An item to be held by a Pokémon. It boosts Sp. Def if hit with a Water- type attack. It can only be used once.</summary>
        /// <summary>An item to be held by a Pokémon. It boosts Attack if hit with an Ice-type attack. It can only be used once.</summary>
        /// <summary>An item to be held by a Pokémon. These goggles protect the holder from both weather-related damage and powder.</summary>
        /// <summary>Mulch to be used in a Berry field. It increases the Berry harvest without the need for particularly diligent care.</summary>
        /// <summary>Mulch to be used in a Berry field. It causes strange, sudden mutations based on the combination of Berries.</summary>
        /// <summary>Mulch to be used in a Berry field. It increases the Berry harvest that can be grown by diligent watering.</summary>
        /// <summary>Mulch to be used in a Berry field. An amazing Mulch with the effects of Rich, Surprise, and Boost Mulch.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Gengar hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Gardevoir hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Ampharos hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Venusaur hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Charizard hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Blastoise hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Mewtwo hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Mewtwo hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Blaziken hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Medicham hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Houndoom hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Aggron hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Banette hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Tyranitar hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Scizor hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Pinsir hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Aerodactyl hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Lucario hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Abomasnow hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Kangaskhan hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Gyarados hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Absol hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Charizard hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Alakazam hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Heracross hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Mawile hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Manectric hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>One variety of the mysterious Mega Stones. Have Garchomp hold it, and this stone will enable it to Mega Evolve during battle.</summary>
        /// <summary>If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Fairy-type attack.</summary>
        /// <summary>If held by a Pokémon, this Berry will increase the holder’s Defense if it’s hit with a physical move.</summary>
        /// <summary>If held by a Pokémon, this Berry will increase the holder’s Sp. Def if it’s hit with a special move.</summary>
        /// <summary>This special coupon allows you to buy items at a discount when you are shopping at a boutique.</summary>
        /// <summary>An ornament depicting a Pokémon that is venerated as a protector in some region far from Kalos.</summary>
        /// <summary>A popular treat in Lumiose City. It can be used once to heal all the status conditions of a Pokémon.</summary>
        /// <summary>A fossil from a prehistoric Pokémon that once lived on the land. It looks as if it could be a piece of a large jaw.</summary>
        /// <summary>A fossil from a prehistoric Pokémon that once lived on the land. It looks like the impression from a skin sail.</summary>
        /// <summary>A gem with an essence of the fey. When held, it strengthens the power of a Fairy-type move one time.</summary>
        /// <summary>This book contains all the points a new Trainer needs to know on a journey. It was handmade by a kind friend.</summary>
        /// <summary>A card key that activates the elevator in Lysandre Labs. It is emblazoned with Team Flare’s logo.</summary>
        /// <summary>A device that allows users to receive and view hologram clips at any time. It is also used to chat with others.</summary>
        /// <summary>A precious symbol that is awarded only to an individual who has done great things for the Kalos region.</summary>
        /// <summary>A rather curious stone that might appear to be valuable to some. It’s all in the eye of the beholder.</summary>
        /// <summary>A rather chic-looking case for carrying contact lenses.</summary>
        /// <summary>A ticket that was handmade by Looker. It’s decorated with a liberal amount of glittery paint.</summary>
        /// <summary>This ring contains an untold power that somehow enables Pokémon carrying Mega Stones to Mega Evolve in battle.</summary>
        /// <summary>This pass serves as an ID card for gaining access to the power plant that lies along Route 13.</summary>
        /// <summary>A letter that Professor Sycamore wrote to your mother. A faint but pleasant perfume seems to cling to the paper.</summary>
        /// <summary>Attaches roller skates to the bottom of your shoes, allowing you to glide quickly around and perform tricks.</summary>
        /// <summary>A watering can shaped like a Lotad. It helps promote the healthy growth of any Berries planted in good, soft soil.</summary>
        /// <summary>A commuter pass that allows the holder to ride the TMV between Lumiose City and Kiloude City at any time.</summary>
        /// <summary>An attack that makes use of nature’s power. Its effects vary depending on the user’s environment.</summary>
        /// <summary>The user releases a horrible aura imbued with dark thoughts. This may also make the target flinch.</summary>
        /// <summary>Striking opponents over and over makes the user’s fists harder. Hitting a target raises the Attack stat.</summary>
        /// <summary>The user damages opposing Pokémon by emitting a powerful flash.</summary>
        /// <summary>The user tells the target a secret, and the target loses its ability to concentrate. This lowers the target’s Sp. Atk stat.</summary>
        //Everything beyond here is new, about 208 new values added
        /// <summary>Held: Allows Latias to Mega Evolve into Mega Latias. : 	Held: Allows Latias to Mega Evolve into Mega Latias.</summary>
        LATIASITE = 760,
        /// <summary>Held: Allows Latios to Mega Evolve into Mega Latios. : 	Held: Allows Latios to Mega Evolve into Mega Latios.</summary>
        LATIOSITE = 761,
        /// <summary>Unknown. : 	Unknown.</summary>
        COMMON_STONE = 762,
        /// <summary>Allows the player to change their lipstick color. : 	Allows the player to change their lipstick color.</summary>
        MAKEUP_BAG = 763,
        /// <summary>Unobtainable, but allows the player to change clothes anywhere. : 	Unobtainable, but allows the player to change clothes anywhere.</summary>
        TRAVEL_TRUNK = 764,
        /// <summary>Cures any major status ailment and confusion. : 	Cures any major status ailment and confusion.</summary>
        SHALOUR_SABLE = 765,
        /// <summary>Unused.  This appears as the girlplayer's Mega Bracelet in PokÃ©mon Contests, but it cannot actually be obtained. : 	Unused Key Stone.</summary>
        MEGA_CHARM = 768,
        /// <summary>Unused.  This is Korrina's Key Stone in X and Y, but it cannot be obtained by the player. : 	Unused NPC Key Stone.</summary>
        MEGA_GLOVE = 769,
        /// <summary>Allows Captain Stern to set out on his expedition. : 	Allows Captain Stern to set out on his expedition.</summary>
        DEVON_PARTS = 770,
        /// <summary>Creates and stores PokÃ©blocks. : 	Creates and stores PokÃ©blocks.</summary>
        POKEBLOCK_KIT = 772,
        /// <summary>Unlocks the door to Room 1 in Sea Mauville. : 	Unlocks the door to Room 1 in Sea Mauville.</summary>
        KEY_TO_ROOM_1 = 773,
        /// <summary>Unlocks the door to Room 2 in Sea Mauville. : 	Unlocks the door to Room 2 in Sea Mauville.</summary>
        KEY_TO_ROOM_2 = 774,
        /// <summary>Unlocks the door to Room 4 in Sea Mauville. : 	Unlocks the door to Room 4 in Sea Mauville.</summary>
        KEY_TO_ROOM_4 = 775,
        /// <summary>Unlocks the door to Room 6 in Sea Mauville. : 	Unlocks the door to Room 6 in Sea Mauville.</summary>
        KEY_TO_ROOM_6 = 776,
        /// <summary>Worn by the player while underwater via Dive in Omega Ruby and Alpha Sapphire. : 	Worn by the player while underwater.</summary>
        DEVON_SCUBA_GEAR = 779,
        /// <summary>Worn during PokÃ©mon Contests. : 	Worn during PokÃ©mon Contests.</summary>
        CONTEST_COSTUME__JACKET = 780,
        /// <summary>Allows the player to ride Groudon in the Cave of Origin. : 	Allows the player to ride Groudon in the Cave of Origin.</summary>
        MAGMA_SUIT = 782,
        /// <summary>Allows the player to ride Kyogre in the Cave of Origin. : 	Allows the player to ride Kyogre in the Cave of Origin.</summary>
        AQUA_SUIT = 783,
        /// <summary>Allows the player and their mother to see the star show in the Mossdeep Space Center. : 	Allows the player and their mother to see the star show in the Mossdeep Space Center.</summary>
        PAIR_OF_TICKETS = 784,
        /// <summary>Allows the player's PokÃ©mon to Mega Evolve. : 	Allows the player's PokÃ©mon to Mega Evolve.</summary>
        MEGA_BRACELET = 785,
        /// <summary>Unused.  This is Wally's Key Stone in Omega Ruby and Alpha Sapphire, but it cannot be obtained by the player. : 	Unused NPC Key Stone.</summary>
        MEGA_PENDANT = 786,
        /// <summary>Unused.  This is Maxie's Key Stone in Omega Ruby and Alpha Sapphire, but it cannot be obtained by the player. : 	Unused NPC Key Stone.</summary>
        MEGA_GLASSES = 787,
        /// <summary>Unused.  This is Archie's Key Stone in Omega Ruby and Alpha Sapphire, but it cannot be obtained by the player. : 	Unused NPC Key Stone.</summary>
        MEGA_ANCHOR = 788,
        /// <summary>Unused.  This is Steven's Key Stone in Omega Ruby and Alpha Sapphire, but it cannot be obtained by the player. : 	Unused NPC Key Stone.</summary>
        MEGA_STICKPIN = 789,
        /// <summary>Unused.  This is Lisia's Key Stone in Omega Ruby and Alpha Sapphire, but it cannot be obtained by the player. : 	Unused NPC Key Stone.</summary>
        MEGA_TIARA = 790,
        /// <summary>Unused.  This is Zinnia's Key Stone in Omega Ruby and Alpha Sapphire, but it cannot be obtained by the player. : 	Unused NPC Key Stone.</summary>
        MEGA_ANKLET = 791,
        /// <summary>Held: Allows Swampert to Mega Evolve into Mega Swampert. : 	Held: Allows Swampert to Mega Evolve into Mega Swampert.</summary>
        SWAMPERTITE = 793,
        /// <summary>Held: Allows Sceptile to Mega Evolve into Mega Sceptile. : 	Held: Allows Sceptile to Mega Evolve into Mega Sceptile.</summary>
        SCEPTILITE = 794,
        /// <summary>Held: Allows Sableye to Mega Evolve into Mega Sableye. : 	Held: Allows Sableye to Mega Evolve into Mega Sableye.</summary>
        SABLENITE = 795,
        /// <summary>Held: Allows Altaria to Mega Evolve into Mega Altaria. : 	Held: Allows Altaria to Mega Evolve into Mega Altaria.</summary>
        ALTARIANITE = 796,
        /// <summary>Held: Allows Gallade to Mega Evolve into Mega Gallade. : 	Held: Allows Gallade to Mega Evolve into Mega Gallade.</summary>
        GALLADITE = 797,
        /// <summary>Held: Allows Audino to Mega Evolve into Mega Audino. : 	Held: Allows Audino to Mega Evolve into Mega Audino.</summary>
        AUDINITE = 798,
        /// <summary>Held: Allows Metagross to Mega Evolve into Mega Metagross. : 	Held: Allows Metagross to Mega Evolve into Mega Metagross.</summary>
        METAGROSSITE = 799,
        /// <summary>Held: Allows Sharpedo to Mega Evolve into Mega Sharpedo. : 	Held: Allows Sharpedo to Mega Evolve into Mega Sharpedo.</summary>
        SHARPEDONITE = 800,
        /// <summary>Held: Allows Slowbro to Mega Evolve into Mega Slowbro. : 	Held: Allows Slowbro to Mega Evolve into Mega Slowbro.</summary>
        SLOWBRONITE = 801,
        /// <summary>Held: Allows Steelix to Mega Evolve into Mega Steelix. : 	Held: Allows Steelix to Mega Evolve into Mega Steelix.</summary>
        STEELIXITE = 802,
        /// <summary>Held: Allows Pidgeot to Mega Evolve into Mega Pidgeot. : 	Held: Allows Pidgeot to Mega Evolve into Mega Pidgeot.</summary>
        PIDGEOTITE = 803,
        /// <summary>Held: Allows Glalie to Mega Evolve into Mega Glalie. : 	Held: Allows Glalie to Mega Evolve into Mega Glalie.</summary>
        GLALITITE = 804,
        /// <summary>Held: Allows Diancie to Mega Evolve into Mega Diancie. : 	Held: Allows Diancie to Mega Evolve into Mega Diancie.</summary>
        DIANCITE = 805,
        /// <summary>Transforms Hoopa into its Unbound form for up to three days. : 	Transforms Hoopa into its Unbound form for up to three days.</summary>
        PRISON_BOTTLE = 806,
        /// <summary>Unused.  This appears as the boy player's Mega Bracelet in PokÃ©mon Contests, but it cannot actually be obtained. : 	Unused Key Stone.</summary>
        MEGA_CUFF = 807,
        /// <summary>Held: Allows Camerupt to Mega Evolve into Mega Camerupt. : 	Held: Allows Camerupt to Mega Evolve into Mega Camerupt.</summary>
        CAMERUPTITE = 808,
        /// <summary>Held: Allows Lopunny to Mega Evolve into Mega Lopunny. : 	Held: Allows Lopunny to Mega Evolve into Mega Lopunny.</summary>
        LOPUNNITE = 809,
        /// <summary>Held: Allows Salamence to Mega Evolve into Mega Salamence. : 	Held: Allows Salamence to Mega Evolve into Mega Salamence.</summary>
        SALAMENCITE = 810,
        /// <summary>Held: Allows Beedrill to Mega Evolve into Mega Beedrill. : 	Held: Allows Beedrill to Mega Evolve into Mega Beedrill.</summary>
        BEEDRILLITE = 811,
        /// <summary>Allows the player's PokÃ©mon to Mega Evolve. : 	Allows the player's PokÃ©mon to Mega Evolve.</summary>
        KEY_STONE = 814,
        /// <summary>Causes the Meteorite to transform to its final form, allowing Rayquaza to Mega Evolve. : 	Causes the Meteorite to transform to its final form, allowing Rayquaza to Mega Evolve.</summary>
        METEORITE_SHARD = 815,
        /// <summary>Summons Latias or Latios for a ride. : 	Summons Latias or Latios for a ride.</summary>
        EON_FLUTE = 816,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Normal moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Normal moves.</summary>
        NORMALIUM_Z__HELD = 817,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Fire moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Fire moves.</summary>
        FIRIUM_Z__HELD = 818,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Water moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Water moves.</summary>
        WATERIUM_Z__HELD = 819,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Electric moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Electric moves.</summary>
        ELECTRIUM_Z__HELD = 820,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Grass moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Grass moves.</summary>
        GRASSIUM_Z__HELD = 821,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Ice moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Ice moves.</summary>
        ICIUM_Z__HELD = 822,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Fighting moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Fighting moves.</summary>
        FIGHTINIUM_Z__HELD = 823,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Poison moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Poison moves.</summary>
        POISONIUM_Z__HELD = 824,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Ground moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Ground moves.</summary>
        GROUNDIUM_Z__HELD = 825,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Flying moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Flying moves.</summary>
        FLYINIUM_Z__HELD = 826,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Psychic moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Psychic moves.</summary>
        PSYCHIUM_Z__HELD = 827,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Bug moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Bug moves.</summary>
        BUGINIUM_Z__HELD = 828,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Rock moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Rock moves.</summary>
        ROCKIUM_Z__HELD = 829,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Ghost moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Ghost moves.</summary>
        GHOSTIUM_Z__HELD = 830,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Dragon moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Dragon moves.</summary>
        DRAGONIUM_Z__HELD = 831,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Dark moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Dark moves.</summary>
        DARKINIUM_Z__HELD = 832,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Steel moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Steel moves.</summary>
        STEELIUM_Z__HELD = 833,
        /// <summary>Held: Allows a PokÃ©mon to use the Z-move equivalents of its Fairy moves. : 	Held: Allows a PokÃ©mon to use the Z-move equivalents of its Fairy moves.</summary>
        FAIRIUM_Z__HELD = 834,
        /// <summary>Held: Allows []{pokemon:pikachu} to upgrade []{move:volt-tackle} into []{move:catastropika}. : 	Held: Allows Pikachu to upgrade Volt Tackle into Catastropika.</summary>
        PIKANIUM_Z__HELD = 835,
        /// <summary>Trade to Mr. Hyper to set one of a PokÃ©mon's genes to 31. : 	Trade to Mr. Hyper to maximize one of a PokÃ©mon's genes.</summary>
        BOTTLE_CAP = 836,
        /// <summary>Trade to Mr. Hyper to set all of a PokÃ©mon's genes to 31. : 	Trade to Mr. Hyper to maximize all of a PokÃ©mon's genes.</summary>
        GOLD_BOTTLE_CAP = 837,
        /// <summary>Allows the player's PokÃ©mon to use Z-moves. : 	Allows the player's PokÃ©mon to use Z-moves.</summary>
        Z_RING = 838,
        /// <summary>Held: Allows []{pokemon:decidueye} to upgrade []{move:spirit-shackle} into []{move:sinister-arrow-raid}. : 	Held: Allows Decidueye to upgrade Spirit Shackle into Sinister Arrow Raid.</summary>
        DECIDIUM_Z__HELD = 839,
        /// <summary>Held: Allows []{pokemon:incineroar} to upgrade []{move:darkest-lariat} into []{move:malicious-moonsault}. : 	Held: Allows Incineroar to upgrade Darkest Lariat into Malicious Moonsault.</summary>
        INCINIUM_Z__HELD = 840,
        /// <summary>Held: Allows []{pokemon:primarina} to upgrade []{move:sparkling-aria} into []{move:oceanic-operetta}. : 	Held: Allows Primarina to upgrade Sparkling Aria into Oceanic Operetta.</summary>
        PRIMARIUM_Z__HELD = 841,
        /// <summary>Held: Allows []{pokemon:tapu-koko}, []{pokemon:tapu-lele}, []{pokemon:tapu-bulu}, and []{pokemon:tapu-fini} to upgrade []{move:natures-madness} into []{move:guardian-of-alola}. : 	Held: Allows the Tapus to upgrade Nature's Madness into Guardian of Alola.</summary>
        TAPUNIUM_Z__HELD = 842,
        /// <summary>Held: Allows []{pokemon:marshadow} to upgrade []{move:spectral-thief} into []{move:soul-stealing-7-star-strike}. : 	Held: Allows Marshadow to upgrade Spectral Thief into Soul-Stealing 7 Star Strike.</summary>
        MARSHADIUM_Z__HELD = 843,
        /// <summary>Held: Allows Alola []{pokemon:raichu} to upgrade []{move:thunderbolt} into []{move:stoked-sparksurfer}. : 	Held: Allows Alola Raichu to upgrade Thunderbolt into Stoked Sparksurfer.</summary>
        ALORAICHIUM_Z__HELD = 844,
        /// <summary>Held: Allows []{pokemon:snorlax} to upgrade []{move:giga-impact} into []{move:pulverizing-pancake}. : 	Held: Allows Snorlax to upgrade Giga Impact into Pulverizing Pancake.</summary>
        SNORLIUM_Z__HELD = 845,
        /// <summary>Held: Allows []{pokemon:eevee} to upgrade []{move:last-resort} into []{move:extreme-evoboost}. : 	Held: Allows Eevee to upgrade Last Resort into Extreme Evoboost.</summary>
        EEVIUM_Z__HELD = 846,
        /// <summary>Held: Allows []{pokemon:mew} to upgrade []{move:psychic} into []{move:genesis-supernova}. : 	Held: Allows Mew to upgrade Psychic into Genesis Supernova.</summary>
        MEWNIUM_Z__HELD = 847,
        /// <summary>Held: Allows cap-wearing []{pokemon:pikachu} to upgrade []{move:thunderbolt} into []{move:10-000-000-volt-thunderbolt}. : 	Held: Allows cap-wearing Pikachu to upgrade Thunderbolt into 10,000,000 Volt Thunderbolt.</summary>
        PIKASHUNIUM_Z__HELD = 877,
        /// <summary>Holds ingredients during Mallow's trial. : 	Holds ingredients during Mallow's trial.</summary>
        FORAGE_BAG = 878,
        /// <summary>Allows the player to fish for PokÃ©mon. : 	Allows the player to fish for PokÃ©mon.</summary>
        FISHING_ROD = 879,
        /// <summary>Lost by Professor Kukui. : 	Lost by Professor Kukui.</summary>
        PROFESSORS_MASK = 880,
        /// <summary>Hosts a mission in Festival Plaza. : 	Hosts a mission in Festival Plaza.</summary>
        FESTIVAL_TICKET = 881,
        /// <summary>Required to obtain a Z-Ring. : 	Required to obtain a Z-Ring.</summary>
        SPARKLING_STONE = 882,
        /// <summary>Makes wild PokÃ©mon more likely to summon allies.  Held: increases the holder's Speed by one stage when affected by Intimidate. : 	Makes wild PokÃ©mon more likely to summon allies.  Held: increases the holder's Speed by one stage when affected by Intimidate.</summary>
        ADRENALINE_ORB = 883,
        /// <summary>Contains collected Zygarde cells/cores.  Can teach Zygarde moves. : 	Contains collected Zygarde cells/cores.  Can teach Zygarde moves.</summary>
        ZYGARDE_CUBE = 884,
        /// <summary>Used on a party PokÃ©mon :   Evolves an Alola []{pokemon:sandshrew} into Alola[]{pokemon:sandslash} or an Alola[]{pokemon:vulpix} into Alola[]{pokemon:ninetales}. : 	Evolves an Alola Sandshrew into Alola Sandslash or an Alola Vulpix into Alola Ninetales.</summary>
        ICE_STONE = 885,
        /// <summary>Allows the player to summon a Ride PokÃ©mon.  Unused, as this can be done simply by pressing Y. : 	Allows the player to summon a Ride PokÃ©mon.</summary>
        RIDE_PAGER = 886,
        /// <summary>Used in battle :   Attempts to [catch]{mechanic:catch} a wild PokÃ©mon.If the wild PokÃ©mon is an Ultra Beast, this ball has a catch rate of 5Ã—.  Otherwise, it has a catch rate of 0.1Ã—. If used in a trainer battle, nothing happens and the ball is lost. : 	Tries to catch a wild PokÃ©mon.Success rate is 5Ã— for Ultra Beasts and 0.1Ã— for all other PokÃ©mon.</ summary >
        BEAST_BALL = 887, 
        /// <summary>Cures major status ailments and confusion. : 	Cures major status ailments and confusion.</summary>
        BIG_MALASADA = 888,
        /// <summary>Changes Oricorio to Baile Style.  Single-use and cannot be used in battle. : 	Changes Oricorio to Baile Style.</summary>
        RED_NECTAR = 889,
        /// <summary>Changes Oricorio to Pom-Pom Style.  Single-use and cannot be used in battle. : 	Changes Oricorio to Pom-Pom Style.</summary>
        YELLOW_NECTAR = 890,
        /// <summary>Changes Oricorio to Paâ€™u Style.  Single-use and cannot be used in battle. : 	Changes Oricorio to Paâ€™u Style.</summary>
        PINK_NECTAR = 891,
        /// <summary>Changes Oricorio to Sensu Style.  Single-use and cannot be used in battle. : 	Changes Oricorio to Sensu Style.</summary>
        PURPLE_NECTAR = 892,
        /// <summary>Evolves Nebby into Solgaleo when used at the Altar of the Sunne. : 	Evolves Nebby into Solgaleo when used at the Altar of the Sunne.</summary>
        SUN_FLUTE = 893,
        /// <summary>Evolves Nebby into Lunala when used at the Altar of the Moone. : 	Evolves Nebby into Lunala when used at the Altar of the Moone.</summary>
        MOON_FLUTE = 894,
        /// <summary>Unlocks Looker's motel room on Route 8. : 	Unlocks Looker's motel room on Route 8.</summary>
        ENIGMATIC_CARD = 895,
        /// <summary>Held: When the holder changes the Terrain (whether by move or ability), it will last  8 turns instead of 5. : 	Held: Extends the holder's Terrain effects to 8 turns.</summary>
        TERRAIN_EXTENDER = 896,
        /// <summary>Held: Prevents side effects of contact moves used on the holder. : 	Held: Prevents side effects of contact moves used on the holder.</summary>
        PROTECTIVE_PADS = 897,
        /// <summary>Held: If the holder enters battle during Electric Terrain, or if Electric Terrain is activated while the holder is in battle, this item is consumed and the holder's Defense raises by one stage. : 	Held: Consumed on Electric Terrain and raises the holder's Defense by one stage.</summary>
        ELECTRIC_SEED = 898,
        /// <summary>Held: If the holder enters battle during Psychic Terrain, or if Psychic Terrain is activated while the holder is in battle, this item is consumed and the holder's Special Defense raises by one stage. : 	Held: Consumed on Psychic Terrain and raises the holder's Special Defense by one stage.</summary>
        PSYCHIC_SEED = 899,
        /// <summary>Held: If the holder enters battle during Misty Terrain, or if Misty Terrain is activated while the holder is in battle, this item is consumed and the holder's Special Defense raises by one stage. : 	Held: Consumed on Misty Terrain and raises the holder's Special Defense by one stage.</summary>
        MISTY_SEED = 900,
        /// <summary>Held: If the holder enters battle during Grassy Terrain, or if Grassy Terrain is activated while the holder is in battle, this item is consumed and the holder's Defense raises by one stage. : 	Held: Consumed on Grassy Terrain and raises the holder's Defense by one stage.</summary>
        GRASSY_SEED = 901,
        /// <summary>Held: Changes Silvally to its Fighting form.  Changes Multi-Attack's type to Fighting. : 	Held: Changes Silvally to its Fighting form.  Changes Multi-Attack's type to Fighting.</summary>
        FIGHTING_MEMORY = 902,
        /// <summary>Held: Changes Silvally to its Flying form.  Changes Multi-Attack's type to Flying. : 	Held: Changes Silvally to its Flying form.  Changes Multi-Attack's type to Flying.</summary>
        FLYING_MEMORY = 903,
        /// <summary>Held: Changes Silvally to its Poison form.  Changes Multi-Attack's type to Poison. : 	Held: Changes Silvally to its Poison form.  Changes Multi-Attack's type to Poison.</summary>
        POISON_MEMORY = 904,
        /// <summary>Held: Changes Silvally to its Ground form.  Changes Multi-Attack's type to Ground. : 	Held: Changes Silvally to its Ground form.  Changes Multi-Attack's type to Ground.</summary>
        GROUND_MEMORY = 905,
        /// <summary>Held: Changes Silvally to its Rock form.  Changes Multi-Attack's type to Rock. : 	Held: Changes Silvally to its Rock form.  Changes Multi-Attack's type to Rock.</summary>
        ROCK_MEMORY = 906,
        /// <summary>Held: Changes Silvally to its Bug form.  Changes Multi-Attack's type to Bug. : 	Held: Changes Silvally to its Bug form.  Changes Multi-Attack's type to Bug.</summary>
        BUG_MEMORY = 907,
        /// <summary>Held: Changes Silvally to its Ghost form.  Changes Multi-Attack's type to Ghost. : 	Held: Changes Silvally to its Ghost form.  Changes Multi-Attack's type to Ghost.</summary>
        GHOST_MEMORY = 908,
        /// <summary>Held: Changes Silvally to its Steel form.  Changes Multi-Attack's type to Steel. : 	Held: Changes Silvally to its Steel form.  Changes Multi-Attack's type to Steel.</summary>
        STEEL_MEMORY = 909,
        /// <summary>Held: Changes Silvally to its Fire form.  Changes Multi-Attack's type to Fire. : 	Held: Changes Silvally to its Fire form.  Changes Multi-Attack's type to Fire.</summary>
        FIRE_MEMORY = 910,
        /// <summary>Held: Changes Silvally to its Water form.  Changes Multi-Attack's type to Water. : 	Held: Changes Silvally to its Water form.  Changes Multi-Attack's type to Water.</summary>
        WATER_MEMORY = 911,
        /// <summary>Held: Changes Silvally to its Grass form.  Changes Multi-Attack's type to Grass. : 	Held: Changes Silvally to its Grass form.  Changes Multi-Attack's type to Grass.</summary>
        GRASS_MEMORY = 912,
        /// <summary>Held: Changes Silvally to its Electric form.  Changes Multi-Attack's type to Electric. : 	Held: Changes Silvally to its Electric form.  Changes Multi-Attack's type to Electric.</summary>
        ELECTRIC_MEMORY = 913,
        /// <summary>Held: Changes Silvally to its Psychic form.  Changes Multi-Attack's type to Psychic. : 	Held: Changes Silvally to its Psychic form.  Changes Multi-Attack's type to Psychic.</summary>
        PSYCHIC_MEMORY = 914,
        /// <summary>Held: Changes Silvally to its Ice form.  Changes Multi-Attack's type to Ice. : 	Held: Changes Silvally to its Ice form.  Changes Multi-Attack's type to Ice.</summary>
        ICE_MEMORY = 915,
        /// <summary>Held: Changes Silvally to its Dragon form.  Changes Multi-Attack's type to Dragon. : 	Held: Changes Silvally to its Dragon form.  Changes Multi-Attack's type to Dragon.</summary>
        DRAGON_MEMORY = 916,
        /// <summary>Held: Changes Silvally to its Dark form.  Changes Multi-Attack's type to Dark. : 	Held: Changes Silvally to its Dark form.  Changes Multi-Attack's type to Dark.</summary>
        DARK_MEMORY = 917,
        /// <summary>Held: Changes Silvally to its Fairy form.  Changes Multi-Attack's type to Fairy. : 	Held: Changes Silvally to its Fairy form.  Changes Multi-Attack's type to Fairy.</summary>
        FAIRY_MEMORY = 918,
        /// <summary>XXX new effect for bike--green : 	XXX new effect for bike--green</summary>
        BIKE__GREEN = 919,
        /// <summary>XXX new effect for storage-key--galactic-warehouse : 	XXX new effect for storage-key--galactic-warehouse</summary>
        STORAGE_KEY__GALACTIC_WAREHOUSE = 920,
        /// <summary>XXX new effect for basement-key--goldenrod : 	XXX new effect for basement-key--goldenrod</summary>
        BASEMENT_KEY__GOLDENROD = 921,
        /// <summary>XXX new effect for xtranceiver--red : 	XXX new effect for xtranceiver--red</summary>
        XTRANCEIVER__RED = 922,
        /// <summary>XXX new effect for xtranceiver--yellow : 	XXX new effect for xtranceiver--yellow</summary>
        XTRANCEIVER__YELLOW = 923,
        /// <summary>XXX new effect for dna-splicers--merge : 	XXX new effect for dna-splicers--merge</summary>
        DNA_SPLICERS__MERGE = 924,
        /// <summary>XXX new effect for dna-splicers--split : 	XXX new effect for dna-splicers--split</summary>
        DNA_SPLICERS__SPLIT = 925,
        /// <summary>XXX new effect for dropped-item--red : 	XXX new effect for dropped-item--red</summary>
        DROPPED_ITEM__RED = 926,
        /// <summary>XXX new effect for dropped-item--yellow : 	XXX new effect for dropped-item--yellow</summary>
        DROPPED_ITEM__YELLOW = 927,
        /// <summary>XXX new effect for holo-caster--green : 	XXX new effect for holo-caster--green</summary>
        HOLO_CASTER__GREEN = 928,
        /// <summary>XXX new effect for bike--yellow : 	XXX new effect for bike--yellow</summary>
        BIKE__YELLOW = 929,
        /// <summary>XXX new effect for holo-caster--red : 	XXX new effect for holo-caster--red</summary>
        HOLO_CASTER__RED = 930,
        /// <summary>XXX new effect for basement-key--new-mauville : 	XXX new effect for basement-key--new-mauville</summary>
        BASEMENT_KEY__NEW_MAUVILLE = 931,
        /// <summary>XXX new effect for storage-key--sea-mauville : 	XXX new effect for storage-key--sea-mauville</summary>
        STORAGE_KEY__SEA_MAUVILLE = 932,
        /// <summary>XXX new effect for ss-ticket--hoenn : 	XXX new effect for ss-ticket--hoenn</summary>
        SS_TICKET__HOENN = 933,
        /// <summary>XXX new effect for contest-costume--dress : 	XXX new effect for contest-costume--dress</summary>
        CONTEST_COSTUME__DRESS = 934,
        /// <summary>XXX new effect for meteorite--2 : 	XXX new effect for meteorite--2</summary>
        METEORITE__2 = 935,
        /// <summary>XXX new effect for meteorite--3 : 	XXX new effect for meteorite--3</summary>
        METEORITE__3 = 936,
        /// <summary>XXX new effect for meteorite--4 : 	XXX new effect for meteorite--4</summary>
        METEORITE__4 = 937,
        /// <summary>XXX new effect for normalium-z--bag : 	XXX new effect for normalium-z--bag</summary>
        NORMALIUM_Z__BAG = 938,
        /// <summary>XXX new effect for firium-z--bag : 	XXX new effect for firium-z--bag</summary>
        FIRIUM_Z__BAG = 939,
        /// <summary>XXX new effect for waterium-z--bag : 	XXX new effect for waterium-z--bag</summary>
        WATERIUM_Z__BAG = 940,
        /// <summary>XXX new effect for electrium-z--bag : 	XXX new effect for electrium-z--bag</summary>
        ELECTRIUM_Z__BAG = 941,
        /// <summary>XXX new effect for grassium-z--bag : 	XXX new effect for grassium-z--bag</summary>
        GRASSIUM_Z__BAG = 942,
        /// <summary>XXX new effect for icium-z--bag : 	XXX new effect for icium-z--bag</summary>
        ICIUM_Z__BAG = 943,
        /// <summary>XXX new effect for fightinium-z--bag : 	XXX new effect for fightinium-z--bag</summary>
        FIGHTINIUM_Z__BAG = 944,
        /// <summary>XXX new effect for poisonium-z--bag : 	XXX new effect for poisonium-z--bag</summary>
        POISONIUM_Z__BAG = 945,
        /// <summary>XXX new effect for groundium-z--bag : 	XXX new effect for groundium-z--bag</summary>
        GROUNDIUM_Z__BAG = 946,
        /// <summary>XXX new effect for flyinium-z--bag : 	XXX new effect for flyinium-z--bag</summary>
        FLYINIUM_Z__BAG = 947,
        /// <summary>XXX new effect for psychium-z--bag : 	XXX new effect for psychium-z--bag</summary>
        PSYCHIUM_Z__BAG = 948,
        /// <summary>XXX new effect for buginium-z--bag : 	XXX new effect for buginium-z--bag</summary>
        BUGINIUM_Z__BAG = 949,
        /// <summary>XXX new effect for rockium-z--bag : 	XXX new effect for rockium-z--bag</summary>
        ROCKIUM_Z__BAG = 950,
        /// <summary>XXX new effect for ghostium-z--bag : 	XXX new effect for ghostium-z--bag</summary>
        GHOSTIUM_Z__BAG = 951,
        /// <summary>XXX new effect for dragonium-z--bag : 	XXX new effect for dragonium-z--bag</summary>
        DRAGONIUM_Z__BAG = 952,
        /// <summary>XXX new effect for darkinium-z--bag : 	XXX new effect for darkinium-z--bag</summary>
        DARKINIUM_Z__BAG = 953,
        /// <summary>XXX new effect for steelium-z--bag : 	XXX new effect for steelium-z--bag</summary>
        STEELIUM_Z__BAG = 954,
        /// <summary>XXX new effect for fairium-z--bag : 	XXX new effect for fairium-z--bag</summary>
        FAIRIUM_Z__BAG = 955,
        /// <summary>XXX new effect for pikanium-z--bag : 	XXX new effect for pikanium-z--bag</summary>
        PIKANIUM_Z__BAG = 956,
        /// <summary>XXX new effect for decidium-z--bag : 	XXX new effect for decidium-z--bag</summary>
        DECIDIUM_Z__BAG = 957,
        /// <summary>XXX new effect for incinium-z--bag : 	XXX new effect for incinium-z--bag</summary>
        INCINIUM_Z__BAG = 958,
        /// <summary>XXX new effect for primarium-z--bag : 	XXX new effect for primarium-z--bag</summary>
        PRIMARIUM_Z__BAG = 959,
        /// <summary>XXX new effect for tapunium-z--bag : 	XXX new effect for tapunium-z--bag</summary>
        TAPUNIUM_Z__BAG = 960,
        /// <summary>XXX new effect for marshadium-z--bag : 	XXX new effect for marshadium-z--bag</summary>
        MARSHADIUM_Z__BAG = 961,
        /// <summary>XXX new effect for aloraichium-z--bag : 	XXX new effect for aloraichium-z--bag</summary>
        ALORAICHIUM_Z__BAG = 962,
        /// <summary>XXX new effect for snorlium-z--bag : 	XXX new effect for snorlium-z--bag</summary>
        SNORLIUM_Z__BAG = 963,
        /// <summary>XXX new effect for eevium-z--bag : 	XXX new effect for eevium-z--bag</summary>
        EEVIUM_Z__BAG = 964,
        /// <summary>XXX new effect for mewnium-z--bag : 	XXX new effect for mewnium-z--bag</summary>
        MEWNIUM_Z__BAG = 965,
        /// <summary>XXX new effect for pikashunium-z--bag : 	XXX new effect for pikashunium-z--bag</summary>
        PIKASHUNIUM_Z__BAG = 966,
        /// <summary>XXX new effect for solganium-z--held : 	XXX new effect for solganium-z--held</summary>
        SOLGANIUM_Z__HELD = 967,
        /// <summary>XXX new effect for lunalium-z--held : 	XXX new effect for lunalium-z--held</summary>
        LUNALIUM_Z__HELD = 968,
        /// <summary>XXX new effect for ultranecrozium-z--held : 	XXX new effect for ultranecrozium-z--held</summary>
        ULTRANECROZIUM_Z__HELD = 969,
        /// <summary>XXX new effect for mimikium-z--held : 	XXX new effect for mimikium-z--held</summary>
        MIMIKIUM_Z__HELD = 970,
        /// <summary>XXX new effect for lycanium-z--held : 	XXX new effect for lycanium-z--held</summary>
        LYCANIUM_Z__HELD = 971,
        /// <summary>XXX new effect for kommonium-z--held : 	XXX new effect for kommonium-z--held</summary>
        KOMMONIUM_Z__HELD = 972,
        /// <summary>XXX new effect for solganium-z--bag : 	XXX new effect for solganium-z--bag</summary>
        SOLGANIUM_Z__BAG = 973,
        /// <summary>XXX new effect for lunalium-z--bag : 	XXX new effect for lunalium-z--bag</summary>
        LUNALIUM_Z__BAG = 974,
        /// <summary>XXX new effect for ultranecrozium-z--bag : 	XXX new effect for ultranecrozium-z--bag</summary>
        ULTRANECROZIUM_Z__BAG = 975,
        /// <summary>XXX new effect for mimikium-z--bag : 	XXX new effect for mimikium-z--bag</summary>
        MIMIKIUM_Z__BAG = 976,
        /// <summary>XXX new effect for lycanium-z--bag : 	XXX new effect for lycanium-z--bag</summary>
        LYCANIUM_Z__BAG = 977,
        /// <summary>XXX new effect for kommonium-z--bag : 	XXX new effect for kommonium-z--bag</summary>
        KOMMONIUM_Z__BAG = 978,
        /// <summary>XXX new effect for z-power-ring : 	XXX new effect for z-power-ring</summary>
        Z_POWER_RING = 979,
        /// <summary>XXX new effect for pink-petal : 	XXX new effect for pink-petal</summary>
        PINK_PETAL = 980,
        /// <summary>XXX new effect for orange-petal : 	XXX new effect for orange-petal</summary>
        ORANGE_PETAL = 981,
        /// <summary>XXX new effect for blue-petal : 	XXX new effect for blue-petal</summary>
        BLUE_PETAL = 982,
        /// <summary>XXX new effect for red-petal : 	XXX new effect for red-petal</summary>
        RED_PETAL = 983,
        /// <summary>XXX new effect for green-petal : 	XXX new effect for green-petal</summary>
        GREEN_PETAL = 984,
        /// <summary>XXX new effect for yellow-petal : 	XXX new effect for yellow-petal</summary>
        YELLOW_PETAL = 985,
        /// <summary>XXX new effect for purple-petal : 	XXX new effect for purple-petal</summary>
        PURPLE_PETAL = 986,
        /// <summary>XXX new effect for rainbow-flower : 	XXX new effect for rainbow-flower</summary>
        RAINBOW_FLOWER = 987,
        /// <summary>XXX new effect for surge-badge : 	XXX new effect for surge-badge</summary>
        SURGE_BADGE = 988,
        /// <summary>XXX new effect for n-solarizer--merge : 	XXX new effect for n-solarizer--merge</summary>
        N_SOLARIZER__MERGE = 989,
        /// <summary>XXX new effect for n-lunarizer--merge : 	XXX new effect for n-lunarizer--merge</summary>
        N_LUNARIZER__MERGE = 990,
        /// <summary>XXX new effect for n-solarizer--split : 	XXX new effect for n-solarizer--split</summary>
        N_SOLARIZER__SPLIT = 991,
        /// <summary>XXX new effect for n-lunarizer--split : 	XXX new effect for n-lunarizer--split</summary>
        N_LUNARIZER__SPLIT = 992,
        /// <summary>XXX new effect for ilimas-normalium-z : 	XXX new effect for ilimas-normalium-z</summary>
        ILIMAS_NORMALIUM_Z = 993,
        /// <summary>XXX new effect for left-poke-ball : 	XXX new effect for left-poke-ball</summary>
        LEFT_POKE_BALL = 994,
        /// <summary>XXX new effect for roto-hatch : 	XXX new effect for roto-hatch</summary>
        ROTO_HATCH = 995,
        /// <summary>XXX new effect for roto-bargain : 	XXX new effect for roto-bargain</summary>
        ROTO_BARGAIN = 996,
        /// <summary>XXX new effect for roto-prize-money : 	XXX new effect for roto-prize-money</summary>
        ROTO_PRIZE_MONEY = 997,
        /// <summary>XXX new effect for roto-exp-points : 	XXX new effect for roto-exp-points</summary>
        ROTO_EXP_POINTS = 998,
        /// <summary>XXX new effect for roto-friendship : 	XXX new effect for roto-friendship</summary>
        ROTO_FRIENDSHIP = 999,
        /// <summary>XXX new effect for roto-encounter : 	XXX new effect for roto-encounter</summary>
        ROTO_ENCOUNTER = 1000,
        /// <summary>XXX new effect for roto-stealth : 	XXX new effect for roto-stealth</summary>
        ROTO_STEALTH = 1001,
        /// <summary>XXX new effect for roto-hp-restore : 	XXX new effect for roto-hp-restore</summary>
        ROTO_HP_RESTORE = 1002,
        /// <summary>XXX new effect for roto-pp-restore : 	XXX new effect for roto-pp-restore</summary>
        ROTO_PP_RESTORE = 1003,
        /// <summary>XXX new effect for roto-boost : 	XXX new effect for roto-boost</summary>
        ROTO_BOOST = 1004,
        /// <summary>XXX new effect for roto-catch : 	XXX new effect for roto-catch</summary>
        ROTO_CATCH = 1005
    }

    public enum ItemPockets
    {
        MISC = 1,
        MEDICINE = 2,
        POKEBALL = 3,
        /// <summary>
        /// TMs
        /// </summary>
        MACHINE = 4, 
        BERRY = 5,
        MAIL = 6,
        BATTLE = 7,
        /// <summary>
        /// Items that are not 'stackable' and therefore should take up 1 individual item spot per (if multiples)
        /// Or possibly limit and restrict to one per user
        /// </summary>
        KEY = 8
    }

    /// <summary>
    /// </summary>
    public enum ItemFlags
    {
        /// <summary>
        /// Has a count in the bag
        /// </summary>
        COUNTABLE = 1,
        /// <summary>
        /// Consumed when used
        /// </summary>
        CONSUMABLE = 2,
        /// <summary>
        /// Usable outside battle
        /// </summary>
        USEABLE_OVERWORLD = 3,
        /// <summary>
        /// Usable in battle
        /// </summary>
        USEABLE_IN_BATTLE = 4,
        /// <summary>
        /// Can be held by a pokemon
        /// </summary>
        HOLDABLE = 5,
        /// <summary>
        /// Works passively when held
        /// </summary>
        HOLDABLE_PASSIVE = 6,
        /// <summary>
        /// Usable by a pokemon when held
        /// </summary>
        HOLDABLE_ACTIVE = 7,
        /// <summary>
        /// Appears in Sinnoh Underground
        /// </summary>
        UNDERGROUND = 8
    }

    /// <summary>
    /// Item Category determines both the item's effect
    /// and the bag-pocket that the item belongs to.
    /// </summary>
    /// <remarks>
    /// Can determine an <see cref="itemEffect"/> by the category it belongs to.
    /// </remarks>
    public enum ItemCategory
    {
		COLLECTIBLES = 9, //PocketId = 1
		EVOLUTION = 10, //PocketId = 1
		SPELUNKING = 11, //PocketId = 1
		HELD_ITEMS = 12, //PocketId = 1
		CHOICE = 13, //PocketId = 1
		EFFORT_TRAINING = 14, //PocketId = 1
		BAD_HELD_ITEMS = 15, //PocketId = 1
		TRAINING = 16, //PocketId = 1
		PLATES = 17, //PocketId = 1
		SPECIES_SPECIFIC = 18, //PocketId = 1
		TYPE_ENHANCEMENT = 19, //PocketId = 1
		LOOT = 24, //PocketId = 1
		MULCH = 32, //PocketId = 1
		DEX_COMPLETION = 35, //PocketId = 1
		SCARVES = 36, //PocketId = 1
		JEWELS = 42, //PocketId = 1
		MEGA_STONES = 44, //PocketId = 1

		VITAMINS = 26, //PocketId = 2
		HEALING = 27, //PocketId = 2
		PP_RECOVERY = 28, //PocketId = 2
		REVIVAL = 29, //PocketId = 2
		STATUS_CURES = 30, //PocketId = 2

		SPECIAL_BALLS = 33, //PocketId = 3
		STANDARD_BALLS = 34, //PocketId = 3
		APRICORN_BALLS = 39, //PocketId = 3

		ALL_MACHINES = 37, //PocketId = 4

		EFFORT_DROP = 2, //PocketId = 5
		MEDICINE = 3, //PocketId = 5
		OTHER = 4, //PocketId = 5
		IN_A_PINCH = 5, //PocketId = 5
		PICKY_HEALING = 6, //PocketId = 5
		TYPE_PROTECTION = 7, //PocketId = 5
		BAKING_ONLY = 8, //PocketId = 5

		ALL_MAIL = 25, //PocketId = 6

		STAT_BOOSTS = 1, //PocketId = 7
		FLUTES = 38, //PocketId = 7
		MIRACLE_SHOOTER = 43, //PocketId = 7

		EVENT_ITEMS = 20, //PocketId = 8
		GAMEPLAY = 21, //PocketId = 8
		PLOT_ADVANCEMENT = 22, //PocketId = 8
		UNUSED = 23, //PocketId = 8
		APRICORN_BOX = 40, //PocketId = 8
		DATA_CARDS = 41, //PocketId = 8
		XY_UNKNOWN = 10001, //PocketId = 8
    }

    /// <summary>
    /// Effects that occur when items are thrown at target.
    /// Not all items can be thrown(?)...
    /// </summary>
    /// <remarks>Didnt have access to variable names...</remarks>
    public enum ItemFlingEffect
    {
        /// <summary>
        /// Badly poisons the target.
        /// </summary>
        One = 1,
        /// <summary>
        /// Burns the target.
        /// </summary>
        Two = 2,
        /// <summary>
        /// Immediately activates the berry's effect on the target.
        /// </summary>
        Three = 3,
        /// <summary>
        /// Immediately activates the herb's effect on the target.
        /// </summary>
        Four = 4, 
        /// <summary>
        /// Paralyzes the target.
        /// </summary>
        Five = 5,
        /// <summary>
        /// Poisons the target.
        /// </summary>
        Six = 6,
        /// <summary>
        /// Target will flinch if it has not yet gone this turn.
        /// </summary>
        Seven = 7
    }

}