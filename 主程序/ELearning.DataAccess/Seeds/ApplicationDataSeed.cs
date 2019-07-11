
using ELearning.Entities;
using ELearning.ORM.SqlServer;
using ELearning.UserAndRole;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DataAccess.Seeds
{
    public static class ApplicationDataSeed
    {
        static SqlServerDbContext _dbContext;

        //static RoleManager<ApplicationRole> ApplicationRoles;
        //static UserManager<ApplicationUser> ApplicationUsers;
        public static void ForEntities(SqlServerDbContext context)
        {
            _dbContext = context;
             //Seed();
            //await ForRolesAndUsers(ApplicationRoles, ApplicationUsers);

            //_ForOrganAndJobTitle(); 
            //_ForDepartmentAndEmployeeAndStudent();

        }

        /// <summary>
        /// 用户组
        /// </summary>
        public static async Task ForRolesAndUsers(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            //#region 创建角色
            //var role1 = new ApplicationRole()
            //{
            //    Name = "普通注册用户",
            //    DisplayName = "普通注册用户",
            //    Synopsis = "具备普通注册用户数据处理的用户组。",

            //    ApplicationRoleType = ApplicationRoleTypeEnum.适用于普通注册用户,
            //    IsDefaultRole = true
            //};

            //var role2 = new ApplicationRole() { Name = "小编", DisplayName = "小编", Synopsis = "具备发布活动，发布，推荐游记攻略。 ", ApplicationRoleType = ApplicationRoleTypeEnum.适用于小编, IsDefaultRole = true };
            //var role3 = new ApplicationRole() { Name = "景区管理用户", DisplayName = "景区管理用户", Synopsis = "对景区的数据维护。", ApplicationRoleType = ApplicationRoleTypeEnum.适用于景区数据管理员, IsDefaultRole = true };
            //var role4 = new ApplicationRole() { Name = "社区管理用户", DisplayName = "社区管理用户", Synopsis = "对游记与攻略的数据维护。", ApplicationRoleType = ApplicationRoleTypeEnum.适用于社区数据管理员, IsDefaultRole = true };

            //await roleManager.CreateAsync(role1);
            //await roleManager.CreateAsync(role2);
            //await roleManager.CreateAsync(role3);
            //await roleManager.CreateAsync(role4);

            //#endregion

            #region 创建普通用户
            //for (int i = 0; i < 200; i++)
            //{
            //    var counterString = i.ToString();
            //    if (i < 10)
            //        counterString = "00" + i.ToString();
            //    if (i >= 10 && i < 100)
            //        counterString = "0" + i.ToString();

            //    var normalUser = new ApplicationUser()
            //    {
            //        UserName = "normal" + counterString,



            //        Phone = 13988888888,
            //        Email = "normal" + counterString + "@hotmail.com",
            //        LockoutEnabled = false
            //    };

            //    userManager.CreateAsync(normalUser, "123@Abc");
            //    userManager.AddToRoleAsync(normalUser, "普通注册用户");
            //    _dbContext.SaveChanges();
            //}


            #endregion

            #region 创建小编
            var systemAdministrator = new ApplicationUser()
            {
                UserName = "admin",
                Name = "李丽丽",
                Sex = true,
                Phone = 13617808332,
                Email = "admin@qq.com",

            };

            await userManager.CreateAsync(systemAdministrator, "123456");
            await userManager.AddToRoleAsync(systemAdministrator, "小编用户");

            #endregion

            #region 创建景区管理用户
            var informationIssuer = new ApplicationUser()
            {
                UserName = "issuer",
                Name = "薇薇",
                Phone = 13617808232,
                Email = "issuer@hotmail.com"
            };

            await userManager.CreateAsync(informationIssuer, "123@Abc");
            await userManager.AddToRoleAsync(informationIssuer, "景区管理用户");

            #endregion

            _dbContext.SaveChanges();

        }
        //种子
        public static void Seed()
        {
            //城市
            var city = new List<City>
            {

                new City(){CityName="北京市",Province="北京" },
                new City(){CityName="天津市",Province="天津" },
                new City(){CityName="石家庄市",Province="河北" },
                new City(){CityName="唐山市",Province="河北" },
                new City(){CityName="秦皇岛市",Province="河北" },
                new City(){CityName="邯郸市",Province="河北" },
                new City(){CityName="邢台市",Province="河北" },
                new City(){CityName="保定市",Province="河北" },
                new City(){CityName="张家口市",Province="河北" },
                new City(){CityName="承德市",Province="河北" },
                new City(){CityName="沧州市",Province="河北" },
                new City(){CityName="廊坊市",Province="河北" },
                new City(){CityName="衡水市",Province="河北" },
                new City(){CityName="太原市",Province="山西" },
                new City(){CityName="大同市",Province="山西" },
                new City(){CityName="阳泉市",Province="山西" },
                new City(){CityName="长治市",Province="山西" },
                new City(){CityName="晋城市",Province="山西" },
                new City(){CityName="朔州市",Province="山西" },
                new City(){CityName="忻州市",Province="山西" },
                new City(){CityName="吕梁市",Province="山西" },
                new City(){CityName="晋中市",Province="山西" },
                new City(){CityName="临汾市",Province="山西" },
                new City(){CityName="运城市",Province="山西" },
                new City(){CityName="呼和浩特市",Province="内蒙古" },
                new City(){CityName="包头市",Province="内蒙古" },
                new City(){CityName="乌海市",Province="内蒙古" },
                new City(){CityName="赤峰市",Province="内蒙古" },
                new City(){CityName="呼伦贝尔市",Province="内蒙古" },
                new City(){CityName="兴安盟",Province="内蒙古" },
                new City(){CityName="通辽市",Province="内蒙古" },
                new City(){CityName="锡林郭勒盟",Province="内蒙古" },
                new City(){CityName="乌兰察布市",Province="内蒙古" },
                new City(){CityName="鄂尔多斯市",Province="内蒙古" },
                new City(){CityName="巴彦淖尔市",Province="内蒙古" },
                new City(){CityName="阿拉善盟",Province="内蒙古" },
                new City(){CityName="沈阳市",Province="辽宁" },
                new City(){CityName="大连市",Province="辽宁" },
                new City(){CityName="鞍山市",Province="辽宁" },
                new City(){CityName="抚顺市",Province="辽宁" },
                new City(){CityName="本溪市",Province="辽宁" },
                new City(){CityName="丹东市",Province="辽宁" },
                new City(){CityName="锦州市",Province="辽宁" },
                new City(){CityName="营口市",Province="辽宁" },
                new City(){CityName="阜新市",Province="辽宁" },
                new City(){CityName="辽阳市",Province="辽宁" },
                new City(){CityName="盘锦市",Province="辽宁" },
                new City(){CityName="铁岭市",Province="辽宁" },
                new City(){CityName="朝阳市",Province="辽宁" },
                new City(){CityName="葫芦岛市",Province="辽宁" },
                new City(){CityName="长春市",Province="吉林" },
                new City(){CityName="吉林市",Province="吉林" },
                new City(){CityName="四平市",Province="吉林" },
                new City(){CityName="辽源市",Province="吉林" },
                new City(){CityName="通化市",Province="吉林" },
                new City(){CityName="白山市",Province="吉林" },
                new City(){CityName="松原市",Province="吉林" },
                new City(){CityName="白城市",Province="吉林" },
                new City(){CityName="延边朝鲜族自治州",Province="吉林" },
                new City(){CityName="哈尔滨市",Province="黑龙江" },
                new City(){CityName="齐齐哈尔市",Province="黑龙江" },
                new City(){CityName="鸡西市",Province="黑龙江" },
                new City(){CityName="鹤岗市",Province="黑龙江" },
                new City(){CityName="双鸭山市",Province="黑龙江" },
                new City(){CityName="大庆市",Province="黑龙江" },
                new City(){CityName="伊春市",Province="黑龙江" },
                new City(){CityName="佳木斯市",Province="黑龙江" },
                new City(){CityName="七台河市",Province="黑龙江" },
                new City(){CityName="牡丹江市",Province="黑龙江" },
                new City(){CityName="黑河市",Province="黑龙江" },
                new City(){CityName="绥化市",Province="黑龙江" },
                new City(){CityName="大兴安岭地区",Province="黑龙江" },
                new City(){CityName="上海市",Province="上海市" },
                new City(){CityName="南京市",Province="江苏" },
                new City(){CityName="无锡市",Province="江苏" },
                new City(){CityName="徐州市",Province="江苏" },
                new City(){CityName="常州市",Province="江苏" },
                new City(){CityName="苏州市",Province="江苏" },
                new City(){CityName="南通市",Province="江苏" },
                new City(){CityName="连云港市",Province="江苏" },
                new City(){CityName="淮安市",Province="江苏" },
                new City(){CityName="盐城市",Province="江苏" },
                new City(){CityName="扬州市",Province="江苏" },
                new City(){CityName="镇江市",Province="江苏" },
                new City(){CityName="泰州市",Province="江苏" },
                new City(){CityName="宿迁市",Province="江苏" },
                new City(){CityName="杭州市",Province="浙江" },
                new City(){CityName="宁波市",Province="浙江" },
                new City(){CityName="温州市",Province="浙江" },
                new City(){CityName="嘉兴市",Province="浙江" },
                new City(){CityName="湖州市",Province="浙江" },
                new City(){CityName="绍兴市",Province="浙江" },
                new City(){CityName="金华市",Province="浙江" },
                new City(){CityName="衢州市",Province="浙江" },
                new City(){CityName="舟山市",Province="浙江" },
                new City(){CityName="台州市",Province="浙江" },
                new City(){CityName="丽水市",Province="浙江" },
                new City(){CityName="合肥市",Province="安徽" },
                new City(){CityName="芜湖市",Province="安徽" },
                new City(){CityName="蚌埠市",Province="安徽" },
                new City(){CityName="淮南市",Province="安徽" },
                new City(){CityName="马鞍山市",Province="安徽" },
                new City(){CityName="淮北市",Province="安徽" },
                new City(){CityName="铜陵市",Province="安徽" },
                new City(){CityName="安庆市",Province="安徽" },
                new City(){CityName="黄山市",Province="安徽" },
                new City(){CityName="滁州市",Province="安徽" },
                new City(){CityName="阜阳市",Province="安徽" },
                new City(){CityName="宿州市",Province="安徽" },
                new City(){CityName="六安市",Province="安徽" },
                new City(){CityName="宣城市",Province="安徽" },
                new City(){CityName="亳州市",Province="安徽" },
                new City(){CityName="池州市",Province="安徽" },
                new City(){CityName="福州市",Province="福建" },
                new City(){CityName="厦门市",Province="福建" },
                new City(){CityName="宁德市",Province="福建" },
                new City(){CityName="莆田市",Province="福建" },
                new City(){CityName="泉州市",Province="福建" },
                new City(){CityName="漳州市",Province="福建" },
                new City(){CityName="龙岩",Province="福建" },
                new City(){CityName="三明市",Province="福建" },
                new City(){CityName="南平市",Province="福建" },
                new City(){CityName="南昌市",Province="江西" },
                new City(){CityName="景德镇市",Province="江西" },
                new City(){CityName="萍乡市",Province="江西" },
                new City(){CityName="九江市",Province="江西" },
                new City(){CityName="新余市",Province="江西" },
                new City(){CityName="鹰潭市",Province="江西" },
                new City(){CityName="赣州市",Province="江西" },
                new City(){CityName="宜春市",Province="江西" },
                new City(){CityName="上饶市",Province="江西" },
                new City(){CityName="吉安市",Province="江西" },
                new City(){CityName="抚州市",Province="江西" },
                new City(){CityName="济南市",Province="山东" },
                new City(){CityName="青岛市",Province="山东" },
                new City(){CityName="淄博市",Province="山东" },
                new City(){CityName="枣庄市",Province="山东" },
                new City(){CityName="东营市",Province="山东" },
                new City(){CityName="烟台市",Province="山东" },
                new City(){CityName="潍坊市",Province="山东" },
                new City(){CityName="济宁市",Province="山东" },
                new City(){CityName="泰安市",Province="山东" },
                new City(){CityName="威海市",Province="山东" },
                new City(){CityName="日照市",Province="山东" },
                new City(){CityName="莱芜市",Province="山东" },
                new City(){CityName="临沂市",Province="山东" },
                new City(){CityName="德州市",Province="山东" },
                new City(){CityName="聊城市",Province="山东" },
                new City(){CityName="滨州市",Province="山东" },
                new City(){CityName="菏泽市",Province="山东" },
                new City(){CityName="郑州市",Province="河南" },
                new City(){CityName="开封市",Province="河南" },
                new City(){CityName="洛阳市",Province="河南" },
                new City(){CityName="平顶山市",Province="河南" },
                new City(){CityName="安阳市",Province="河南" },
                new City(){CityName="鹤壁市",Province="河南" },
                new City(){CityName="新乡市",Province="河南" },
                new City(){CityName="焦作市",Province="河南" },
                new City(){CityName="濮阳市",Province="河南" },
                new City(){CityName="许昌市",Province="河南" },
                new City(){CityName="漯河市",Province="河南" },
                new City(){CityName="三门峡市",Province="河南" },
                new City(){CityName="南阳市",Province="河南" },
                new City(){CityName="商丘市",Province="河南" },
                new City(){CityName="信阳市",Province="河南" },
                new City(){CityName="周口市",Province="河南" },
                new City(){CityName="驻马店地区",Province="河南" },
                new City(){CityName="直辖行政单位",Province="河南" },
                new City(){CityName="武汉市",Province="湖北" },
                new City(){CityName="黄石市",Province="湖北" },
                new City(){CityName="十堰市",Province="湖北" },
                new City(){CityName="宜昌市",Province="湖北" },
                new City(){CityName="襄阳市",Province="湖北" },
                new City(){CityName="鄂州市",Province="湖北" },
                new City(){CityName="荆门市",Province="湖北" },
                new City(){CityName="孝感市",Province="湖北" },
                new City(){CityName="荆州市",Province="湖北" },
                new City(){CityName="黄冈市",Province="湖北" },
                new City(){CityName="咸宁市",Province="湖北" },
                new City(){CityName="恩施土家族苗族自治州",Province="湖北" },
                new City(){CityName="随州市",Province="湖北" },
                new City(){CityName="直辖行政单位",Province="湖北" },
                new City(){CityName="长沙市",Province="湖南" },
                new City(){CityName="株洲市",Province="湖南" },
                new City(){CityName="湘潭市",Province="湖南" },
                new City(){CityName="衡阳市",Province="湖南" },
                new City(){CityName="邵阳市",Province="湖南" },
                new City(){CityName="岳阳市",Province="湖南" },
                new City(){CityName="常德市",Province="湖南" },
                new City(){CityName="张家界市",Province="湖南" },
                new City(){CityName="益阳市",Province="湖南" },
                new City(){CityName="郴州市",Province="湖南" },
                new City(){CityName="永州市",Province="湖南" },
                new City(){CityName="怀化市",Province="湖南" },
                new City(){CityName="娄底地区",Province="湖南" },
                new City(){CityName="湘西土家族苗族自治州",Province="湖南" },
                new City(){CityName="广州市",Province="广东" },
                new City(){CityName="韶关市",Province="广东" },
                new City(){CityName="深圳市",Province="广东" },
                new City(){CityName="珠海市",Province="广东" },
                new City(){CityName="汕头市",Province="广东" },
                new City(){CityName="佛山市",Province="广东" },
                new City(){CityName="江门市",Province="广东" },
                new City(){CityName="湛江市",Province="广东" },
                new City(){CityName="茂名市",Province="广东" },
                new City(){CityName="肇庆市",Province="广东" },
                new City(){CityName="惠州市",Province="广东" },
                new City(){CityName="梅州市",Province="广东" },
                new City(){CityName="汕尾市",Province="广东" },
                new City(){CityName="河源市",Province="广东" },
                new City(){CityName="阳江市",Province="广东" },
                new City(){CityName="清远市",Province="广东" },
                new City(){CityName="东莞市",Province="广东" },
                new City(){CityName="中山市",Province="广东" },
                new City(){CityName="潮州市",Province="广东" },
                new City(){CityName="揭阳市",Province="广东" },
                new City(){CityName="云浮市",Province="广东" },
                new City(){CityName="南宁市",Province="广西" },
                new City(){CityName="柳州市",Province="广西" },
                new City(){CityName="桂林市",Province="广西" },
                new City(){CityName="梧州市",Province="广西" },
                new City(){CityName="北海市",Province="广西" },
                new City(){CityName="防城港市",Province="广西" },
                new City(){CityName="钦州市",Province="广西" },
                new City(){CityName="贵港市",Province="广西" },
                new City(){CityName="玉林市",Province="广西" },
                new City(){CityName="崇左市",Province="广西" },
                new City(){CityName="来宾市",Province="广西" },
                new City(){CityName="贺州市",Province="广西" },
                new City(){CityName="百色市",Province="广西" },
                new City(){CityName="河池市",Province="广西" },
                new City(){CityName="直辖县级行政单位",Province="海南" },
                new City(){CityName="海口市",Province="海南" },
                new City(){CityName="三亚市",Province="海南" },
                new City(){CityName="儋州市",Province="海南" },
                new City(){CityName="三沙市",Province="海南" },
                new City(){CityName="d",Province="重庆市" },
                new City(){CityName="成都市",Province="四川" },
                new City(){CityName="自贡市",Province="四川" },
                new City(){CityName="攀枝花市",Province="四川" },
                new City(){CityName="泸州市",Province="四川" },
                new City(){CityName="德阳市",Province="四川" },
                new City(){CityName="绵阳市",Province="四川" },
                new City(){CityName="广元市",Province="四川" },
                new City(){CityName="遂宁市",Province="四川" },
                new City(){CityName="内江市",Province="四川" },
                new City(){CityName="乐山市",Province="四川" },
                new City(){CityName="南充市",Province="四川" },
                new City(){CityName="宜宾市",Province="四川" },
                new City(){CityName="广安市",Province="四川" },
                new City(){CityName="达州市",Province="四川" },
                new City(){CityName="雅安市",Province="四川" },
                new City(){CityName="阿坝藏族羌族自治州",Province="四川" },
                new City(){CityName="甘孜藏族自治州",Province="四川" },
                new City(){CityName="凉山彝族自治州",Province="四川" },
                new City(){CityName="巴中市",Province="四川" },
                new City(){CityName="眉山市",Province="四川" },
                new City(){CityName="资阳市",Province="四川" },
                new City(){CityName="凉山彝族自治州",Province="四川" },
                new City(){CityName="巴中市",Province="四川" },
                new City(){CityName="眉山市",Province="四川" },
                new City(){CityName="资阳市",Province="四川" },
                new City(){CityName="贵阳市",Province="贵州" },
                new City(){CityName="六盘水市",Province="贵州" },
                new City(){CityName="遵义市",Province="贵州" },
                new City(){CityName="铜仁市",Province="贵州" },
                new City(){CityName="黔西南布依族苗族自治州",Province="贵州" },
                new City(){CityName="毕节市",Province="贵州" },
                new City(){CityName="安顺市",Province="贵州" },
                new City(){CityName="黔东南苗族侗族自治州",Province="贵州" },
                new City(){CityName="黔南布依族苗族自治州",Province="贵州" },
                new City(){CityName="昆明市",Province="云南" },
                new City(){CityName="曲靖市",Province="云南" },
                new City(){CityName="玉溪市",Province="云南" },
                new City(){CityName="昭通市",Province="云南" },
                new City(){CityName="楚雄彝族自治州",Province="云南" },
                new City(){CityName="红河哈尼族彝族自治州",Province="云南" },
                new City(){CityName="文山壮族苗族自治州",Province="云南" },
                new City(){CityName="普洱市",Province="云南" },
                new City(){CityName="西双版纳傣族自治州",Province="云南" },
                new City(){CityName="大理白族自治州",Province="云南" },
                new City(){CityName="保山市",Province="云南" },
                new City(){CityName="德宏傣族景颇族自治州",Province="云南" },
                new City(){CityName="丽江市",Province="云南" },
                new City(){CityName="怒江傈僳族自治州",Province="云南" },
                new City(){CityName="迪庆藏族自治州",Province="云南" },
                new City(){CityName="临沧市",Province="云南" },
                new City(){CityName="拉萨市",Province="西藏" },
                new City(){CityName="昌都市",Province="西藏" },
                new City(){CityName="山南地区",Province="西藏" },
                new City(){CityName="日喀则市",Province="西藏" },
                new City(){CityName="那曲地区",Province="西藏" },
                new City(){CityName="阿里地区",Province="西藏" },
                new City(){CityName="林芝地区",Province="西藏" },
                new City(){CityName="西安市",Province="陕西" },
                new City(){CityName="铜川市",Province="陕西" },
                new City(){CityName="宝鸡市",Province="陕西" },
                new City(){CityName="咸阳市",Province="陕西" },
                new City(){CityName="渭南市",Province="陕西" },
                new City(){CityName="延安市",Province="陕西" },
                new City(){CityName="汉中市",Province="陕西" },
                new City(){CityName="安康市",Province="陕西" },
                new City(){CityName="商洛市",Province="陕西" },
                new City(){CityName="榆林市",Province="陕西" },
                new City(){CityName="兰州市",Province="甘肃" },
                new City(){CityName="嘉峪关市",Province="甘肃" },
                new City(){CityName="金昌市",Province="甘肃" },
                new City(){CityName="白银市",Province="甘肃" },
                new City(){CityName="天水市",Province="甘肃" },
                new City(){CityName="酒泉市",Province="甘肃" },
                new City(){CityName="张掖市",Province="甘肃" },
                new City(){CityName="武威市",Province="甘肃" },
                new City(){CityName="定西市",Province="甘肃" },
                new City(){CityName="陇南市",Province="甘肃" },
                new City(){CityName="平凉市",Province="甘肃" },
                new City(){CityName="庆阳市",Province="甘肃" },
                new City(){CityName="临夏回族自治州",Province="甘肃" },
                new City(){CityName="甘南藏族自治州",Province="甘肃" },
                new City(){CityName="临夏回族自治州",Province="甘肃" },
                new City(){CityName="西宁市",Province="青海" },
                new City(){CityName="海东市",Province="青海" },
                new City(){CityName="海北藏族自治州",Province="青海" },
                new City(){CityName="黄南藏族自治州",Province="青海" },
                new City(){CityName="海南藏族自治州",Province="青海" },
                new City(){CityName="果洛藏族自治州",Province="青海" },
                new City(){CityName="玉树藏族自治州",Province="青海" },
                new City(){CityName="海西蒙古族藏族自治州",Province="青海" },
                new City(){CityName="银川市",Province="宁夏" },
                new City(){CityName="石嘴山市",Province="宁夏" },
                new City(){CityName="吴忠市",Province="宁夏" },
                new City(){CityName="固原市",Province="宁夏" },
                new City(){CityName="中卫市",Province="宁夏" },
                new City(){CityName="乌鲁木齐市",Province="新疆" },
                new City(){CityName="克拉玛依市",Province="新疆" },
                new City(){CityName="吐鲁番地区",Province="新疆" },
                new City(){CityName="哈密地区",Province="新疆" },
                new City(){CityName="昌吉回族自治州",Province="新疆" },
                new City(){CityName="博尔塔拉蒙古自治州",Province="新疆" },
                new City(){CityName="巴音郭楞蒙古自治州",Province="新疆" },
                new City(){CityName="阿克苏地区",Province="新疆" },
                new City(){CityName="孜勒苏柯尔克孜自治州",Province="新疆" },
                new City(){CityName="喀什地区",Province="新疆" },
                new City(){CityName="和田地区",Province="新疆" },
                new City(){CityName="伊犁哈萨克自治州",Province="新疆" },
                new City(){CityName="塔城地区",Province="新疆" },
                new City(){CityName="阿勒泰地区",Province="新疆" },
                new City(){CityName="直辖行政单位",Province="新疆" },
                new City(){CityName="香港特别行政自治区",Province="香港特别行政自治区" },
                new City(){CityName="澳门特别行政自治区",Province="澳门特别行政自治区" },
            };
            foreach (var citys in city)
            {
                _dbContext.Citys.Add(citys);
            }

            //标签
            var label = new List<Label>
            {
                 new Label (){LabelName="古镇" },
                 new Label (){LabelName="穷游" },
                 new Label (){LabelName="骑行" },
                 new Label (){LabelName="潜水" },
                 new Label (){LabelName="登上" },
                 new Label (){LabelName="徒步" },
                 new Label (){LabelName="海岛" },
                 new Label (){LabelName="江山" },
                 new Label (){LabelName="夜景" },
                 new Label (){LabelName="古迹" },
                 new Label (){LabelName="雪景" },
                 new Label (){LabelName="露营" },
                 new Label (){LabelName="滑雪" },
            };
            foreach (var labels in label)
            {
                _dbContext.Label.Add(labels);
            }

            //主题
            var theme = new List<Theme>
            {
                 new Theme (){themeName="蜜月度假" },
                 new Theme (){themeName="亲子同行" },
                 new Theme (){themeName="好友结伴" },
                 new Theme (){themeName="风景名胜" },
                 new Theme (){themeName="骑行" },
                 new Theme (){themeName="潜水" },
                 new Theme (){themeName="徒步" },
                 new Theme (){themeName="爸妈游" },
                 new Theme (){themeName="免签/落地签" },
                 new Theme (){themeName="购物血拼" },
                 new Theme (){themeName="拍摄采风" },
                 new Theme (){themeName="极低之旅" },
                 new Theme (){themeName="全球婚礼" },
            };
            foreach (var themes in theme)
            {
                _dbContext.Themes.Add(themes);
            }
            //景区
            var ScenicSpot = new List<ScenicSpot>
            {
                new ScenicSpot(){Grade="AAA" ,Lng=30.421,Lat=31.432,Addr="广西北海市银海区",Name="北海银滩",Type="自然类旅游景区",Opentime="9:00~18:00",Tel=775620,Label=label.SingleOrDefault(x=>x.LabelName=="潜水"),Theme=theme.SingleOrDefault(x=>x.themeName=="蜜月度假"),Url="/Scenicspot/timg.jpg",Describe="北海银滩是北海市的著名的旅游景点，位于广西北海市银海区，西起冠头岭，东至大冠沙，由西区、东区和海域沙滩区组成，东西绵延约24公里，海滩宽度在30--3000米之间，陆地面积12平方公里，总面积约38平方公里。"},
                new ScenicSpot(){Grade="AAA" ,Lng=24.321,Lat=25.332,Addr="广西东北部，桂林市区南面",Name="桂林阳朔",Type="自然类旅游景区",Opentime="8:00~19:00",Tel=51423,Label=label.SingleOrDefault(x=>x.LabelName=="江山"),Theme=theme.SingleOrDefault(x=>x.themeName=="好友结伴"),Url="/Scenicspot/glys.jpg",Describe="阳朔县拥有漓江景区、《印象·刘三姐》、碧莲峰山水园、聚龙潭、蝴蝶泉、刘三姐水上公园、鉴山寺等营业景点15处。2018年11月，荣登“2018中国幸福百县榜”。"},
                new ScenicSpot(){Grade="AAAA" ,Lng=31.546,Lat=26.566,Addr="位于广州市海珠区（艺洲岛）赤岗塔附近",Name="广州小蛮腰",Type="社会类旅游景区",Opentime="8:00~23:00",Tel=56524,Label=label.SingleOrDefault(x=>x.LabelName=="夜景"),Theme=theme.SingleOrDefault(x=>x.themeName=="好友结伴"),Url="/Scenicspot/gzxmy.jpg",Describe="广州塔塔身168~334.4米处设有“蜘蛛侠栈道”，是世界最高最长的空中漫步云梯。塔身422.8米处设有旋转餐厅，是世界最高的旋转餐厅。塔身顶部450~454米处设有摩天轮，是世界最高摩天轮。天线桅杆455~485米处设有“极速云霄”速降游乐项目，是世界最高的垂直速降游乐项目。天线桅杆488米处设有户外摄影观景平台，是世界最高的户外观景平台，超越了迪拜哈利法塔的442米室外观景平台，以及加拿大国家电视塔447米的“天空之盖”的高度"},
                new ScenicSpot(){Grade="AAAAA" ,Lng=45.894,Lat=45.899,Addr="四川都江堰市城西",Name="成都都江堰",Type="自然类旅游景区",Opentime="8:00~19:00",Tel=51423,Label=label.SingleOrDefault(x=>x.LabelName=="古迹"),Theme=theme.SingleOrDefault(x=>x.themeName=="风景名胜"),Url="/Scenicspot/djy.jpg",Describe="《都江堰》通过作者自己游览都江堰的经历，从人与水相辅相成的关系表达了自己对道的感想：“看上去，是人在治水；实际上，却是人领悟了水，顺应了水，听从了水。只有这样，才能天人合一，无我无私，长生不老。这便是道。”"},
                new ScenicSpot(){Grade="AAAAA" ,Lng=55.465,Lat=55.476,Addr="云南丽江市境内雪山群,市北面约15千米",Name="玉龙雪山",Type="自然类旅游景区",Opentime="9:00~21:00",Tel=564456,Label=label.SingleOrDefault(x=>x.LabelName=="雪景"),Theme=theme.SingleOrDefault(x=>x.themeName=="风景名胜"),Url="/Scenicspot/ylxs.jpg",Describe="玉龙雪山在纳西语中被称为“欧鲁”，意为“天山”。其十三座雪峰连绵不绝，宛若一条“巨龙”腾越飞舞，故称为“玉龙”。又因其岩性主要为石灰岩与玄武岩，黑白分明，所以又称为“黑白雪山”。是纳西人的神山，传说纳西族保护神“三多”的化身。"},
            };
            foreach (var scenicspot in ScenicSpot)
            {
                _dbContext.ScenicSpot.Add(scenicspot);
            }
            //游记内容
            var TravelNotes = new List<TravelNotes>
            {
                new TravelNotes(){ Images="/Images/aomen.jpg",Notos="五一小长假，这样游玩最美！上海，是个不夜城。与北京并列的一线繁华城市，是年轻人追求梦想的地方，是欲望之都。它也是个古老而有韵味，但是又"},
                new TravelNotes(){ Images="/Images/aomen.jpg",Notos="黄色的外墙，绿色的门框，无论你站在哪里跟这些建筑合影，都会呈现非常漂亮的色彩。那两棵椰子树还带了点夏季风情，澳门这小小的地方，处处都是惊喜。"},
                new TravelNotes(){ Images="/Images/aomen.jpg",Notos="这其实不是我第一次来澳门了，还记得第一次来的时候已经是十年前，也许当时不是自由行，并没有发现澳门的乐趣。小时候的我，觉得澳门这个地方特别小，又不好玩。但是当我长大了，再重新来到这个地方的时候，我才发现原来彩色的澳门，是那么让人向往的"},
            };
            var TravelNotes1 = new List<TravelNotes>
            {
                new TravelNotes(){ Images="/Images/ylxs1.jpg",Notos="一起放飞自我，投入大自然的怀抱吧香格里拉国家森林公园从这里感受人与自然的和谐共生从这里踏上通往神界的天路"},
                new TravelNotes(){ Images="/Images/ylxs2.jpg",Notos="一起放飞自我，投入大自然的怀抱吧香格里拉国家森林公园从这里感受人与自然的和谐共生从这里踏上通往神界的天路"},
                new TravelNotes(){ Images="/Images/ylxs3.jpg",Notos="一起放飞自我，投入大自然的怀抱吧香格里拉国家森林公园从这里感受人与自然的和谐共生从这里踏上通往神界的天路"},
            };
            var TravelNotes2 = new List<TravelNotes>
            {
                new TravelNotes(){ Images="/Images/shatan.jpg",Notos="发现其中有一个教堂能够对外开放，于是我便顺便走进去看看。仿佛置身在欧洲的小教堂中，窗花颇有特色，在阳光照射下，呈现不同的色彩。"},
                new TravelNotes(){ Images="/Images/shatan.jpg",Notos="第一站，地铁“豫园”站下来就是“上海老街”，上海古朴的老街，保留着古式建筑，非常迷人， 这里有各种小吃，各种上海特产手信，纪念品等等，人山人海，好不热闹。"},
                new TravelNotes(){ Images="/Images/shatan.jpg",Notos="从城隍庙出来，已到中午吃饭，这里也很多小吃，蟹黄灌汤包，小煎肉包都是特色小吃，然后可以到“上海书城”溜达溜达，感受下当地人的勤奋向上。"},
            };
            var TravelNotes3 = new List<TravelNotes>
            {
                new TravelNotes(){ Images="/Images/bolodehai.png",Notos="三国合起来的总面积（17.5万平方公里）大体相当于我国贵州省那么大，而三国中最大的立陶宛（6.53万平方公里） 也就勉强与我国宁夏自治区相当，最小的爱沙尼亚（4.53万平方公里）更是比台湾省大不了多少。"},
                new TravelNotes(){ Images="/Images/bolodehai.png",Notos="第一站，地铁“豫园”站下来就是“上海老街”，上海古朴的老街，保留着古式建筑，非常迷人， 这里有各种小吃，各种上海特产手信，纪念品等等，人山人海，好不热闹。"},
                new TravelNotes(){ Images="/Images/bolodehai.png",Notos="从城隍庙出来，已到中午吃饭，这里也很多小吃，蟹黄灌汤包，小煎肉包都是特色小吃，然后可以到“上海书城”溜达溜达，感受下当地人的勤奋向上。"},
            };
            foreach (var travelNotes in TravelNotes1)
            {
                _dbContext.TravelNotes.Add(travelNotes);
            }
            foreach (var travelNotes1 in TravelNotes1)
            {
                _dbContext.TravelNotes.Add(travelNotes1);
            }
            foreach (var travelNotes2 in TravelNotes2)
            {
                _dbContext.TravelNotes.Add(travelNotes2);
            }
            foreach (var travelNotes3 in TravelNotes3)
            {
                _dbContext.TravelNotes.Add(travelNotes3);
            }
            
            //游记
            var Travel = new List<Travels>
            {
                new Travels(){ Like=666,Share=55,TravelsTitle="澳门",TravelNotes=TravelNotes,Collection=6,User=_dbContext.Users.SingleOrDefault(x=>x.UserName=="normal1")},
                new Travels(){ Like=1231,Share=123,TravelsTitle="玉龙雪山",TravelNotes=TravelNotes1,Collection=6,User=_dbContext.Users.SingleOrDefault(x=>x.UserName=="normal000")},
                new Travels(){ Like=121,Share=183,TravelsTitle="上海",TravelNotes=TravelNotes2,Collection=6,User=_dbContext.Users.SingleOrDefault(x=>x.UserName=="normal1")},
                new Travels(){ Like=31,Share=13,TravelsTitle="波罗海三国",TravelNotes=TravelNotes3,Collection=6,User=_dbContext.Users.SingleOrDefault(x=>x.UserName=="normal000")},
            };
            foreach (var travel in Travel)
            {
                _dbContext.Travels.Add(travel);
            }
            _dbContext.SaveChanges();
        }

        //      private static void _ForDepartmentAndEmployeeAndStudent()
        //      {

        //if (!_dbContext.Departments.Any())
        //    {
        //        var o1 = _dbContext.Organs.Where(x => x.Name == "内部组织").FirstOrDefault();
        //        var o2 = _dbContext.Organs.Where(x => x.Name == "外部组织").FirstOrDefault();


        //        var dept01 = new Department() { Name = "数学与信息工程学院", Synopsis = "", SortCode = "01", DepartmentType = DepartmentTypeEnum.二级部门, Organization = o1 };
        //        var dept02 = new Department() { Name = "物理与材料工程学院", Synopsis = "", SortCode = "02", DepartmentType = DepartmentTypeEnum.二级部门, Organization = o1 };
        //        var dept03 = new Department() { Name = "教务处", Synopsis = "", SortCode = "03", DepartmentType = DepartmentTypeEnum.总部部门, Organization = o1 };
        //        var dept04 = new Department() { Name = "攀登数字工作室", Synopsis = "", SortCode = "04", DepartmentType = DepartmentTypeEnum.总部部门, Organization = o2 };
        //        var dept0401 = new Department() { Name = "客户响应服务组", Synopsis = "", SortCode = "0401", DepartmentType = DepartmentTypeEnum.二级部门 };
        //        var dept0402 = new Department() { Name = "客户需求分析组", Synopsis = "", SortCode = "0402", DepartmentType = DepartmentTypeEnum.二级部门 };
        //        var dept0403 = new Department() { Name = "应用设计开发组", Synopsis = "", SortCode = "0403", DepartmentType = DepartmentTypeEnum.二级部门 };
        //        var dept05 = new Department() { Name = "神华软件技术公司", Synopsis = "", SortCode = "05", DepartmentType = DepartmentTypeEnum.二级部门, Organization = o2 };
        //        var dept06 = new Department() { Name = "2019年级学生", Synopsis = "", SortCode = "06", DepartmentType = DepartmentTypeEnum.教学班级, Organization = o1 };
        //        var dept0601 = new Department() { Name = "2019级01班", Synopsis = "", SortCode = "0601", DepartmentType = DepartmentTypeEnum.教学班级 };
        //        var dept0602 = new Department() { Name = "2019级02班", Synopsis = "", SortCode = "0602", DepartmentType = DepartmentTypeEnum.教学班级 };

        //        dept01.ParentDepartment = dept01;
        //        dept02.ParentDepartment = dept02;
        //        dept03.ParentDepartment = dept03;
        //        dept04.ParentDepartment = dept04;

        //        dept0401.ParentDepartment = dept04;
        //        dept0402.ParentDepartment = dept04;
        //        dept0403.ParentDepartment = dept04;
        //        dept05.ParentDepartment = dept05;
        //        dept06.ParentDepartment = dept06;
        //        dept0601.ParentDepartment = dept06;
        //        dept0602.ParentDepartment = dept06;

        //        var depts = new List<Department>() { dept01, dept02, dept03, dept04, dept0401, dept0402, dept0403, dept05, dept06, dept0601, dept0602 };
        //        foreach (var item in depts)
        //            _dbContext.Departments.Add(item);

        //        _dbContext.SaveChanges();
        //    }


        //    if (!_dbContext.Employees.Any())
        //    {
        //        var dept = _dbContext.Departments.FirstOrDefault();
        //        var persons = new List<Employee>()
        //        {
        //            new Employee() { Name="刘虎军", EmployeeCode="20190001", CredentialsCode="452230198210010011", Email="Liuhj@qq.com", Mobile="15107728899", SortCode="01001", Synopsis="请补充个人简介", Department=dept },
        //            new Employee() { Name="魏小花", EmployeeCode="20190002", CredentialsCode="452230198210010011", Email="weixh@163.com", Mobile="13678622345", SortCode="01002", Synopsis="请补充个人简介",Department=dept },
        //            new Employee() { Name="李文慧", EmployeeCode="20190003", CredentialsCode="452230198210010011", Email="liwenhui@tom.com", Mobile="13690251923", SortCode="01003", Synopsis="请补充个人简介",Department=dept },
        //            new Employee() { Name="张江的", EmployeeCode="20190004", CredentialsCode="452230198210010011", Email="zhangjd@msn.com", Mobile="13362819012", SortCode="01004", Synopsis="请补充个人简介",Department=dept },
        //            new Employee() { Name="萧可君", EmployeeCode="20190005", CredentialsCode="452230198210010011", Email="xiaokj@qq.com", Mobile="13688981234", SortCode="01005", Synopsis="请补充个人简介",Department=dept },
        //            new Employee() { Name="魏铜生", EmployeeCode="20190006", CredentialsCode="452230198210010011", Email="weitsh@qq.com", Mobile="18398086323", SortCode="01006", Synopsis="请补充个人简介",Department=dept },
        //            new Employee() { Name="刘德华", EmployeeCode="20190007", CredentialsCode="452230198210010011", Email="liudh@icloud.com", Mobile="13866225636", SortCode="01007", Synopsis="请补充个人简介",Department=dept },
        //            new Employee() { Name="魏星亮", EmployeeCode="20190008", CredentialsCode="452230198210010011", Email="weixl@liuzhou.com", Mobile="13872236091", SortCode="01008", Synopsis="请补充个人简介",Department=dept },
        //            new Employee() { Name="潘家富", EmployeeCode="20190009", CredentialsCode="452230198210010011", Email="panjf@guangxi.com", Mobile="13052366213", SortCode="01009", Synopsis="请补充个人简介",Department=dept },
        //            new Employee() { Name="黎温德", EmployeeCode="20190010", CredentialsCode="452230198210010011", Email="liwende@qq.com", Mobile="13576345509", SortCode="01010", Synopsis="请补充个人简介",Department=dept },
        //            new Employee() { Name="邓淇升", EmployeeCode="20190011", CredentialsCode="452230198210010011", Email="dengqsh@qq.com", Mobile="13709823456", SortCode="01011", Synopsis="请补充个人简介" ,Department=dept},
        //            new Employee() { Name="谭檀檀", EmployeeCode="20190012", CredentialsCode="452230198210010011", Email="tangx@live.com", Mobile="18809888754", SortCode="01012", Synopsis="请补充个人简介" ,Department=dept},
        //            new Employee() { Name="陈慧琳", EmployeeCode="20190013", CredentialsCode="452230198210010011", Email="chenhl@live.com", Mobile="13172038023", SortCode="01013", Synopsis="请补充个人简介" ,Department=dept},
        //            new Employee() { Name="祁华钰", EmployeeCode="20190014", CredentialsCode="452230198210010011", Email="qihy@qq.com", Mobile="15107726987", SortCode="01014", Synopsis="请补充个人简介" ,Department=dept},
        //            new Employee() { Name="胡德财", EmployeeCode="20190015", CredentialsCode="452230198210010011", Email="hudc@qq.com", Mobile="13900110988", SortCode="01015", Synopsis="请补充个人简介" ,Department=dept},
        //            new Employee() { Name="吴富贵", EmployeeCode="20190016", CredentialsCode="452230198210010011", Email="wufugui@hotmail.com", Mobile="15087109921", SortCode="01016", Synopsis="请补充个人简介" ,Department=dept}
        //        };

        //        foreach (var person in persons)
        //        {
        //            _dbContext.Employees.Add(person);
        //        }
        //        _dbContext.SaveChanges();
        //    }

        //    if (!_dbContext.GradeAndClasses.Any())
        //    {
        //        var gc001 = new GradeAndClass() { Name = "LZ2019-2020", Synopsis = "", SortCode = "01" };
        //        gc001.ParentDepartment = gc001;
        //        var gc00101 = new GradeAndClass() { Name = "高一3班", Synopsis = "", SortCode = "0101", ParentDepartment = gc001 };
        //        var gc00102 = new GradeAndClass() { Name = "高一2班", Synopsis = "", SortCode = "0102", ParentDepartment = gc001 };
        //        _dbContext.GradeAndClasses.AddRange(new GradeAndClass[] { gc001, gc00101, gc00102 });
        //        _dbContext.SaveChanges();
        //    }

        //    if (!_dbContext.Students.Any())
        //    {
        //        var grade = _dbContext.GradeAndClasses.FirstOrDefault(); ;
        //        var students = new List<Student>()
        //        {
        //            new Student() { Name="黄虎军", EmployeeCode="201908001", CredentialsCode="452230198210010011", Email="Liuhj@qq.com", Mobile="15107728899", SortCode="01001", Synopsis="请补充个人简介" },
        //            new Student() { Name="河小花", EmployeeCode="201908002", CredentialsCode="452230198210010012", Email="weixh@163.com", Mobile="13678622345", SortCode="01002", Synopsis="请补充个人简介"},
        //            new Student() { Name="陆文慧", EmployeeCode="201908003", CredentialsCode="452230198210010011", Email="liwenhui@tom.com", Mobile="13690251923", SortCode="01003", Synopsis="请补充个人简介"},
        //            new Student() { Name="刘江的", EmployeeCode="201908004", CredentialsCode="452230198210010011", Email="zhangjd@msn.com", Mobile="13362819012", SortCode="01004", Synopsis="请补充个人简介"},
        //            new Student() { Name="韦可君", EmployeeCode="201908005", CredentialsCode="452230198210010011", Email="xiaokj@qq.com", Mobile="13688981234", SortCode="01005", Synopsis="请补充个人简介"},
        //            new Student() { Name="韦铜生", EmployeeCode="201908006", CredentialsCode="452230198210010011", Email="weitsh@qq.com", Mobile="18398086323", SortCode="01006", Synopsis="请补充个人简介"},
        //            new Student() { Name="韦德华", EmployeeCode="201908007", CredentialsCode="452230198210010011", Email="liudh@icloud.com", Mobile="13866225636", SortCode="01007", Synopsis="请补充个人简介"},
        //            new Student() { Name="蒋星亮", EmployeeCode="201908008", CredentialsCode="452230198210010011", Email="weixl@liuzhou.com", Mobile="13872236091", SortCode="01008", Synopsis="请补充个人简介"},
        //            new Student() { Name="蒋家富", EmployeeCode="201908009", CredentialsCode="452230198210010011", Email="panjf@guangxi.com", Mobile="13052366213", SortCode="01009", Synopsis="请补充个人简介"},
        //            new Student() { Name="张温德", EmployeeCode="201908010", CredentialsCode="452230198210010011", Email="liwende@qq.com", Mobile="13576345509", SortCode="01010", Synopsis="请补充个人简介"},
        //            new Student() { Name="张淇升", EmployeeCode="201908011", CredentialsCode="452230198210010011", Email="dengqsh@qq.com", Mobile="13709823456", SortCode="01011", Synopsis="请补充个人简介"},
        //            new Student() { Name="秦冠希", EmployeeCode="201908011", CredentialsCode="452230198210010011", Email="tangx@live.com", Mobile="18809888754", SortCode="01012", Synopsis="请补充个人简介"},
        //            new Student() { Name="刘慧琳", EmployeeCode="201908012", CredentialsCode="452230198210010011", Email="chenhl@live.com", Mobile="13172038023", SortCode="01013", Synopsis="请补充个人简介"},
        //            new Student() { Name="周华钰", EmployeeCode="201908013", CredentialsCode="452230198210010011", Email="qihy@qq.com", Mobile="15107726987", SortCode="01014", Synopsis="请补充个人简介"},
        //            new Student() { Name="钱德财", EmployeeCode="201908014", CredentialsCode="452230198210010011", Email="hudc@qq.com", Mobile="13900110988", SortCode="01015", Synopsis="请补充个人简介"},
        //            new Student() { Name="孙富贵", EmployeeCode="201908015", CredentialsCode="452230198210010011", Email="wufugui@hotmail.com", Mobile="15087109921", SortCode="01016", Synopsis="请补充个人简介"},
        //            new Student() { Name="韦虎军", EmployeeCode="201908016", CredentialsCode="452230198210010011", Email="Liuhj@qq.com", Mobile="15107728899", SortCode="01001", Synopsis="请补充个人简介"},
        //            new Student() { Name="韦小花", EmployeeCode="201908017", CredentialsCode="452230198210010011", Email="weixh@163.com", Mobile="13678622345", SortCode="01002", Synopsis="请补充个人简介"},
        //            new Student() { Name="韦文慧", EmployeeCode="201908018", CredentialsCode="452230198210010011", Email="liwenhui@tom.com", Mobile="13690251923", SortCode="01003", Synopsis="请补充个人简介"},
        //            new Student() { Name="韦江的", EmployeeCode="201908019", CredentialsCode="452230198210010011", Email="zhangjd@msn.com", Mobile="13362819012", SortCode="01004", Synopsis="请补充个人简介"},
        //            new Student() { Name="温可君", EmployeeCode="201908020", CredentialsCode="452230198210010011", Email="xiaokj@qq.com", Mobile="13688981234", SortCode="01005", Synopsis="请补充个人简介"},
        //            new Student() { Name="温铜生", EmployeeCode="201908021", CredentialsCode="452230198210010011", Email="weitsh@qq.com", Mobile="18398086323", SortCode="01006", Synopsis="请补充个人简介"},
        //            new Student() { Name="温德华", EmployeeCode="201908022", CredentialsCode="452230198210010011", Email="liudh@icloud.com", Mobile="13866225636", SortCode="01007", Synopsis="请补充个人简介"},
        //            new Student() { Name="温星亮", EmployeeCode="201908023", CredentialsCode="452230198210010011", Email="weixl@liuzhou.com", Mobile="13872236091", SortCode="01008", Synopsis="请补充个人简介"},
        //            new Student() { Name="温家富", EmployeeCode="201908024", CredentialsCode="452230198210010011", Email="panjf@guangxi.com", Mobile="13052366213", SortCode="01009", Synopsis="请补充个人简介"},
        //            new Student() { Name="覃温德", EmployeeCode="201908025", CredentialsCode="452230198210010011", Email="liwende@qq.com", Mobile="13576345509", SortCode="01010", Synopsis="请补充个人简介"},
        //            new Student() { Name="覃淇升", EmployeeCode="201908026", CredentialsCode="452230198210010011", Email="dengqsh@qq.com", Mobile="13709823456", SortCode="01011", Synopsis="请补充个人简介" },
        //            new Student() { Name="覃冠希", EmployeeCode="201908027", CredentialsCode="452230198210010011", Email="tangx@live.com", Mobile="18809888754", SortCode="01012", Synopsis="请补充个人简介" },
        //            new Student() { Name="覃慧琳", EmployeeCode="201908028", CredentialsCode="452230198210010011", Email="chenhl@live.com", Mobile="13172038023", SortCode="01013", Synopsis="请补充个人简介"},
        //            new Student() { Name="覃华钰", EmployeeCode="201908029", CredentialsCode="452230198210010011", Email="qihy@qq.com", Mobile="15107726987", SortCode="01014", Synopsis="请补充个人简介"},
        //            new Student() { Name="覃德财", EmployeeCode="201908030", CredentialsCode="452230198210010011", Email="hudc@qq.com", Mobile="13900110988", SortCode="01015", Synopsis="请补充个人简介"},
        //            new Student() { Name="覃富贵", EmployeeCode="201908031", CredentialsCode="452230198210010011", Email="wufugui@hotmail.com", Mobile="15087109921", SortCode="01016", Synopsis="请补充个人简介"}
        //        };

        //        foreach (var student in students)
        //        {
        //            student.GradeAndClass = grade;
        //            _dbContext.Students.Add(student);
        //        }
        //        _dbContext.SaveChanges();
        //    }


        //}
    }
}
