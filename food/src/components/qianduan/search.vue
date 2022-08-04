<template>
  <div>
    <header>
      <article>
        <div class="mt-logo">
          <!--顶部导航条 -->
          <div class="am-container header">
            <ul class="message-r">
              <div class="topMessage home">
                <div class="menu-hd">
                  <a href="http://81.68.137.46:8000/" target="_top" class="h"
                    >商城首页</a
                  >
                </div>
              </div>
              <div class="topMessage my-shangcheng">
                <div class="menu-hd MyShangcheng">
                  <a href="#" target="_top" @click="s"
                    ><i class="am-icon-user am-icon-fw"></i>个人中心</a
                  >
                </div>
              </div>
              <div class="topMessage mini-cart">
                <div class="menu-hd">
                  <a id="mc-menu-hd" href="#" target="_top" @click="goodshopp"
                    ><i class="am-icon-shopping-cart am-icon-fw"></i
                    ><span>购物车</span
                    ><strong id="J_MiniCartNum" class="h"></strong></a
                  >
                </div>
              </div>
              <div class="topMessage favorite">
                <div class="menu-hd">
                  <a href="#" target="_top" @click="goodfoot"
                    ><i class="am-icon-heart am-icon-fw"></i
                    ><span>收藏夹</span></a
                  >
                </div>
              </div>
              <div class="topMessage favorite">
                <div class="menu-hd">
                  <a href="#" target="_top"><span @click="tui" v-show="zhus()">退出</span></a>
                </div>
              </div>
            </ul>
          </div>

          <!--悬浮搜索框-->

          <div class="nav white">
            <div class="logoBig">
              <li><img src="../../assets/images/logobig.png" /></li>
            </div>

            <div class="search-bar pr">
              <a name="index_none_header_sysc" href="#"></a>
              <form>
                <input
                  id="searchInput"
                  name="index_none_header_sysc"
                  type="text"
                  placeholder="搜索"
                  autocomplete="off" v-model="query"
                />
                <input
                  id="ai-topsearch"
                  class="submit am-btn"
                  value="搜索"
                  index="1"
                  type="button" @click="Selects"
                  style="text-align: center"
                />
              </form>
            </div>
          </div>

          <div class="clear"></div>
        </div>
      </article>
    </header>
    <div class="nav-table">
      <div class="long-title"><span class="all-goods">全部分类</span></div>
      <div class="nav-cont">
        <ul>
          <li class="index"><a href="http://81.68.132.153:7070/">首页</a></li>
          <li class="qc">
            <a
              href="https://www.tmall.com/?spm=a21bo.21814703.201859.1.49fa11d9BdGwQk"
              target="_blank"
              >天猫</a
            >
          </li>
          <li class="qc">
            <a
              target="_blank"
              href="https://pages.tmall.com/wow/a/act/ju/dailygroup/2199/wupr?wh_pid=daily-222239&bid=3&spm=a21bo.21814703.201859.2.49fa11d9BdGwQk"
              >聚划算</a
            >
          </li>
          <li class="qc">
            <a
              target="_blank"
              href="https://chaoshi.tmall.com/?spm=a21bo.21814703.201859.3.49fa11d9BdGwQk"
              >天猫超市</a
            >
          </li>
          <li class="qc last">
            <a
              target="_blank"
              href="https://www.fliggy.com/?spm=a21bo.21814703.201859.5.49fa11d9BdGwQk"
              >飞猪旅行</a
            >
          </li>
        </ul>
      </div>
    </div>
    <b class="line"></b>
    <div class="am-g am-g-fixed" style="margin: 0 auto">
      <div class="am-u-sm-12 am-u-md-12">
        <div class="theme-popover">
          <ul class="select">
            <li class="select-result" :style="yangshi">
              <dl>
                <dt>已选</dt>
                <dd class="select-no" v-for="(item, index) in arr" :key="item">
                  <a href="#" :style="biank" @click="remove(index)">{{
                    item
                  }}</a>
                  <!-- <a style="color: red;" href="javascript:;" @click="remove(index,item.id)">X</a> -->
                </dd>
                <p class="eliminateCriteria">清除</p>
              </dl>
            </li>
            <div class="clear"></div>
            <li class="select-list">
              <dl id="select1">
                <dt class="am-badge am-round">类型</dt>

                <div class="dd-conent">
                  <dd>
                    <a href="#" class="sdss leixi" @click="dianji(quanbu)">{{
                      quanbu
                    }}</a>
                  </dd>
                  <dd
                    v-for="goodtwo in goodtwodate"
                    :key="goodtwo.Goodtypetwoid"
                  >
                    <a href="#" class="sdss" @click="dianji(goodtwo)">{{
                      goodtwo
                    }}</a>
                  </dd>
                </div>
              </dl>
            </li>
          </ul>
          <div class="clear"></div>
        </div>
        <div class="search-content">
          <div class="sort">
            <li class="sd first" @click="zhongho"><a title="综合" >综合排序</a></li>
            <li class="sd" @click="xiaoliao"><a title="销量" >销量排序</a></li>
            <li class="sd" @click="jiage"><a title="价格" >价格优先</a></li>
          </div>
          <div class="clear"></div>

          <ul
            v-if="twoid == 1"
            class="am-avg-sm-2 am-avg-md-3 am-avg-lg-4 boxes"
          >
            <li v-for="goods in gooddate" :key="goods.Goodid" @click="xiang(goods.GoodName)">
              <div class="i-pic limit">
                <img :src="'http://81.68.132.153:7070/img/' + goods.GoodImage" />
                <p class="title fl">
                  {{ goods.GoodfuName }}
                </p>
                <p class="price fl">
                  <b>¥</b>
                  <strong>{{ goods.GoodPrcieper }}</strong>
                </p>
                <p class="number fl">
                  销量<span>{{ goods.Goodsales }}</span>
                </p>
              </div>
            </li>
          </ul>
          <ul v-else class="am-avg-sm-2 am-avg-md-3 am-avg-lg-4 boxes">
            <li v-for="goods in Goodtwodates" :key="goods.Goodtypetwoid" @click="xiang(goods.Good.GoodName)">
              <div class="i-pic limit">
                <img
                  :src="'http://81.68.132.153:7070/img/' + goods.Good.GoodImage"
                />
                <p class="title fl">
                  {{ goods.Good.GoodfuName }}
                </p>
                <p class="price fl">
                  <b>¥</b>
                  <strong>{{ goods.Good.GoodPrcieper }}</strong>
                </p>
                <p class="number fl">
                  销量<span>{{ goods.Good.Goodsales }}</span>
                </p>
              </div>
            </li>
          </ul>
          <el-pagination
        @size-change="handleSizeChange"
        @current-change="handleCurrentChange"
        :current-page="pagenum"
        :page-sizes="[1, 2, 5, 12]"
        :page-size="pagesize"
        layout="total, sizes, prev, pager, next, jumper"
        :total="total"
      >
      </el-pagination>
        </div>
        <div class="search-side">
          <div class="side-title">经典搭配</div>
         <ul>
          <li v-for="(goods,index) in gooddates" :key="goods.Goodid" @click="xiang(goods.GoodName)">
            <div v-if="index<=2" class="i-pic check">
              <img :src="'http://81.68.132.153:7070/img/' + goods.GoodImage" />
              <p class="check-title">{{ goods.GoodName }}</p>
              <p class="price fl">
                <b>¥</b>
                <strong>{{ goods.GoodPrcieper }}</strong>
              </p>
              <p class="number fl">销量<span>{{ goods.Goodsales }}</span></p>
            </div>
          </li>
          </ul>
        </div>
        <div class="clear"></div>
        <!--分页 -->
         <!-- 分页区域 -->
      
      </div>
    </div>
  </div>
</template>

<script>
import $ from "jquery";
$(function () {
  $(".sdss").each(function (index) {
    //便利对象
    $(this).click(function () {
      //点击触发事件
      $(".sdss").removeClass("leixi"); //删除当前元素的样式
      $(".sdss").eq(index).addClass("leixi"); //添加当前元素的样式
    });
  });
  $(".sd").each(function (index) {
    //便利对象
    $(this).click(function () {
      //点击触发事件
      $(".sd").removeClass("first"); //删除当前元素的样式
      $(".sd").eq(index).addClass("first"); //添加当前元素的样式
    });
  });
});
export default {
  data() {
    return {
      //接收所有商品数据
      gooddate: [],
      //接收所有商品数据经典搭配
      gooddates:[],
      //接收所有的二级分类数据
      goodtwodate: [],
      //接收口味的id
      goodnamesdate: {
        goodnames: [],
      },
      quanbu: "全部",
      //控制
      twoid: 1,
      //选中的数据
      arr: [],
      yangshi: "",
      biank: "",
      //接收商品口味的数据
      Goodtwodates:[],
      //搜索
      soushou:"",
      //当前的页数
      pagenum: 1,
      //当前每页的数据
      pagesize: 12,
      //获取总共的页数
      total: 0,
      //获取搜索的内容
      query: "",
      //判断用户有没有登录
      namess: "",
      //获取从index页面的数据
      indexname:""
    };
  },
  methods: {
    //查询所有商品
    goodjindian(){
     this.$axios.get('/api/Food/goods').then(s=>{
       this.gooddates=s.data;
     });
    },
    //分页查询商品查询所有
    goodlist() {
     this.$axios
        .get("/api/Food/goodsiddS", {
          params: {
            pagenum: this.pagenum,
            pagesize: this.pagesize,
          },
        }).then((s) => {
        if (s.data != "") {
          console.log(s.data.data);
           this.total=s.data.total;
          this.gooddate = s.data.data;
        }
      });
    },
    s() {
             if (this.namess == null) {
        this.$router.push('/Login');
      } else {
        console.log();
         this.$axios.get('/api/Food/foodUsersname?name='+this.namess).then(sd=>{
            if (sd.data!="") {
             this.userids=sd.data[0].Userxixid;
             this.$router.push({
              path: '/qianduan/Information',
              query: {
                userids:this.userids
              }
      });
            }else{
              this.$message.error("查询用户失败!");
            }
          })
      }
    },
    //跳转到购物车
    goodshopp() {
      if (this.namess == null) {
        this.$router.push("/Login");
      } else {
        console.log();
        this.$axios
          .get("/api/Food/foodUsersname?name=" + this.namess)
          .then((sd) => {
            if (sd.data != "") {
              this.userids = sd.data[0].Userxixid;
              this.$router.push({
                path: "/qianduan/shopgowuche",
                query: {
                  userids: this.userids,
                },
              });
            } else {
              this.$message.error("查询用户失败!");
            }
          });
      }
    },
    //跳转到收藏夹
    goodfoot() {
      if (this.namess == null) {
        this.$router.push("/Login");
      } else {
        console.log();

        this.$axios
          .get("/api/Food/foodUsersname?name=" + this.namess)
          .then((sd) => {
            if (sd.data != "") {
              this.userids = sd.data[0].Userxixid;
              this.$router.push({
                path: "/qianduan/shouchang",
                query: {
                  userids: this.userids,
                },
              });
            } else {
              this.$message.error("查询用户失败!");
            }
          });
      }
    },
    //退出
    tui() {
      window.sessionStorage.clear();
      this.$router.push("/Login");
    },
     //判断有没有登录
    zhus() {
      // window.sessionStorage.clear();

      if (this.namess != "") {
        return true;
      }
      return false;
    },
    //查询所有类型
    goodtwolist() {
      this.$axios.get("/api/Food/goodtypetwos").then((s) => {
        this.goodtwodate = s.data;
         this.Goodtwodates = s.data;
        this.goodtwodate.reverse();
        console.log(this.goodtwodate);
      });
    },
    //点击类型查询所有商品
    dianji(id) {
      this.yangshi = "display: flex;";
      this.biank = "color: #f00 !important;border: #999 solid 1px;";
      let shuz = [];
      shuz.push(id);
      const ress = new Map();
      this.arr = shuz.filter((a) => !ress.has(a) && ress.set(a, 1));
      console.log("ss");
      console.log(this.arr);
      this.$axios.get("/api/Food/goodtypetwogoodnames?name=" + id).then((s) => {
        if (id == "全部") {
          this.twoid = 1;
          this.goodlist();
        } else {
          if (s.data != "") {
            this.twoid = 2;
            const res = new Map();
            this.gooddate = s.data.filter(
              (a) => !res.has(a.Good.GoodName) && res.set(a.Good.GoodName, 1)
            );
             const ress = new Map();
            this.Goodtwodates = s.data.filter(
              (a) => !ress.has(a.Good.GoodName) && ress.set(a.Good.GoodName, 1)
            );
            console.log(this.gooddate);
          }
        }
      });
    },
    //已选删除
    remove(id) {
      this.arr.splice(id, 1);
      if (this.arr.length == 0) {
        this.yangshi = "";
        this.twoid=1;
        this.goodlist();
      }
    },
    //综合排序
    zhongho(){
      if (this.twoid==1) {
        this.goodlist();
      }
      else{
        this.goodtwolist();
      }
    },
    //销量排序
    xiaoliao(){
       if (this.twoid==1) {
         this.gooddate=this.sortDesByKey(this.gooddate,"Goodsales");
       }else{
         this.Goodtwodates=this.sortDesByKey(this.Goodtwodates,"Good.Goodsales");
       }
  
    },
    //价格排序
    jiage(){
     if (this.twoid==1) {
         this.gooddate=this.sortDesByKey(this.gooddate,"GoodPrcieper");
       }else{
         this.Goodtwodates=this.sortDesByKey(this.Goodtwodates,"Good.GoodPrcieper");
       }
    },
    //从大到小
    sortDesByKey(ary,key){
    return ary.sort((a,b)=>{
       let x = a[key];
       let y = b[key];
       return ((x<y)?1:(x>y)?-1:0)
    })
},
//从小到大
sortAscByKey(ary,key){
   return ary.sort((a,b)=>{
       let x = a[key];
       let y = b[key];
       return ((x<y)?-1:(x>y)?1:0)
   })
},
//商品详情页面
  xiang(sender){
     this.$router.push({
          path: '/qianduan/shopping',
          query: {
            ids: sender,
            namess: this.name
          }
        });
  },
  //根据搜索查询
  Selects(){
   this.$axios.get("/api/Food/goodsnameselect", {
          params: {
            pagenum: this.pagenum,
            pagesize: this.pagesize,
            query: this.query,
          },
        }).then(s=>{
      if (s.data!="") {
        this.gooddate=s.data.data;
        this.total=s.data.total;
        if (this.query=="") {
           this.$message.success("请输入关键字");
            this.goodlist();
          }
      }
      else{
         if (this.query=="") {
           this.$message.success("请输入关键字");
            this.goodlist();
          }
        else{
          this.$message.error("暂无商品");
        }
         
      }
   });
  },
  //监听pagesize改变的事件
    handleSizeChange(newSieze) {
      console.log(newSieze + "pagesize=");
      this.pagesize = newSieze;
     this.goodlist();
    },
    //监听页码值改变的事件
    handleCurrentChange(newPage) {
      console.log(newPage + "pagenum");
      this.pagenum = newPage;
      this.goodlist();
    },
  },
  created() {
    this.goodlist();
    this.goodtwolist();
    this.goodjindian();
    this.namess=this.$route.query.namess;
    this.indexname=this.$route.query.onename;
    if (this.indexname!=null) {
      this.dianji(this.indexname);
    }
  },
};
</script>
<style scoped>
.i-pic:hover{
box-shadow: 0px 12px 12px -10px rgb(0 0 0 / 40%);
}
.leixi {
  color: #f00 !important;
  border: #999 solid 1px;
}
/* CSS Document */
/*通用格式*/
*,
*:after,
*:before {
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  -o-box-sizing: border-box;
  box-sizing: border-box;
}
/*任何标签、包括它前面、后面生成的内容都不要影响盒子的边框*/
ul,
li,
ol {
  list-style: none;
}
dl,
dt,
dd {
  margin: 0px auto;
  padding: 0px;
}
p {
  margin: 0 0 0.3rem 0;
  font-size: 14px;
}
[class*="am-u-"] {
  padding-left: 0rem;
  padding-right: 0rem;
}
.am-thumbnails {
  margin-left: 0rem;
  margin-right: 0rem;
}
.am-thumbnail {
  margin-bottom: 0;
}
.am-thumbnails > li {
  padding: 0 0rem 0.2rem 0.2rem;
}
img {
  width: 100%;
}
.price {
  color: #e4393c;
  font-weight: 600;
}

.theme-popover {
  z-index: 1009;
  overflow: visible;
  background: #fff;
}

/* select */
.sort {
  padding: 5px 10px;
  font-size: 12px;
}

.suggest,
.searchAbout {
  display: none;
}
.select .title.font-normal {
  margin-top: 70px;
  margin-left: 10px;
}
.select li {
  margin: 10px 0 5px 0px;
}
.select dl {
  zoom: 1;
  position: relative;
  line-height: 24px;
  margin: 10px 0px;
}
.select dl:after {
  content: " ";
  display: block;
  clear: both;
  height: 0;
  overflow: hidden;
}
.select dt {
  width: 80%;
  margin-left: 10%;
  margin-bottom: 5px;
  position: absolute;
  cursor: pointer;
  height: 24px;
  line-height: 24px;
}
.select dd {
  float: left;
  display: inline;
  margin: 0 0 5px 5px;
}
.select a {
  display: inline-block;
  white-space: nowrap;
  height: 24px;
  line-height: 24px;
  padding: 0 10px;
  text-decoration: none;
  color: #000;
  border-radius: 2px;
}
.select a:hover {
  color: #f60;
  background-color: #f3edc2;
}
.select .selected a {
  color: #f00;
  border: #999 solid 1px;
}
ul.pagination {
  display: none;
}
/*搜索显示*/
.select-result {
  display: none;
}
li.select-result dl {
  padding: 10px 0 5px 30px;
}
li.select-result dt {
  left: -30px;
  top: 10px;
  font-weight: bold;
  width: 50px;
}

.select-no {
  color: #999;
}
.select .select-result a {
  padding-right: 20px;
  background: url("../../assets/images/close.png") right 9px no-repeat;
}
.select .select-result a:hover {
  background-position: right -15px;
}
.eliminateCriteria {
  display: none;
  line-height: 21px;
  margin-top: 4px;
  width: 35px;
  float: right;
  color: #f00;
  cursor: pointer;
}

/*排序*/
.sort {
  margin-top: 0px;
  width: 100%;
  border: hidden;
}
.sort li {
  float: left;
  width: 33.33%;
  height: 35px;
  line-height: 35px;
  text-align: center;
  padding: 0px 0px;
}
.sort li a {
  font-size: 14px;
}
.sort li.big {
  display: none;
}
.sort li.first {
  color: #f03726;
}

/*筛选条件*/
.select-list {
  float: left;
  display: inline;
  left: 0;
  width: 33.33%;
  height: 30px;
}

.select-list dl dt {
  left: 0px;
  cursor: pointer;
  top: -10px;
  text-align: center;
}
.select-list .dd-conent {
  display: none;
  float: left;
  top: 20px;
  padding-top: 5px;
  z-index: 10;
  left: 0px;
  width: 300%;
  position: absolute;
  background: #fff;
  overflow: hidden;
}
.select-list .dd-conent dd {
  width: 33.33%;
  text-align: center;
  margin-left: 0px;
  height: 25px;
}
dl#select2 .dd-conent {
  left: -100%;
  right: -100%;
}
dl#select3 .dd-conent {
  left: -200%;
  right: 0px;
}

.am-badge {
  font-size: 12px;
  padding: 0px 0px;
  background-color: #999999;
  color: #ffffff;
}
.theme-popover-mask {
  z-index: 5;
  width: 100%;
  height: auto;
  position: fixed;
  background: #000;
  top: 0;
  opacity: 0.6;
}
.theme-popover {
  width: 100%;
}

/*搜索结果*/
.i-pic.limit {
  margin: 5px;
  border: 1px #e8e8e8 solid;
  overflow: hidden;
  position: relative;
  cursor: pointer;
}
.number.fl {
  position: absolute;
  bottom: 5px;
  right: 5px;
}
.price.fl {
  padding: 5px;
}
/*分页*/
.am-pagination li {
  float: none;
}
.footer {
  margin-left: 0px;
}

.search-side {
  display: none;
}
.search-content {
  margin: 0px 5px;
}

.limit p.title,
.i-pic.check p.title {
  padding: 0px 5px;
  margin: 5px 0px;
  overflow: hidden;
  height: 18px;
  line-height: 18px;
}

@media only screen and (min-width: 640px) {
  .search-content {
    margin: 0px 0px;
  }
  .theme-popover {
    margin-left: 10px;
    margin-right: 10px;
    width: auto;
  }

  /* select */
  .select-list .dd-conent dd {
    width: auto;
    text-align: center;
    margin-left: 5px;
  }

  .select li.select-result {
    display: none;
  }
  .suggest,
  .searchAbout,
  ul.pagination {
    display: block;
  }
  .select .title.font-normal {
    margin-top: 0px;
    margin-left: 0px;
  }
  .select,
  .sort {
    padding: 5px 10px;
    box-shadow: 0px 0px 2px #999;
    margin-top: 5px;
    background: #fff;
  }
  .searchAbout {
    padding: 10px;
  }

  .select-list {
    width: 100%;
    padding: 0px 0px;
  }
  .select li {
    list-style: none;
    padding: 0px 0px 0px 100px;
    border-top: #eee 1px dashed;
    float: none;
    display: block;
    height: auto;
  }

  .select-result dl dt {
    width: 100px;
  }

  .eliminateCriteria {
    width: 80px;
    float: right;
    margin-right: 20px;
  }

  .am-badge {
    font-size: 14px;
    padding: 0px 0px;
    background: none;
    color: #000000;
  }

  /*排序*/
  .sort {
    padding: 0px 0px;
    border-radius: 0px 0px 4px 4px;
    margin: 10px 10px;
    font-size: 12px;
    width: auto;
    overflow: hidden;
  }
  .sort li {
    display: inline;
    height: 35px;
    line-height: 35px;
    padding: 0px 20px;
    width: auto;
    border-right: 1px dotted #ddd;
  }
  .sort li.big {
    display: block;
    border: none;
  }
  .sort li.first {
    background: #f5f5f5;
    color: #000;
  }

  /*筛选条件*/
  .select-list,
  .select-list dl {
    width: 100%;
  }
  .select dl dt {
    left: -100px;
    top: 10px;
  }
  .select-list dl dt {
    top: 5px;
  }
  .select dt {
    width: 100px;
    margin-left: 0;
    text-align: center;
    color: #666;
    height: 24px;
    line-height: 24px;
  }
  .select-list .dd-conent {
    display: inline-block;
    float: left;
    background: none;
    width: 100%;
    position: static;
  }
  dl#select2 .dd-conent,
  dl#select3 .dd-conent {
    left: 0;
    right: 0;
  }

  /*搜索结果*/
  .i-pic.limit {
    padding: 0px;
    margin: 10px;
    border: 1px #e8e8e8 solid;
    background: #fff;
  }
  li.select-result dl {
    padding: 10px 0px;
  }

  .scoll {
    margin-top: 70px;
  }
  .am-slider-default .am-direction-nav a {
    z-index: 0;
  }
  span.am-icon-th-list {
    color: orangered;
    margin-right: 1px;
  }

  /*改写的布局*/
  .flood li {
    width: 33.3%;
    float: left;
    text-align: center;
  }
  .smallnav img {
    max-width: 60px;
  }
  .smallnav {
    font-size: 14px;
  }

  /*文字布局*/
  .limit p.title,
  .i-pic.check p.title {
    padding: 0px 10px;
    overflow: hidden;
    height: 36px;
    line-height: 18px;
  }
  .i-pic .price.fl {
    font-size: 16px;
  }
}

@media only screen and (min-width: 1025px) {
  .search {
    margin: 0px 40px 0px 0px;
    padding-top: 10px;
  }
  .search-list {
    max-width: 1000px;
    margin: 0px auto;
    position: relative;
  }
  .nav.white {
    padding-left: 0px;
  }

  /*选中效果*/
  .search-list ul li:hover .i-pic.limit,
  .search-side li:hover .i-pic.check {
    box-shadow: 0px 12px 12px -10px rgba(0, 0, 0, 0.4);
  }
}

@media only screen and (min-width: 1260px) {
  .am-g-fixed {
    max-width: 1200px;
  }
  .search-list {
    max-width: 1200px;
    margin: 0px auto;
    position: relative;
  }
  .search-content {
    float: left;
    width: 80%;
  }
  .search-side {
    display: block;
    float: left;
    width: 20%;
    padding: 0px 10px;
  }
  .side-title {
    height: 35px;
    line-height: 35px;
    padding: 0px 20px;
    border-radius: 0px 0px 4px 4px;
    margin: 10px 0px;
    box-shadow: 0px 0px 2px #999;
    text-align: center;
    color: #e4393c;
    font-size: 14px;
    background: #fff;
  }
  .search-side li {
    width: 100%;
    overflow: hidden;
  }
  .i-pic.check {
    border: 1px solid #ddd;
    margin: 10px auto;
    overflow: hidden;
    cursor: pointer;
    background: #fff;
    position: relative;
  }
  .i-pic.check p.check-title {
    text-align: center;
  }
  .i-pic.check p.check-title {
    height: 36px;
    font-size: 20px;
    margin: 5px 10px;
  }
}
</style>
<style scoped>
[class*="am-u-"] {
  padding-left: 0;
  padding-right: 0;
}
.user-infoPic {
  overflow: hidden;
  position: relative;
  margin: 0px 10px;
  padding: 0px 5px 0px 0px;
  border-bottom: 1px solid #e4eaee;
}
.filePic {
  position: relative;
  width: 60px;
  text-align: center;
  float: right;
}
.inputPic {
  cursor: pointer;
  opacity: 0;
  ilter: alpha(opacity=0);
  width: 100%;
  height: 100%;
  position: absolute;
  top: 0;
  left: 0;
  z-index: 9;
}
p.am-form-help {
  font-size: 14px;
  font-weight: 600;
  margin: 0px auto;
  position: absolute;
  top: 25px;
  color: #000000;
}
.am-selected-list {
  font-size: 14px;
}
.am-img-thumbnail {
  padding: 0px;
  margin: 2px;
}
.info-m {
  display: none;
}

/*修改信息*/
.info-main {
  max-width: 800px;
  padding: 0px 10px;
}
.am-form-group {
  margin: 10px 0px;
  border-bottom: 1px solid #e4eaee;
  height: 34px;
}
.am-form-horizontal .am-form-label {
  padding-top: 8px;
  text-align: left;
}
.am-form textarea,
.am-form select,
.am-form textarea,
.am-form input[type="text"],
.am-form input[type="password"],
.am-form input[type="datetime"],
.am-form input[type="datetime-local"],
.am-form input[type="date"],
.am-form input[type="month"],
.am-form input[type="time"],
.am-form input[type="week"],
.am-form input[type="tel"],
.am-form input[type="email"],
.am-form input[type="url"],
.am-form input[type="search"],
.am-form input[type="tel"],
.am-form input[type="color"],
.am-form-field,
.am-btn {
  font-size: 14px;
}
.birth-select,
.birth-select2 {
  float: left;
  margin-right: 5px;
  vertical-align: middle;
}
.birth-select select {
  float: left;
  width: 60px;
  background: none;
  border: none;
  padding-top: 9px;
}
.birth-select2 select {
  float: left;
  width: 40px;
  background: none;
  border: none;
  padding-top: 9px;
}

.birth button {
  border: none;
}
.birth .am-selected-icon::before {
  opacity: 0;
}
.user-info {
  width: 100%;
  max-width: 900px;
  overflow: hidden;
}
.user-safety {
  width: 100%;
  max-width: 900px;
  overflow: hidden;
}

/*按钮*/
.info-btn {
  text-align: center;
}
.fore3 .am-btn-secondary {
  color: #000;
  background-color: transparent;
  border: none;
}

/*地址*/
.am-form-content.address a,
.am-form-group.safety a {
  width: 80%;
  float: right;
  text-align: right;
  padding-right: 5px;
}
p.new-mu_l2cw {
  margin: 0px;
}
p.new-mu_l2cw span {
  height: 17px;
  line-height: 17px;
}

/*性别*/
.sex .am-ucheck-icons {
  top: 8px;
}
/*安全设置*/
.user-safety .check {
  max-width: 900px;
}
.user-safety .check li {
  overflow: hidden;
  margin: 5px 10px;
  padding: 8px 0px;
  border-bottom: 1px solid #e4eaee;
}
.user-safety .check .m-left {
  float: left;
}
.user-safety .check .fore1 {
  width: 80px;
  font-size: 14px;
  font-weight: 600;
  line-height: 21px;
  padding-top: 5px;
}
.user-safety .check .fore2 {
  display: none;
  text-align: left;
  font-size: 12px;
  line-height: 21px;
}
.user-safety .check .fore3 {
  text-align: center;
  font-size: 12px;
  float: right;
  line-height: 21px;
}
.am-btn {
  padding: 5px;
}
.user-safety .check i {
  margin-left: 10px;
}
.user-safety .fore3 .am-btn {
  width: 70px;
}

/*表单配置*/
.am-form input[type="text"],
.am-form input[type="password"],
.am-form input[type="datetime"],
.am-form input[type="datetime-local"],
.am-form input[type="date"],
.am-form input[type="month"],
.am-form input[type="time"],
.am-form input[type="week"],
.am-form input[type="tel"],
.am-form input[type="email"],
.am-form input[type="url"],
.am-form input[type="search"],
.am-form input[type="tel"],
.am-form input[type="color"] {
  background: none;
  border: none;
}
input::-webkit-input-placeholder {
  text-align: right;
}
input {
  text-align: right;
}
.am-form-label {
  font-size: 14px;
  font-weight: 600;
  width: auto;
}
.sex,
.birth {
  float: right;
  padding-right: 5px;
  margin-left: 0;
}

.am-form-content small {
  display: none;
}
.am-selected {
  width: auto;
}

@media only screen and (min-width: 640px) {
  .am-form-group.address,
  .am-form-group.safety,
  .am-form-help {
    display: none;
  }
  .sex,
  .birth {
    float: none;
    margin-left: 85px;
  }
  .am-radio-inline input[type="radio"] {
    margin-left: 0px;
  }
  input::-webkit-input-placeholder,
  input {
    text-align: left;
  }
  .info-main {
    margin: 0% 5%;
  }
  .user-infoPic,
  .am-form-group {
    border: none;
  }
  .am-form-group {
    margin: 20px 0px;
  }
  .am-form input[type="text"],
  .am-form input[type="password"],
  .am-form input[type="datetime"],
  .am-form input[type="datetime-local"],
  .am-form input[type="date"],
  .am-form input[type="month"],
  .am-form input[type="time"],
  .am-form input[type="week"],
  .am-form input[type="tel"],
  .am-form input[type="email"],
  .am-form input[type="url"],
  .am-form input[type="search"],
  .am-form input[type="tel"],
  .am-form input[type="color"],
  .birth-select select,
  .birth-select2 select {
    border: 1px solid #e4eaee;
  }
  input {
    text-align: left;
  }
  .am-form-group {
    height: 50px;
  }
  .am-form-horizontal .am-form-label {
    padding-top: 8px;
  }
  .am-form-content small {
    display: block;
    margin: 5px 5px;
    color: #ccc;
  }
  /*生日*/

  .birth-select select,
  .birth-select2 select {
    -webkit-appearance: none !important;
    -moz-appearance: none !important;
    -webkit-border-radius: 0;
    background: #ffffff
      url("data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZlcnNpb249IjEuMSIgeD0iMTJweCIgeT0iMHB4IiB3aWR0aD0iMjRweCIgaGVpZ2h0PSIzcHgiIHZpZXdCb3g9IjAgMCA2IDMiIGVuYWJsZS1iYWNrZ3JvdW5kPSJuZXcgMCAwIDYgMyIgeG1sOnNwYWNlPSJwcmVzZXJ2ZSI+PHBvbHlnb24gcG9pbnRzPSI1Ljk5MiwwIDIuOTkyLDMgLTAuMDA4LDAgIi8+PC9zdmc+")
      no-repeat 100% center;
  }

  .birth-select {
    width: 38%;
    margin-right: 0;
    position: relative;
    height: 32px;
    line-height: 32px;
  }
  .birth-select2 {
    width: 30%;
    margin-right: 0;
    margin-left: 1%;
    position: relative;
    height: 32px;
    line-height: 32px;
  }
  .birth-select select,
  .birth-select2 select {
    width: 90%;
  }
  .birth-select em,
  .birth-select2 em {
    position: absolute;
    right: 0px;
  }
  .birth-select .am-selected,
  .birth-select2 .am-selected {
    width: auto;
    position: absolute;
    left: 0px;
    right: 20px;
  }
  .birth button {
    border: 1px solid #e4eaee;
  }
  .birth .am-selected-icon::before {
    opacity: 1;
    margin: 5px 0px 5px -10px;
  }
  .birth .am-selected-status {
    padding-top: 3px;
  }
  /*头像、安全评分*/
  .user-infoPic {
    position: relative;
    margin: 20px 5% 50px;
    height: 130px;
    border-bottom: 1px solid #eee;
  }
  .filePic {
    width: 100px;
    float: left;
    margin-left: 15px;
    margin-top: 15px;
  }
  .info-m {
    display: block;
    float: left;
    overflow: hidden;
    line-height: 24px;
    position: absolute;
    left: 6%;
    top: 25px;
    margin-left: 120px;
  }
  .safeText {
    display: block;
    color: #fff;
    position: relative;
    text-align: left;
  }
  .progressBar {
    width: 190px;
    height: 8px;
    position: relative;
    overflow: hidden;
    border-radius: 5px;
    margin-top: 5px;
  }
  .progress {
    width: 190px;
    height: 8px;
    position: absolute;
    top: 0;
    background-color: #ffeb68;
    border-radius: 5px;
  }
  /*会员*/
  .vip {
    margin-top: 15px;
  }
  .vip span {
    display: block;
    width: 51px;
    height: 22px;
    float: left;
    margin-right: 5px;
  }
  .user-info {
    overflow: hidden;
    margin-bottom: 15px;
  }
  /*安全设置*/
  .user-safety .check li {
    padding: 15px 0px;
    position: relative;
    border: none;
  }
  .user-safety .check .fore2 {
    display: block;
  }
  .user-safety .check .fore1 {
    width: 100px;
    font-size: 16px;
  }
  /*小图标*/
  .user-safety .check i {
    left: 0;
    display: inline-block;
    vertical-align: middle;
    background-image: url("../../assets/images/sprite.png");
    width: 40px;
    height: 40px;
    position: absolute;
    margin-top: 5px;
  }
  .i-safety-lock {
    background-position: -90px -45px;
  }
  .i-safety-wallet {
    background-position: 0px -135px;
  }
  .i-safety-iphone {
    background-position: -45px 0px;
  }
  .i-safety-mail {
    background-position: 0px -90px;
  }
  .i-safety-idcard {
    background-position: -90px -90px;
  }
  .i-safety-security {
    background-position: -135px -45px;
  }

  .user-safety .check .m-left {
    margin-left: 70px;
  }
  .user-safety .check .fore3 {
    margin-top: 10px;
  }
  /*按钮*/
  .fore3 .am-btn-secondary {
    color: #fff;
    background-color: #3bb4f2;
    border: 1px solid #3bb4f2;
  }
}

@media only screen and (min-width: 1025px) {
  .info-main {
    margin: 0% 10%;
  }
  .user-safety .check ul {
    margin: 0 5%;
  }
}
@media only screen and (min-width: 1260px) {
}

/*公共*/
html,
body,
div,
span,
applet,
object,
iframe,
h1,
h2,
h3,
h4,
h5,
h6,
p,
blockquote,
pre,
a,
abbr,
acronym,
address,
big,
cite,
code,
del,
dfn,
em,
img,
ins,
kbd,
q,
s,
samp,
small,
strike,
strong,
sub,
sup,
tt,
var,
b,
u,
i,
center,
dl,
dt,
dd,
ol,
ul,
li,
fieldset,
form,
label,
legend,
table,
caption,
tbody,
tfoot,
thead,
tr,
th,
td,
article,
aside,
canvas,
details,
embed,
figure,
figcaption,
footer,
header,
hgroup,
menu,
nav,
output,
ruby,
section,
summary,
time,
mark,
audio,
video {
  margin: 0;
  padding: 0;
  border: 0;
  font-size: 100%;
  font-size: 12px;
  font: inherit;
  vertical-align: baseline;
  font-family: arial, "Lantinghei SC", "Microsoft Yahei";
}
/* HTML5 display-role reset for older browsers */
article,
aside,
details,
figcaption,
figure,
footer,
header,
hgroup,
menu,
nav,
section,
main {
  display: block;
}
ul,
li,
ol {
  list-style: none;
}
dl,
dd {
  margin: auto;
}

html {
  width: 100%;
  height: 100%;
  -ms-text-size-adjust: none;
  -webkit-text-size-adjust: none;
  -moz-text-size-adjust: none;
  -o-text-size-adjust: none;
}
/*text-size-adjust不管屏幕怎么变文字大小不变*/

body {
  margin: 0;
  padding: 0;
  width: 100%;
  font-size: 12px;
  font-family: arial, "Lantinghei SC", "Microsoft Yahei";
  background: #f5f8fa none repeat scroll 0% 0%;
}

a:link,
a:visited {
  text-decoration: none;
  outline: none;
  color: #000;
}
/*所有超链接不要下划线*/
* {
  padding: 0;
  margin: 0;
}
； *,
*:after,
*:before {
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  -o-box-sizing: border-box;
  box-sizing: border-box;
}
/*任何标签、包括它前面、后面生成的内容都不要影响盒子的边框*/
.am-form textarea,
.am-form select,
.am-form textarea,
.am-form input[type="text"],
.am-form input[type="password"],
.am-form input[type="datetime"],
.am-form input[type="datetime-local"],
.am-form input[type="date"],
.am-form input[type="month"],
.am-form input[type="time"],
.am-form input[type="week"],
.am-form input[type="tel"],
.am-form input[type="email"],
.am-form input[type="url"],
.am-form input[type="search"],
.am-form input[type="tel"],
.am-form input[type="color"],
.am-form-field,
.am-btn {
  font-size: 14px;
}

.clear {
  clear: both;
}
header {
  display: none;
}

/*选项卡样式定义*/
.am-nav-tabs,
.am-tabs-bd {
  border-color: transparent;
}
.am-nav-tabs > li.am-active > a,
.am-nav-tabs > li.am-active > a:hover,
.am-nav-tabs > li.am-active > a:focus,
.am-nav-tabs > li > a:hover {
  color: #555555;
  background: none;
  border-color: transparent;
  cursor: default;
}
.am-nav-tabs > li > a {
  margin-right: 0px;
}
.am-nav-tabs > li.am-active {
  border-bottom: 2px solid #f03726;
}
.am-tabs-d2 .am-tabs-nav li {
  max-width: 216px;
}
/*选项卡样式*/
.am-nav-tabs > li {
  cursor: pointer;
}
.am-nav-tabs > li > a {
  padding: 0px 2px;
  margin: 0px 0px;
  text-align: center;
}

.nav-table {
  display: none;
}
/*主体部分*/
.center {
  width: 100%;
  margin: 0px auto;
  min-height: 1px;
  overflow: hidden;
}
aside,
.wrap-right,
.m-logistics,
.you-like {
  display: none;
}
.col-main {
  padding-bottom: 50px;
}
/*标题*/
.am-text-lg {
  font-size: 18px;
}
.am-padding {
  padding: 0px 10px;
}
.am-padding small {
  width: 50%;
}
hr {
  margin: 5px 0px;
}

/*表单布局*/
.am-form-label {
  width: 50px;
  float: left;
  text-align: right;
}
.am-form-content {
  margin-left: 65px;
}
.col-main {
  padding-top: 10px;
  background-color: #fff;
}

/*博客*/
.bloglist .am-u-md-9 {
  background: #fff;
}
.blog-main {
  max-width: 760px;
  margin: 0px auto;
}
.blog-sidebar {
  padding: 0px 0px;
}
.blog-list li {
  border: none;
}
.blog-list li p {
  white-space: nowrap; /* 不换行 */
  overflow: hidden;
  text-overflow: ellipsis;
}
.am-panel-hd {
  font-size: 18px;
  padding: 1rem 1rem;
}
.blog-title a {
  font-size: 20px;
  margin: 10px auto;
}
.blog-meta {
  font-size: 14px;
  text-align: right;
}
.blog-content p {
  font-size: 14px;
  line-height: 24px;
  text-indent: 2em;
}
.blog-content .Row li {
  width: 33.33%;
  float: left;
  padding: 5px;
}
.blog-content img {
  width: 100%;
}
.blog-tit p {
  color: rgb(89, 89, 89);
  text-indent: 0em;
  margin-top: 10px;
}
.blog-tit p span {
  font-family: Microsoft YaHei !important;
  color: rgb(192, 0, 0);
  font-size: 18px;
}
/*底部*/

.footer {
  display: none;
  text-align: center;
  border-top: 2px solid #f8f8f8;
  margin-top: 20px;
  padding-top: 5px;
}
.main-wrap {
  background-color: #fff;
}
@media only screen and (min-width: 640px) {
  html,
  body,
  div,
  span,
  applet,
  object,
  iframe,
  h1,
  h2,
  h3,
  h4,
  h5,
  h6,
  p,
  blockquote,
  pre,
  a,
  abbr,
  acronym,
  address,
  big,
  cite,
  code,
  del,
  dfn,
  em,
  img,
  ins,
  kbd,
  q,
  s,
  samp,
  small,
  strike,
  strong,
  sub,
  sup,
  tt,
  var,
  b,
  u,
  i,
  center,
  dl,
  dt,
  dd,
  ol,
  ul,
  li,
  fieldset,
  form,
  label,
  legend,
  table,
  caption,
  tbody,
  tfoot,
  thead,
  tr,
  th,
  td,
  article,
  aside,
  canvas,
  details,
  embed,
  figure,
  figcaption,
  footer,
  header,
  hgroup,
  menu,
  nav,
  output,
  ruby,
  section,
  summary,
  time,
  mark,
  audio,
  video {
    font-size: 14px;
  }

  /*头*/
  header {
    display: block;
  }
  header article {
    max-width: 1200px;
    margin: 0px auto;
  }
  .mt-logo .mt-tblogo {
    width: 20%;
    display: inline-block;
    vertical-align: middle;
  }
  .message-l {
    float: left;
  }
  .message-l .topMessage {
    padding: 0px 6px;
    height: 35px;
    line-height: 35px;
  }
  .message-r {
    float: right;
  }
  .message-r .topMessage {
    float: left;
    padding: 0px 6px;
    height: 35px;
    line-height: 35px;
  }
  /*浮动框*/
  .nav.white {
    width: 100%;
    margin: 0px auto;
  }
  .nav.white .logoBig {
    display: block;
    float: left;
    height: 56px;
    width: 115px;
    margin: 0px auto;
    margin-left: 5%;
  }
  .nav.white .logoBig img {
    width: 100%;
  }
  .my-cart {
    width: 46px;
    height: 46px;
  }

  #ai-topsearch {
    height: 46px;
  }
  .search-bar input {
    width: 80%;
    height: 46px;
  }
  .classified {
    display: none;
  }
  .nav.white {
    position: relative;
    top: 0px;
    z-index: 0;
  }

  /*搜索框*/
  .search-bar {
    height: 51px;
    margin: 0px 50px 0 120px;
    padding-left: 5%;
  }
  .search-bar form {
    border: 2px solid #f03726;
    max-width: 670px;
  }
  .search-bar input {
    padding-left: 5px;
    width: 80%;
    height: 46px;
    outline: none;
    font-size: 12px;
    border: none;
  }
  #ai-topsearch {
    width: 20%;
    height: 46px;
    border: 0px none;
    float: right;
    background: #f03726 none repeat scroll 0% 0%;
    color: #f5f5f2;
    font-size: 14px;
    cursor: pointer;
  }

  /*固定框架*/
  .center {
    width: 96%;
    max-width: 1000px;
    margin: 0px auto;
    min-height: 1px;
    margin-top: 15px;
  }

  /*表单布局*/
  .am-form-label {
    width: 100px;
    float: left;
  }
  .am-form-content {
    margin-left: 85px;
  }

  /*侧边栏*/
  aside {
    display: block;
    width: 130px;
    float: left;
    margin-left: -100%;
    padding-top: 10px;
  }
  aside ul {
    margin-left: 10px;
    margin-right: -10px;
    padding: 0px 8px;
    font-size: 14px;
    background: #fff;
    border-top: 5px solid #fec4d7;
  }
  aside a {
    display: block;
    overflow: hidden;
    text-decoration: none;
    line-height: 28px;
    color: #000;
    height: 28px;
  }
  aside ul li {
    text-align: center;
  }
  aside ul li.active a {
    color: #f69;
  }
  li.person {
    border-bottom: 1px solid #f5f8fa;
    padding-bottom: 10px;
    padding-top: 10px;
  }
  .person ul {
    padding-left: 6px;
    border: none;
    padding-top: 0px;
    padding-bottom: 0px;
    margin: 0px auto;
    font-size: 12px;
  }
  .person ul li a {
    color: #666;
  }
  /*主题*/
  .col-main {
    float: left;
    width: 100%;
    min-height: 1px;
    background: none;
    padding-bottom: 0px;
  }
  .main-wrap {
    position: relative;
    margin-left: 150px;
    overflow: hidden;
    min-height: 585px;
    background-color: #fff;
  }
  .am-fl.am-cf small {
    width: auto;
  }
  .am-padding {
    margin: 20px 0px;
  }
  .am-text-danger {
    color: #000;
  }
  /*底部*/
  .footer {
    text-align: left;
    display: block;
    position: relative;
    margin: 0px auto;
    padding: 7px 0px 9px;
    border-top: 2px solid #ff5400;
    margin-top: 20px;
  }
  .footer .footer-bd p,
  .footer .footer-hd p {
    margin-bottom: 8px;
    line-height: 27px;
    border-bottom: 1px solid #ddd;
    text-align: left;
  }
  .footer .footer-hd a {
    margin: 0px 4px;
    white-space: nowrap;
    color: #6c6c6c;
  }
  .footer .footer-hd b {
    margin: 0px 3px;
    font-weight: 400;
    color: #ddd;
  }
  .footer .footer-bd p {
    border-bottom: none;
  }
  .footer-bd {
    display: block;
  }

  /*博客*/
  .blog-main {
    margin-top: 10px;
  }
  .blog-sidebar {
    padding: 0px 10px;
  }
}

@media only screen and (min-width: 1025px) {
  .nav.white {
    padding-left: 0px;
    max-width: 1000px;
    margin: 0px auto;
  }
  .nav.white .logoBig {
    display: block;
    float: left;
    height: 90px;
    width: 200px;
    margin-left: 0px;
  }
  .nav.white .logoBig li {
    float: left;
  }
  .search-bar {
    height: 90px;
    padding: 20px 70px 0 230px;
    margin: auto;
  }

  /*分类*/
  .nav-table {
    max-width: 1000px;
    margin: 0px auto;
    height: 45px;
    position: relative;
    overflow: hidden;
    display: block;
    margin-top: 10px;
  }
  .nav-table .all-goods {
    font-size: 16px;
  }
  .long-title {
    background: #d2364c;
    color: #fff;
    height: 45px;
    line-height: 45px;
    display: block;
    position: absolute;
    width: 150px;
    text-align: center;
    font-size: 16px;
    top: 0px;
    z-index: 6;
  }
  .nav-cont {
    position: absolute;
    padding-left: 150px;
    display: block;
    width: 100%;
    top: 0px;
  }
  .nav-cont li {
    float: left;
    height: 45px;
    line-height: 45px;
  }
  .nav-cont li::before {
    content: "\20";
    display: inline-block;
    height: 16px;
    border-right: 1px solid #d9d9d9;
    width: 0;
    vertical-align: middle;
    margin-left: -1px;
  }
  .nav-cont li a {
    font-size: 16px;
    color: #333;
    line-height: 36px;
    margin-left: -1px;
    padding: 0 25px;
    text-decoration: none;
    font-weight: 700;
    display: inline-block;
    vertical-align: middle;
  }

  .nav-cont .nav-extra {
    position: absolute;
    right: 0px;
    top: 6px;
    font-size: 16px;
    color: #fcff00;
    line-height: 33px;
    height: 33px;
    width: 160px;
    text-align: center;
    background: url(../../assets/images/extra.png);
    cursor: pointer;
  }
  .nav-cont .nav-extra i.nav-user {
    background: #000;
    color: #fff;
    width: 33px;
    height: 33px;
    border-radius: 33px;
    position: absolute;
    left: -28px;
    z-index: 99;
    padding: 5px;
    overflow: hidden;
  }
  .nav-cont .nav-extra b {
    display: block;
    position: absolute;
    width: 45px;
    height: 45px;
    border-radius: 45px;
    z-index: 1;
    left: -33px;
    top: -8px;
    background: #fff;
  }
  b.line {
    display: block;
    width: 100%;
    height: 2px;
    border-bottom: 2px solid #d2364c;
  }

  .bloglist {
    padding-top: 20px;
  }
  .blog-content p {
    font-size: 16px;
    line-height: 24px;
  }
}

@media only screen and (min-width: 1260px) {
  /*分类*/
  .nav-table,
  .footer {
    max-width: 1200px;
  }
  .long-title {
    width: 180px;
  }
  .nav-cont {
    padding-left: 180px;
  }
  /*固定框架*/
  .center {
    width: 96%;
    max-width: 1200px;
    margin: 0px auto;
    min-height: 1px;
    margin-top: 15px;
  }
  aside {
    width: 160px;
  }
  .main-wrap {
    margin-left: 180px;
  }
  .am-container,
  .bloglist {
    max-width: 1200px;
  }
  /*博客*/
  .blog-main {
    margin-top: 30px;
  }
}
</style>