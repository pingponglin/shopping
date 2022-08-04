using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using foodapi.Models;
using Microsoft.AspNetCore.Http;
using qcloudsms_csharp;
using qcloudsms_csharp.httpclient;
using qcloudsms_csharp.json;

namespace foodapi.Controllers
{
    public class FoodController : ApiController
    {
        //登录查询
        [HttpPost]
        //用户
        public List<Userxix> foodUser([FromBody] Userxix user)
        {
            foodEntities food = new foodEntities();
            var d1 = food.Userxix.SingleOrDefault(s => s.Userxixname == user.Userxixname);
            var d2 = food.Userxix.SingleOrDefault(s => s.Userxixphone == user.Userxixemail);
            var d3 = food.Userxix.SingleOrDefault(s => s.Userxixemail == user.Userxixemail);
            var dt = food.Userxix.Where(p => p.Userxixname == user.Userxixname && p.Usermima == user.Usermima).ToList();
            if (d1 != null)
            {
                dt = food.Userxix.Where(p => p.Userxixname == user.Userxixname && p.Usermima == user.Usermima).ToList();
            }
            if (d2 != null)
            {
                dt = food.Userxix.Where(p => p.Userxixphone == user.Userxixphone && p.Usermima == user.Usermima).ToList();
            }
            if (d3 != null)
            {
                dt = food.Userxix.Where(p => p.Userxixemail == user.Userxixemail && p.Usermima == user.Usermima).ToList();
            }

            return dt;
        }
        [HttpPost]
        //管理员
        public List<Admin> foodAdmin([FromBody] Admin ad)
        {
            foodEntities food = new foodEntities();
            var dt = food.Admin.Where(p => p.Adminname == ad.Adminname && p.Adminmima == ad.Adminmima).ToList();
            return dt;
        }
        //查询用户所有
        [HttpGet]
        public List<Userxix> foodUsers()
        {
            foodEntities food = new foodEntities();
            var dt = food.Userxix.Where(s => s.Userstatus == "true").ToList();
            return dt;
        }
        //添加用户
        [HttpPost]
        public string fooduseradd([FromBody] Userxix userxix)
        {
            foodEntities food = new foodEntities();
            userxix.Userstatus = "true";
            userxix.Userxixname = "tb157164243";
            food.Userxix.Add(userxix);
            var d = "";
            if (food.SaveChanges() > 0)
            {
                d = "添加成功";
            }
            else
            {
                d = "添加失败";
            }
            return d;
        }
        [HttpGet]
        public List<Userxix> foodUsersname(string name)
        {
            foodEntities food = new foodEntities();
            var dt = food.Userxix.Where(s => s.Userstatus == "true" && s.Userxixname == name).ToList();
            return dt;
        }
        //根据用户id和密码查询
        [HttpGet]
        public List<Userxix> foodUseridname(string id, string name)
        {
            foodEntities food = new foodEntities();
            var dt = food.Userxix.Where(s => s.Userstatus == "true" && s.Userxixid.ToString() == id && s.Usermima == name).ToList();
            return dt;
        }
        [HttpPost]
        public string foodUseridnamse([FromBody] Userxix user)
        {
            foodEntities food = new foodEntities();
            var dt = food.Userxix.SingleOrDefault(s => s.Userxixid == user.Userxixid);
            dt.Usermima = user.Usermima;
            string name = "";
            if (food.SaveChanges() > 0)
            {
                name = "修改成功";
            }
            else
            {
                name = "修改失败";
            }
            return name;
        }
        //根据id查询
        [HttpGet]
        public List<Userxix> foodUsersid(string pagenum)
        {
            foodEntities food = new foodEntities();

            var dt = food.Userxix.Where(p => p.Userxixid.ToString() == pagenum && p.Userstatus == "true").ToList();
            return dt;
        }
        //根据id查询
        [HttpGet]
        public List<Userxix> foodUsersphone(string name)
        {
            foodEntities food = new foodEntities();

            var dt = food.Userxix.Where(p => p.Userxixphone == name && p.Userstatus == "true").ToList();
            return dt;
        }
        //根据当前的页数，当前每页的数据
        [HttpGet]
        public IHttpActionResult foodUsersiddS(int pagenum, int pagesize)
        {
            foodEntities food = new foodEntities();
            var dt = food.Userxix.Where(d => d.Userstatus == "true");
            var data = dt.OrderBy(s => s.Userxixid).Skip(pagesize * (pagenum - 1)).Take(pagesize).AsQueryable();
            return Json(new { data, total = dt.Count() });
        }
        //根据查询搜索条件，当前的页数，当前每页的数据
        [HttpGet]
        public IHttpActionResult foodUsersnameselect(int pagenum, int pagesize, string query)
        {
            foodEntities food = new foodEntities();
            var dt = food.Userxix.Where(d => d.Userxixname.Contains(query) && d.Userstatus == "true");
            var data = dt.OrderBy(s => s.Userxixid).Skip(pagesize * (pagenum - 1)).Take(pagesize).AsQueryable();
            return Json(new { data, total = dt.Count() });
        }
        //根据id查询用户信息
        [HttpGet]
        public List<Userxix> foodUsersidselect(string Userxixid)
        {
            foodEntities food = new foodEntities();
            var dt = food.Userxix.Where(s => s.Userxixid.ToString() == Userxixid).ToList();

            return dt;
        }
        //修改用户
        [HttpPost]
        public string foodUsersUpdate([FromBody] Userxix user)
        {
            foodEntities food = new foodEntities();
            var dt = food.Userxix.SingleOrDefault(s => s.Userxixname == user.Userxixname);
            dt.Userxixnich = user.Userxixnich;
            dt.Userxixname = user.Userxixname;
            dt.Userxixgender = user.Userxixgender;
            dt.Userxixbirthday = user.Userxixbirthday;
            dt.Userxixphone = user.Userxixphone;
            dt.Userxixemail = user.Userxixemail;
            dt.Usermima = user.Usermima;
            string name = "";
            if (food.SaveChanges() > 0)
            {
                name = "修改成功";
            }
            else
            {
                name = "修改失败";
            }
            return name;
        }
        //删除用户
        [HttpGet]
        public string foodUsersidDelete(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Userxix.SingleOrDefault(s => s.Userxixid.ToString() == id);
            dt.Userstatus = "false";
            string d = "";
            if (food.SaveChanges() > 0)
            {
                d = "删除成功";
            }
            else
            {
                d = "删除失败";
            }
            return d;
        }

        [HttpGet]
        //查询所有商品信息
        public List<Good> goods()
        {
            foodEntities food = new foodEntities();
            var dt = food.Good.Where(d => d.Goodstatus == "true").ToList();
            return dt;
        }
        [HttpGet]
        //根据商品名称查询所有商品信息
        public List<Good> goodsnameS(string name)
        {
            foodEntities food = new foodEntities();
            var dt = food.Good.Where(d => d.Goodstatus == "true" && d.GoodName == name).ToList();
            return dt;
        }
        [HttpGet]
        //根据商品名称查询所有商品信息
        public List<Good> goodsnamelike(string name)
        {
            foodEntities food = new foodEntities();
            var dt = food.Good.ToList();
            if (name == "")
            {
                dt = food.Good.ToList();
            }
            else
            {
                dt = food.Good.Where(d => d.Goodstatus == "true" && d.GoodName.Contains(name)).ToList();
            }
            return dt;
        }
        [HttpPost]
        //根据商品名称查询所有商品信息
        public List<Good> goodsname(goodshuzhu goodshuz)
        {
            foodEntities food = new foodEntities();
            var dt = food.Good.ToList();
            foreach (var item in goodshuz.goodkoweiid)
            {
                dt = food.Good.Where(d => d.Goodstatus == "true" && d.GoodName == item).ToList();
            }

            return dt;
        }
        //根据当前的页数，当前每页的数据商品
        [HttpGet]
        public IHttpActionResult goodsiddS(int pagenum, int pagesize)
        {
            foodEntities food = new foodEntities();
            var dt = food.Good.Where(s => s.Goodstatus == "true");
            var data = dt.OrderBy(s => s.Goodid).Skip(pagesize * (pagenum - 1)).Take(pagesize).AsQueryable();
            return Json(new { data, total = dt.Count() });
        }
        //搜索框查询商品
        [HttpGet]
        public IHttpActionResult goodsnameselect(int pagenum, int pagesize, string query)
        {
            foodEntities food = new foodEntities();
            var dt = food.Good.Where(s => s.GoodName.Contains(query) && s.Goodstatus == "true");
            var data = dt.OrderBy(p => p.Goodid).Skip(pagesize * (pagenum - 1)).Take(pagesize).AsQueryable();
            return Json(new { data, total = dt.Count() });
        }
        //根据id查询商品信息
        [HttpGet]
        public List<Good> goodidselect(string goodid)
        {
            foodEntities food = new foodEntities();
            var dt = food.Good.Where(s => s.Goodid.ToString() == goodid).ToList();

            return dt;
        }
        //根据管理员用户名查询
        [HttpGet]
        public List<Admin> adminname(string names)
        {
            foodEntities food = new foodEntities();
            var dt = food.Admin.Where(p => p.Adminname == names).ToList();
            return dt;
        }
        //修改商品
        [HttpPost]
        public string goodUpdate([FromBody] Good good)
        {
            foodEntities food = new foodEntities();
            var dt = food.Good.SingleOrDefault(s => s.Goodid == good.Goodid);
            dt.GoodName = good.GoodName;
            dt.GoodPrice = good.GoodPrice;
            dt.GoodPrcieper = good.GoodPrcieper;
            dt.Goodnum = good.Goodnum;
            dt.Goodsales = good.Goodsales;
            dt.GoodCreatedate = good.GoodCreatedate;
            dt.GoodImage = good.GoodImage;
            dt.GoodfuName = good.GoodfuName;
            dt.GoodImagefu = good.GoodImagefu;
            string name = "";
            if (food.SaveChanges() > 0)
            {
                name = "修改成功";
            }
            else
            {
                name = "修改失败";
            }
            return name;
        }
        //根据Id删除商品
        [HttpGet]
        public string gooddelete(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Good.SingleOrDefault(s => s.Goodid.ToString() == id);
            dt.Goodstatus = "false";
            string d = "";
            if (food.SaveChanges() > 0)
            {
                d = "删除成功";
            }
            else
            {
                d = "删除失败";
            }
            return d;
        }

        //添加商品
        [HttpPost]
        public string gooadd([FromBody] Good good)
        {
            foodEntities dt = new foodEntities();
            good.Goodsales = "0";
            good.GoodCreatedate = DateTime.Now;
            good.Goodstatus = "true";
            dt.Good.Add(good);
            string d = "";
            if (dt.SaveChanges() > 0)
            {
                d = "添加成功";
            }
            else
            {
                d = "添加失败";
            }
            return d;
        }
        //查询所有口味
        [HttpGet]
        public List<Goodkowei> goodkoweis()
        {
            foodEntities food = new foodEntities();
            return food.Goodkowei.Where(s => s.Goodkoweistatus == "true").ToList();
        }
        //根据当前的页数，当前每页的数据商品
        [HttpGet]
        public IQueryable<Goodkowei> goodkoweify(int pagenum, int pagesize)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodkowei.ToList();

            return food.Goodkowei.Where(s => s.Goodkoweistatus == "true").OrderBy(s => s.Goodkoweiid).Skip(pagesize * (pagenum - 1)).Take(pagesize).AsQueryable();
        }
        //根据id查询商品口味
        [HttpGet]
        public List<Goodkowei> goodkoweisid(string goodkoweiid)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodkowei.Where(s => s.Goodkoweiid.ToString() == goodkoweiid && s.Goodkoweistatus == "true").ToList();
            return dt;
        }
        //根据id查询商品口味
        [HttpPost]
        public List<Goodkowei> goodkoweisidzhu(goodshuzhu goodshuz)
        {
            foodEntities food = new foodEntities();
            List<Goodkowei> dt = new List<Goodkowei>();
            foreach (var item in goodshuz.goodkoweiid)
            {
                var d = food.Goodkowei.SingleOrDefault(s => s.Goodkoweiid.ToString() == item && s.Goodkoweistatus == "true");
                dt.Add(d);
            }
            return dt;
        }
        //根据商品名称查询商品口味
        [HttpGet]
        public List<Goodkowei> goodkoweisnames(string name)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodkowei.Where(s => s.Good.GoodName == name && s.Goodkoweistatus == "true").ToList();
            return dt;
        }
        //根据商品口味名称查询商品口味
        [HttpGet]
        public List<Goodkowei> goodkoweiz(string name)
        {
            foodEntities food = new foodEntities();
            return food.Goodkowei.Where(d => d.Goodkoweiname == name && d.Goodkoweistatus == "true").ToList();
        }
        //根据商品名称查询口味
        [HttpGet]
        public List<Goodkowei> goodkoweizname(string name)
        {
            foodEntities food = new foodEntities();
            return food.Goodkowei.Where(d => d.Good.GoodName == name && d.Goodkoweistatus == "true").ToList();
        }
        //搜索框查询商品
        [HttpGet]
        public IHttpActionResult goodkoweiselect(int pagenum, int pagesize, string query)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodkowei.Where(s => s.Goodkoweiname.Contains(query) && s.Goodkoweistatus == "true");
            var data = dt.OrderBy(p => p.Goodkoweiid).Skip(pagesize * (pagenum - 1)).Take(pagesize).AsQueryable();
            return Json(new { data, total = dt.Count() });
        }
        //根据商品名称查询商品口味
        [HttpGet]
        public List<Goodkowei> goodkoweisname(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodkowei.Where(s => s.Good.Goodid.ToString() == id && s.Goodkoweistatus == "true").ToList();
            return dt;
        }
        //修改商品口味
        [HttpPost]
        public string goodkoweiUpdate([FromBody] Goodkowei good)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodkowei.SingleOrDefault(s => s.Goodkoweiid == good.Goodkoweiid && s.Goodkoweistatus == "true");
            dt.Goodkoweiid = good.Goodkoweiid;
            dt.Goodkoweiname = good.Goodkoweiname;
            dt.Goodid = good.Goodid;
            string name = "";
            if (food.SaveChanges() > 0)
            {
                name = "修改成功";
            }
            else
            {
                name = "修改失败";
            }
            return name;
        }
        //根据Id删除商品
        [HttpGet]
        public string goodkoweidelete(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodkowei.SingleOrDefault(s => s.Goodkoweiid.ToString() == id && s.Goodkoweistatus == "true");
            dt.Goodkoweistatus = "false";
            string d = "";
            if (food.SaveChanges() > 0)
            {
                d = "删除成功";
            }
            else
            {
                d = "删除失败";
            }
            return d;
        }
        //添加商品口味
        [HttpPost]
        public string goodkoweiADD([FromBody] Goodkowei good)
        {
            foodEntities dt = new foodEntities();
            good.Goodkoweistatus = "true";
            dt.Goodkowei.Add(good);
            string d = "";
            if (dt.SaveChanges() > 0)
            {
                d = "添加成功";
            }
            else
            {
                d = "添加失败";
            }
            return d;
        }
        //查询商品属性所有
        [HttpGet]
        public List<Param> Params()
        {
            foodEntities food = new foodEntities();
            var dt = food.Param.ToList();
            return dt;
        }
        //根据当前的页数，当前每页的数据
        [HttpGet]
        public IQueryable<Param> Paramselect(int pagenum, int pagesize)
        {
            foodEntities food = new foodEntities();
            var dt = food.Userxix.ToList();
            return food.Param.Where(s => s.Paramid > 0).OrderBy(s => s.Paramid).Skip(pagesize * (pagenum - 1)).Take(pagesize).AsQueryable();
        }
        //添加商品属性
        [HttpPost]
        public string ParamADD([FromBody] Param param)
        {
            foodEntities dt = new foodEntities();
            dt.Param.Add(param);
            string d = "";
            if (dt.SaveChanges() > 0)
            {
                d = "添加成功";
            }
            else
            {
                d = "添加失败";
            }
            return d;
        }
        //根据id查询商品口味
        [HttpGet]
        public List<Param> Paramid(string paramid)
        {
            foodEntities food = new foodEntities();
            var dt = food.Param.Where(s => s.Paramid.ToString() == paramid).ToList();
            return dt;
        }
        //根据商品名称查询商品属性和商品
        [HttpGet]
        public List<Param> Paramname(string name)
        {
            foodEntities food = new foodEntities();
            var dt = food.Param.Where(s => s.Good.GoodName == name).ToList();
            return dt;
        }
        //修改商品属性
        [HttpPost]
        public string ParamUpdate([FromBody] Param param)
        {
            foodEntities food = new foodEntities();
            var dt = food.Param.SingleOrDefault(s => s.Paramid == param.Paramid);
            dt.Paramid = param.Paramid;
            dt.ParamProductionid = param.ParamProductionid;
            dt.Parammethod = param.Parammethod;
            dt.Paramdate = param.Paramdate;
            dt.Paramedible = param.Paramedible;
            dt.Paramcontent = param.Paramcontent;
            dt.Paramproduct = param.Paramproduct;
            dt.Paramstandard = param.Paramstandard;
            dt.Paramsite = param.Paramsite;
            dt.Goodimage1 = param.Goodimage1;
            dt.Goodimage2 = param.Goodimage2;
            dt.Goodimage3 = param.Goodimage3;
            dt.Goodimage4 = param.Goodimage4;
            dt.Goodid = param.Goodid;
            string name = "";
            if (food.SaveChanges() > 0)
            {
                name = "修改成功";
            }
            else
            {
                name = "修改失败";
            }
            return name;
        }
        //根据Id删除商品属性
        [HttpGet]
        public string paramdelete(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Param.SingleOrDefault(s => s.Paramid.ToString() == id);
            food.Param.Remove(dt);
            string d = "";
            if (food.SaveChanges() > 0)
            {
                d = "删除成功";
            }
            else
            {
                d = "删除失败";
            }
            return d;
        }
        //查询所有商品类型
        [HttpGet]
        public List<Goodtypetwo> goodtypetwo()
        {
            foodEntities food = new foodEntities();
            return food.Goodtypetwo.Where(s => s.Goodtypeone.Goodtypestatus == "true" && s.Goodtypetwostatus == "true").ToList();
        }
        //查询商品类型去重复
        [HttpGet]
        public IHttpActionResult goodtypetwos()
        {
            foodEntities food = new foodEntities();
            return Json(food.Goodtypetwo.Where(s => s.Goodtypeone.Goodtypestatus == "true" && s.Goodtypetwostatus == "true").Select(d => d.Goodtypetwoname).Distinct());
        }
        //根据二级分类名
        [HttpGet]
        public List<Goodtypetwo> goodtypetwonames(string name)
        {
            foodEntities food = new foodEntities();
            return food.Goodtypetwo.Where(s => s.Goodtypeone.Goodtypestatus == "true" && s.Goodtypetwoname == name && s.Goodtypetwostatus == "true").ToList();
        }
        //根据商品名称查询所有商品
        [HttpGet]
        public List<Goodtypetwo> goodtypetwogoodnames(string name)
        {
            foodEntities food = new foodEntities();
            return food.Goodtypetwo.Where(s => s.Goodtypeone.Goodtypestatus == "true" && s.Good.Goodstatus == "true" && s.Goodtypetwostatus == "true" && s.Goodtypetwoname == name).ToList();
        }

        //根据当前的页数，当前每页的数据商品分类
        [HttpGet]
        public IHttpActionResult goodtypetwofy(int pagenum, int pagesize)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodtypetwo.Where(s => s.Goodtypetwostatus == "true");
            var data = dt.OrderBy(s => s.Goodtypetwoid).Skip(pagesize * (pagenum - 1)).Take(pagesize).AsQueryable();
            return Json(new { data, total = dt.Count() });
        }
        //搜索框查询商品分类
        [HttpGet]
        public IHttpActionResult goodsnametwoselect(int pagenum, int pagesize, string query)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodtypetwo.Where(s => s.Goodtypetwoname.Contains(query) && s.Goodtypetwostatus == "true");
            var data = dt.OrderBy(p => p.Goodid).Skip(pagesize * (pagenum - 1)).Take(pagesize).AsQueryable();
            return Json(new { data, total = dt.Count() });
        }
        //根据id查询商品口味
        [HttpGet]
        public List<Goodtypetwo> goodtypetwofyid(string Goodtypeid)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodtypetwo.Where(s => s.Goodtypetwoid.ToString() == Goodtypeid).ToList();
            return dt;
        }
        //根据当前的页数，当前每页的数据商品分类
        [HttpGet]
        public IHttpActionResult goodtypeonefy(int pagenum, int pagesize)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodtypeone.Where(s => s.Goodtypestatus == "true");
            var data = dt.OrderBy(s => s.Goodtypeoneid).Skip(pagesize * (pagenum - 1)).Take(pagesize).AsQueryable();
            return Json(new { data, total = dt.Count() });

        }
        //搜索框查询商品分类
        [HttpGet]
        public IHttpActionResult goodsnameoneselect(int pagenum, int pagesize, string query)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodtypeone.Where(s => s.Goodtypeonename.Contains(query) && s.Goodtypestatus == "true");
            var data = dt.OrderBy(s => s.Goodtypeoneid).Skip(pagesize * (pagenum - 1)).Take(pagesize).AsQueryable();
            return Json(new { data, total = dt.Count() });
        }
        [HttpGet]
        public List<Goodtypeone> goodtypeoneselect(string query)
        {
            foodEntities food = new foodEntities();
            return food.Goodtypeone.Where(p => p.Goodtypeonename.Contains(query)).ToList();
        }
        //根据一级分类名称查询所有数据
        [HttpGet]
        public List<Goodtypeone> goodtypeoneselectname(string name)
        {
            foodEntities food = new foodEntities();
            return food.Goodtypeone.Where(p => p.Goodtypeonename == name).ToList();
        }
        //查询分类一级分类
        [HttpGet]
        public List<Goodtypeone> goodtypeone()
        {
            foodEntities food = new foodEntities();
            return food.Goodtypeone.Where(p => p.Goodtypestatus == "true").ToList();
        }
        //添加一级分类
        [HttpGet]
        public string goodtypeoneADD(string name)
        {
            foodEntities food = new foodEntities();
            Goodtypeone good = new Goodtypeone();
            good.Goodtypeonename = name;
            good.Goodtypestatus = "true";
            food.Goodtypeone.Add(good);
            string n = "";
            if (food.SaveChanges() > 0)
            {
                n = "添加成功";
            }
            else
            {
                n = "添加失败";
            }
            return n;
        }
        //修改商品一级分类
        [HttpPost]
        public string Goodtypeoneupdate([FromBody] Goodtypeone one)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodtypeone.SingleOrDefault(s => s.Goodtypeoneid == one.Goodtypeoneid);
            dt.Goodtypeonename = one.Goodtypeonename;
            string name = "";
            if (food.SaveChanges() > 0)
            {
                name = "修改成功";
            }
            else
            {
                name = "修改失败";
            }
            return name;
        }
        //根据id删除一级分类
        [HttpGet]
        public string goodtypeonedelete(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodtypeone.SingleOrDefault(s => s.Goodtypeoneid.ToString() == id);
            dt.Goodtypestatus = "false";
            string d = "";
            if (food.SaveChanges() > 0)
            {
                d = "删除成功";
            }
            else
            {
                d = "删除失败";
            }
            return d;
        }
        //根据id查询二级分类的
        [HttpGet]
        public List<Goodtypeone> goodtypeoneselectid(string goodtypeoneid)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodtypeone.Where(s => s.Goodtypeoneid.ToString() == goodtypeoneid && s.Goodtypestatus == "true").ToList();
            return dt;
        }

        //根据id查询二级分类的
        [HttpGet]
        public List<Goodtypetwo> goodtypetwoselectid(string goodtypetwoid)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodtypetwo.Where(s => s.Goodtypetwoid.ToString() == goodtypetwoid && s.Goodtypetwostatus == "true").ToList();
            return dt;
        }
        //修改商品二级分类
        [HttpPost]
        public string goodtypeUpdate([FromBody] Goodtypetwo two)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodtypetwo.SingleOrDefault(s => s.Goodtypetwoid == two.Goodtypetwoid && s.Goodtypetwostatus == "true");
            dt.Goodtypetwoname = two.Goodtypetwoname;
            dt.Goodtypeone.Goodtypeonename = two.Goodtypeone.Goodtypeonename;
            dt.Goodid = two.Goodid;
            string name = "";
            if (food.SaveChanges() > 0)
            {
                name = "修改成功";
            }
            else
            {
                name = "修改失败";
            }
            return name;
        }
        //
        //添加二级分类
        [HttpPost]
        public string goodtypetwoADD([FromBody] Goodtypetwo two)
        {
            foodEntities food = new foodEntities();
            two.Goodtypetwostatus = "true";
            food.Goodtypetwo.Add(two);
            string n = "";
            if (food.SaveChanges() > 0)
            {
                n = "添加成功";
            }
            else
            {
                n = "添加失败";
            }
            return n;
        }

        //根据id删除二级分类
        [HttpGet]
        public string goodtypetwodelete(string ids)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodtypetwo.SingleOrDefault(s => s.Goodtypetwoid.ToString() == ids);
            dt.Goodtypetwostatus = "false";
            string d = "";
            if (food.SaveChanges() > 0)
            {
                d = "删除成功";
            }
            else
            {
                d = "删除失败";
            }
            return d;
        }

        //上传图片到文件夹中
        [HttpPost]
        public string Imgupload()
        {
            //文件保存目录路径 
            string SaveTempPath = "~/img/";
            String dirTempPath = System.Web.HttpContext.Current.Server.MapPath(SaveTempPath);

            if (!Directory.Exists(dirTempPath))
            {
                Directory.CreateDirectory(dirTempPath);
            }

            System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;
            HttpFileCollection FileCollect = request.Files;
            var fors = request.Form;
            HttpPostedFile FileSave = FileCollect[0];  //因为只有图片 使用是0  如果是多个文件 可以使用foreach循环 前端是否from表单上传
            string imgPath = SaveTempPath + FileSave.FileName;     //通过此对象获取文件名
            string AbsolutePath = System.Web.HttpContext.Current.Server.MapPath(imgPath);
            FileSave.SaveAs(AbsolutePath);              //将上传的东西保存
            return "";
        }
        //查询所有订单
        [HttpGet]
        public IHttpActionResult orderfy(int pagenum, int pagesize)
        {
            foodEntities food = new foodEntities();
            var dt = food.Order.Where(s => s.Orderzt == "true");
            var data = dt.OrderBy(s => s.Orderid).Skip(pagesize * (pagenum - 1)).Take(pagesize).AsQueryable();
            return Json(new { data, total = dt.Count() });
        }
        //搜索框、开始日期、结束日期、订单状态查询订单
        [HttpGet]
        public IHttpActionResult orderselect(int pagenum, int pagesize, string query, string kaishi,string jieshu, string dingdan)
        {
            foodEntities food = new foodEntities();
            var dt = food.Order.ToList();
            if (kaishi!=null&&jieshu!=null)
            {
                DateTime d = DateTime.Parse(DateTime.Parse(kaishi).ToString("yyyy-MM-dd"));
                DateTime d1 = DateTime.Parse(DateTime.Parse(jieshu).ToString("yyyy-MM-dd"));
                dt = food.Order.Where(s => s.Ordertime>=d&&s.Ordertime<=d1||s.Orderstatus == dingdan||s.Ordername.Contains(query)&&s.Orderzt=="true").ToList();
            }
            else
            {
                dt = food.Order.Where(s => s.Orderstatus == dingdan||s.Ordername.Contains(query) && s.Orderzt == "true").ToList();
            }
           var data = dt.OrderBy(p => p.Orderid).Skip(pagesize * (pagenum - 1)).Take(pagesize).AsQueryable();
            return Json(new { data, total = dt.Count() });
        }
        //查询所有订单
        [HttpGet]
        public List<Models.Order> order()
        {
            foodEntities food = new foodEntities();

            return food.Order.Where(s => s.Orderzt == "true").ToList();
        }
        //查询所有订单的提醒发货信息
        [HttpGet]
        public List<Models.Order> ordertixi()
        {
            foodEntities food = new foodEntities();

            return food.Order.Where(s => s.Orderzt == "true" && s.Ordertixifahuo == "true").ToList();
        }
        [HttpGet]
        public IHttpActionResult orders()
        {
            foodEntities food = new foodEntities();
            var d = food.Order.Where(s => s.Orderzt == "true").ToList();
            return Json(d);
        }
        //根据id查询
        [HttpGet]
        public List<Models.Order> ordersselect(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Order.Where(s => s.Orderid.ToString() == id && s.Orderzt == "true").ToList();
            return dt;
        }
        //根据订单状态和用户id查询
        [HttpGet]
        public List<Models.Order> ordersstatus(string name, string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Order.Where(s => s.Address.Userxixids.ToString() == id && s.Orderzt == "true" && s.Orderstatus == name).ToList();
            return dt;
        }
        //根据订单状态和用户id、待付款查询的数据
        [HttpGet]
        public List<Models.Order> ordersidsd(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Order.Where(s => s.Orderzt == "true" && s.Goodid.ToString() == id && s.Orderstatus == "待付款").ToList();
            return dt;
        }
        //根据id修改订单是否发货
        //根据id查询
        [HttpPost]
        public string ordersupdate([FromBody] Order order)
        {
            foodEntities food = new foodEntities();
            var dt = food.Order.SingleOrDefault(s => s.Orderid == order.Orderid && s.Orderzt == "true");
            dt.Ordername = order.Ordername;
            dt.Ordernum = order.Ordernum;
            dt.Ordersum = order.Ordersum;
            dt.Goodid = order.Goodid;
            dt.Address.Addressname = order.Address.Addressname;
            dt.Ordertime = order.Ordertime;
            dt.Orderwuliu = order.Orderwuliu;
            dt.Goodtypetwoid = order.Goodtypetwoid;
            dt.Orderstatus = "待收货";
            dt.Orderzt = order.Orderzt;
            string name = "";
            if (food.SaveChanges() > 0)
            {
                name = "发货成功";
            }
            else
            {
                name = "发货失败";
            }
            return name;
        }
        //根据id修改状态 提醒发货
        [HttpGet]
        public string ordertixifahuos(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Order.SingleOrDefault(s => s.Orderid.ToString() == id);
            dt.Ordertixifahuo = "true";
            string d = "";
            if (food.SaveChanges() > 0)
            {
                d = "修改成功";
            }
            else
            {
                d = "修改失败";
            }
            return d;
        }
        //根据id修改状态 提醒发货
        [HttpGet]
        public string ordertixiyiwangchuos(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Order.SingleOrDefault(s => s.Orderid.ToString() == id);
            dt.Orderstatus = "待评价";
            string d = "";
            if (food.SaveChanges() > 0)
            {
                d = "修改成功";
            }
            else
            {
                d = "修改失败";
            }
            return d;
        }
        //根据id修改状态 提醒发货
        [HttpGet]
        public string orderfahuoslin(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Order.SingleOrDefault(s => s.Orderid.ToString() == id);
            dt.Orderstatus = "待收货";
            dt.Ordertixifahuo = "false";
            string d = "";
            if (food.SaveChanges() > 0)
            {
                d = "发货成功";
            }
            else
            {
                d = "发货成功";
            }
            return d;
        }
        //根据id修改状态 提醒发货
        [HttpGet]
        public string orderyiwangc(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Order.SingleOrDefault(s => s.Orderid.ToString() == id);
            dt.Orderstatus = "已完成";
            string d = "";
            if (food.SaveChanges() > 0)
            {
                d = "已完成";
            }
            else
            {
                d = "已完成";
            }
            return d;
        }
        //根据id删除
        [HttpGet]
        public string orderdelete(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Order.SingleOrDefault(s => s.Orderid.ToString() == id);
            dt.Orderzt = "false";
            string d = "";
            if (food.SaveChanges() > 0)
            {
                d = "删除成功";
            }
            else
            {
                d = "删除失败";
            }
            return d;
        }
        //查询所有订单退货
        [HttpGet]
        public IHttpActionResult ordertuihuofy(int pagenum, int pagesize)
        {
            foodEntities food = new foodEntities();
            var dt = food.Ordertuihuo.Where(s => s.Ordertuihuoid > 0);
            var data = dt.OrderBy(s => s.Ordertuihuoid).Skip(pagesize * (pagenum - 1)).Take(pagesize).AsQueryable();
            return Json(new { data, total = dt.Count() });
        }
        //搜索框、开始日期、结束日期、订单状态查询退货
        [HttpGet]
        public IHttpActionResult ordertuihuoselect(int pagenum, int pagesize, string query, string kaishi, string jieshu, string dingdan)
        {
            foodEntities food = new foodEntities();
            var dt = food.Ordertuihuo.ToList();
            if (kaishi != null && jieshu != null)
            {
                DateTime d = DateTime.Parse(DateTime.Parse(kaishi).ToString("yyyy-MM-dd"));
                DateTime d1 = DateTime.Parse(DateTime.Parse(jieshu).ToString("yyyy-MM-dd"));
                dt = food.Ordertuihuo.Where(s => s.Ordertuihuodate >= d && s.Ordertuihuodate <= d1 || s.Ordertuihuostatus == dingdan || s.Order.Ordername.Contains(query) && s.Order.Orderzt == "true").ToList();
            }
            else
            {
                dt = food.Ordertuihuo.Where(s => s.Ordertuihuostatus == dingdan || s.Order.Ordername.Contains(query) && s.Order.Orderzt == "true").ToList();
            }
            var data = dt.OrderBy(p => p.Ordertuihuoid).Skip(pagesize * (pagenum - 1)).Take(pagesize).AsQueryable();
            return Json(new { data, total = dt.Count() });
        }
        //查询所有退货
        [HttpGet]
        public List<Models.Ordertuihuo> ordertuihuo()
        {
            foodEntities food = new foodEntities();
            return food.Ordertuihuo.Where(s => s.Order.Orderzt == "true").ToList();
        }
        //根据id查询所有退货信息
        [HttpGet]
        public List<Models.Ordertuihuo> ordertuihuoid(string id)
        {
            foodEntities food = new foodEntities();
            return food.Ordertuihuo.Where(s => s.Order.Orderzt == "true" && s.Ordertuihuoid.ToString() == id).ToList();
        }
        //根据订单id查询所有退货信息
        [HttpGet]
        public List<Models.Ordertuihuo> ordertuihuodingid(string id)
        {
            foodEntities food = new foodEntities();
            return food.Ordertuihuo.Where(s => s.Order.Orderzt == "true" && s.Orderid.ToString() == id).ToList();
        }
        //根据用户id查询所有退货信息
        [HttpGet]
        public List<Models.Ordertuihuo> ordertuihuouserid(string id)
        {
            foodEntities food = new foodEntities();
            return food.Ordertuihuo.Where(s => s.Order.Orderzt == "true" && s.Order.Address.Userxixids.ToString() == id).ToList();
        }
        //根据id修改退货状态
        [HttpPost]
        public string ordertuihuoAdd(Ordertuihuo ordertuihuo)
        {
            foodEntities food = new foodEntities();
            ordertuihuo.Ordertuihuodate = DateTime.Now;
            ordertuihuo.Ordertuihuostatus = "待处理";
            food.Ordertuihuo.Add(ordertuihuo);
            string name = "";
            if (food.SaveChanges() > 0)
            {
                name = "添加成功";
            }
            else
            {
                name = "添加失败";
            }
            return name;
        }
        //根据id修改退货状态
        [HttpGet]
        public string ordertuihuoupdate(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Ordertuihuo.SingleOrDefault(s => s.Ordertuihuoid.ToString() == id);
            dt.Ordertuihuostatus = "已完成";
            string name = "";
            if (food.SaveChanges() > 0)
            {
                name = "退货成功";
            }
            else
            {
                name = "退货失败";
            }
            return name;
        }
        //根据id修改退货状态为退货中
        [HttpGet]
        public string ordertuihuojujupdate(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Ordertuihuo.SingleOrDefault(s => s.Ordertuihuoid.ToString() == id);
            dt.Ordertuihuostatus = "已拒绝";
            string name = "";
            if (food.SaveChanges() > 0)
            {
                name = "拒绝成功";
            }
            else
            {
                name = "拒绝失败";
            }
            return name;
        }
        //根据id修改是否付款
        [HttpGet]
        public string ordertuihuoupdatestaus(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Order.SingleOrDefault(s => s.Orderid.ToString() == id);
            dt.Orderstatus = "已付款";
            string name = "";
            if (food.SaveChanges() > 0)
            {
                name = "付款成功";
            }
            else
            {
                name = "付款失败";
            }
            return name;
        }
        [HttpGet]
        //查询订单总数
        public int ordersum()
        {
            foodEntities food = new foodEntities();
            var dt = food.Order.Select(s => s.Ordernum).ToList();
            int sum = 0;
            foreach (var item in dt)
            {
                sum += int.Parse(item);
            }
            return sum;
        }
        [HttpGet]
        //查询订单总金额
        public decimal ordermoney()
        {
            foodEntities food = new foodEntities();

            var dt = food.Order.Select(s => s.Ordersum).ToList();
            decimal sum = 0;
            foreach (var item in dt)
            {
                sum += decimal.Parse(item);
            }
            return sum;
        }
        //点击购买添加订单数据
        [HttpPost]
        public string ordershoppingadd([FromBody] Order order)
        {
            foodEntities food = new foodEntities();
            string chars = "0123456789";
            Random randrom = new Random((int)DateTime.Now.Ticks);
            string str = "";
            for (int i = 0; i < 16; i++)
            {
                str += chars[randrom.Next(chars.Length)];
            }
            order.Ordername = str;
            order.Orderstatus = "待付款";
            order.Orderzt = "true";
            int ds = int.Parse(order.Ordernum);
            var goods = food.Good.SingleOrDefault(l => l.Goodid == order.Goodid);
            goods.Goodnum -= ds;
            int goodsales = int.Parse(goods.Goodsales) + ds;
            goods.Goodsales = goodsales.ToString();
            order.Ordertixifahuo = "false";
            var d = "";
            if (goods.Goodnum > 0)
            {
                food.Order.Add(order);
                if (food.SaveChanges() > 0)
                {
                    d = "添加成功";
                }
                else
                {
                    d = "添加失败";
                }
            }
            else
            {
                d = "数量为负";
            }
            return d;
        }
        //根据添加订单的日期查询所有退货信息
        [HttpGet]
        public string ordertime(string times)
        {
            foodEntities food = new foodEntities();
            times += ".000";
            DateTime dtime = DateTime.Parse(times);
            var dt = food.Order.SingleOrDefault(s => s.Orderzt == "true" && s.Ordertime == dtime);
            dt.Orderstatus = "待发货";
            string name = "";
            if (food.SaveChanges() > 0)
            {
                name = "付款成功";
            }
            else
            {
                name = "付款失败";
            }
            return name;
        }
        //根据添加订单的日期多个查询所有退货信息
        [HttpGet]
        public string ordertimes(string times)
        {
            foodEntities food = new foodEntities();
            times += ".000";
            DateTime dtime = DateTime.Parse(times);
            var dt = food.Order.Where(s => s.Orderzt == "true" && s.Ordertime == dtime);
            foreach (var item in dt)
            {
                item.Orderstatus = "待发货";
            }
            string name = "";
            if (food.SaveChanges() > 0)
            {
                name = "付款成功";
            }
            else
            {
                name = "付款失败";
            }
            return name;
        }
        //根据传过来的分类名称查询商品
        [HttpGet]
        public List<Models.Goodtypetwo> getgoodtwo(string name)
        {
            foodEntities food = new foodEntities();
            var dt = food.Goodtypetwo.Where(s => s.Goodtypetwoname == name).ToList();
            return dt;
        }
        //查询所有购物车
        [HttpGet]
        public List<Models.shopping> shoppings()
        {
            foodEntities food = new foodEntities();
            return food.shopping.Where(s => s.Good.Goodstatus == "true" && s.Userxix.Userstatus == "true").ToList();
        }
        //根据id查询所有购物车
        [HttpGet]
        public List<Models.shopping> shoppingid(string id)
        {
            foodEntities food = new foodEntities();
            return food.shopping.Where(s => s.Good.Goodstatus == "true" && s.Userxix.Userstatus == "true" && s.Userxix.Userxixid.ToString() == id).ToList();
        }
        //添加购物车
        [HttpPost]
        public string shoppingADD([FromBody] shopping shopp)
        {
            foodEntities dt = new foodEntities();
            shopp.shoppingdate = DateTime.Now;
            dt.shopping.Add(shopp);
            string d = "";
            if (dt.SaveChanges() > 0)
            {
                d = "添加成功";
            }
            else
            {
                d = "添加失败";
            }
            return d;
        }
        //删除购物车
        [HttpGet]
        public string shoppingDelete(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.shopping.SingleOrDefault(s => s.shoppingid.ToString() == id);
            food.shopping.Remove(dt);
            string d = "";
            if (food.SaveChanges() > 0)
            {
                d = "删除成功";
            }
            else
            {
                d = "删除失败";
            }
            return d;
        }
        //根据id查询所有收货地址
        [HttpGet]
        public List<Models.Address> addresses(string id)
        {
            foodEntities food = new foodEntities();
            return food.Address.Where(s => s.Userxix.Userxixid.ToString() == id && s.Addressstaus == "true").ToList();
        }
        //根据id查询收货地址默认地址Addressstaus=true
        [HttpGet]
        public List<Models.Address> addressestrue(string id)
        {
            foodEntities food = new foodEntities();
            return food.Address.Where(s => s.Userxix.Userxixid.ToString() == id && s.Addressstaus == "true").ToList();
        }
        //根据id查询收货地址默认地址Addressstaus=true
        [HttpGet]
        public List<Models.Address> addressesname(string name)
        {
            foodEntities food = new foodEntities();
            return food.Address.Where(s => s.Addressphone == name && s.Addressstaus == "true").ToList();
        }
        //根据收货地址的id
        [HttpGet]
        public List<Models.Address> addressesids(string id)
        {
            foodEntities food = new foodEntities();
            return food.Address.Where(s => s.Addressid.ToString() == id && s.Userxix.Userstatus == "true").ToList();
        }
        //查询id修改收货地址的默认地址
        [HttpGet]
        public string addressesid(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Address.SingleOrDefault(s => s.Addressid.ToString() == id && s.Userxix.Userstatus == "true");
            dt.Addressstaus = "true";
            var name = "";
            var ds = food.Address.Where(l => l.Addressid.ToString() != id);
            foreach (var item in ds)
            {
                item.Addressstaus = "false";
            }
            if (food.SaveChanges() > 0)
            {
                name = "修改成功";
            }
            else
            {
                name = "修改失败";
            }
            return name;
        }
        //修改收货地址
        [HttpPost]
        public string addressupdate([FromBody] Address add)
        {
            foodEntities food = new foodEntities();
            var dt = food.Address.SingleOrDefault(s => s.Addressid == add.Addressid);
            dt.Addressname = add.Addressname;
            dt.Addresssuozaidiqu = add.Addresssuozaidiqu;
            dt.Addressxiangxidiqu = add.Addressxiangxidiqu;
            dt.Addressyoubian = add.Addressyoubian;
            dt.Addressphone = add.Addressphone;
            dt.Userxixids = add.Userxixids;
            dt.Addressstaus = add.Addressstaus;
            string d = "";
            if (food.SaveChanges() > 0)
            {
                d = "修改成功";
            }
            else
            {
                d = "修改失败";
            }
            return d;
        }
        //根据id删除收货信息
        [HttpGet]
        public string addressdelete(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Address.SingleOrDefault(s => s.Addressid.ToString() == id);
            food.Address.Remove(dt);
            string d = "";
            if (food.SaveChanges() > 0)
            {
                d = "删除成功";
            }
            else
            {
                d = "删除失败";
            }
            return d;
        }
        //添加收货地址
        [HttpPost]
        public string addressADD([FromBody] Address add)
        {
            foodEntities food = new foodEntities();
            add.Addressstaus = "true";
            food.Address.Add(add);
            string n = "";
            if (food.SaveChanges() > 0)
            {
                n = "添加成功";
            }
            else
            {
                n = "添加失败";
            }
            return n;
        }
        //添加收藏
        [HttpPost]
        public string footprintADD([FromBody] footprint foot)
        {
            foodEntities food = new foodEntities();
            foot.footprintdate = DateTime.Now;
            food.footprint.Add(foot);
            var d = "";
            if (food.SaveChanges() > 0)
            {
                d = "添加成功";
            }
            else
            {
                d = "添加失败";
            }
            return d;
        }
        [HttpGet]
        //查询收藏夹
        public List<footprint> footprintselect()
        {
            foodEntities food = new foodEntities();
            return food.footprint.Where(s => s.Good.Goodstatus == "true" && s.Userxix.Userstatus == "true").ToList();
        }
        //根据id查询所有收藏夹
        [HttpGet]
        public List<Models.footprint> footprintid(string id)
        {
            foodEntities food = new foodEntities();
            return food.footprint.Where(s => s.Userxix.Userstatus == "true" && s.Userxix.Userxixid.ToString() == id).ToList();
        }
        //取消收藏
        [HttpGet]
        public string footprintdelete(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.footprint.Where(s => s.Good.GoodfuName.ToString() == id);
            foreach (var item in dt)
            {
                food.footprint.Remove(item);
            }
            string d = "";
            if (food.SaveChanges() > 0)
            {
                d = "删除成功";
            }
            else
            {
                d = "删除失败";
            }
            return d;
        }
        //添加评价
        [HttpPost]
        public string scoreADD([FromBody] Score score)
        {
            foodEntities dt = new foodEntities();
            score.Scoredate = DateTime.Now;
            dt.Score.Add(score);
            string d = "";
            if (dt.SaveChanges() > 0)
            {
                d = "添加成功";
            }
            else
            {
                d = "添加失败";
            }
            return d;
        }
        //查询评价所有
        [HttpGet]
        public List<Score> scoresselect()
        {
            foodEntities food = new foodEntities();
            return food.Score.Where(s => s.Good.Goodstatus == "true" && s.Order.Orderzt == "true" && s.Userxix.Userstatus == "true").ToList();
        }
        //根据id查询评价所有
        [HttpGet]
        public List<Score> scoresselectid(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Score.Where(s => s.Good.Goodstatus == "true" && s.Order.Orderzt == "true" && s.Userxix.Userstatus == "true" && s.Good.GoodName == id).ToList();
            return dt;
        }
        //根据id查询差评评价的数量
        [HttpGet]
        public List<Score> scoresselectchapi(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Score.Where(s => s.Good.Goodstatus == "true" && s.Order.Orderzt == "true" && s.Userxix.Userstatus == "true" && s.Goodid.ToString() == id && s.Scoreidpf == "2" || s.Scoreidpf == "1").ToList();
            return dt;
        }
        //根据id查询中评评价的数量
        [HttpGet]
        public List<Score> scoresselectzhongpi(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Score.Where(s => s.Good.Goodstatus == "true" && s.Order.Orderzt == "true" && s.Userxix.Userstatus == "true" && s.Goodid.ToString() == id && s.Scoreidpf == "3").ToList();
            return dt;
        }
        //根据id查询优评评价的数量
        [HttpGet]
        public List<Score> scoresselectyoupi(string id)
        {
            foodEntities food = new foodEntities();
            var dt = food.Score.Where(s => s.Good.Goodstatus == "true" && s.Order.Orderzt == "true" && s.Userxix.Userstatus == "true" && s.Goodid.ToString() == id && s.Scoreidpf == "4" || s.Scoreidpf == "5").ToList();
            return dt;
        }
        //搜索框查询商品分类
        [HttpGet]
        public IHttpActionResult scoresselectfy(int pagenum, int pagesize, string query)
        {
            foodEntities food = new foodEntities();
            var dt = food.Score.Where(s => s.Good.GoodName.Contains(query) && s.Good.Goodstatus == "true");
            var data = dt.OrderBy(s => s.Scoreid).Skip(pagesize * (pagenum - 1)).Take(pagesize).AsQueryable();
            return Json(new { data, total = dt.Count() });
        }
        //发送验证码
        [HttpGet]
        public IHttpActionResult SendSMS(string phone)
        {
            int appid = 1400545047;//SDK AppID
            string appkey = "ebb9da1667baf1678e93eecbe265578c"; //SDK AppKey
            string[] phoneNumbers = { phone };//发送短信手机号
            int templateId = 1033774; // 模板ID
            string smsSign = "PMS系统学习"; // 签名内容
            string[] tempData = new string[2];//模板内容
            Random r = new Random();
            int randNum = r.Next(1000000);
            tempData[0] = randNum.ToString("D4");//验证码
            tempData[1] = "15";//过期时间
            try
            {
                SmsMultiSender msender = new SmsMultiSender(appid, appkey);
                msender.sendWithParam("86", phoneNumbers, templateId, tempData, smsSign, "", "");
                return Json(new { Msg = "OK", sms = tempData[0], time = tempData[1] });//条件有限，暂发送到前端计时
            }
            catch (JSONException e)
            {
                return Json(new { Msg = "Error" });
            }
            catch (HTTPException e)
            {
                return Json(new { Msg = "Error" });
            }
            catch (Exception ex)
            {
                return Json(new { Msg = "Error" });
            }
        }
    }
}