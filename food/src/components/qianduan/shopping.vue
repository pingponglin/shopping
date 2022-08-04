<template>
<el-scrollbar class="page_scroll">

  <div class="shopadd">
    <!--顶部导航条 -->
    <div class="am-container header">
      <ul class="message-r">
        <div class="topMessage home">
          <div class="menu-hd">
            <a href="#" target="_top" class="h" @click="s"
              >商城首页</a
            >
          </div>
        </div>
        <div class="topMessage my-shangcheng">
          <div class="menu-hd MyShangcheng">
            <a href="#" target="_top" @click="goodusers"
              ><i class="am-icon-user am-icon-fw"></i>个人中心</a
            >
          </div>
        </div>
        <div class="topMessage mini-cart">
          <div class="menu-hd">
            <a id="mc-menu-hd" href="#" @click="goodshopp" target="_top"
              ><i class="am-icon-shopping-cart am-icon-fw"></i>
              <span>购物车</span
              ><strong id="J_MiniCartNum" class="h"></strong></a
            >
          </div>
        </div>
        <div class="topMessage favorite">
          <div class="menu-hd">
            <a href="#" target="_top" @click="goodfoot"
              ><i class="am-icon-heart am-icon-fw"></i><span>收藏夹</span>
            </a>
          </div>
        </div>
        <div class="topMessage favorite">
          <div class="menu-hd">
            <a href="#" target="_top"
              ><span @click="tui" v-show="zhus()">退出</span></a
            >
          </div>
        </div>
      </ul>
    </div>
    <!--悬浮搜索框-->
    <div class="nav white">
      <div class="logo"><img src="../../assets/images/logo.png" /></div>
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
            autocomplete="off"
          />
          <input
            id="ai-topsearch"
            class="submit am-btn"
            value="搜索"
            index="1" @click="shuosuo"
            type="submit"
          />
        </form>
      </div>
    </div>
    <div class="clear"></div>
    <b class="line"></b>
    <div class="listMain">
      <!--分类-->
      <div class="nav-table">
        <div class="long-title"><span class="all-goods">全部分类</span></div>
        <div class="nav-cont">
          <ul>
            <li class="index"><a href="#" @click="s" target="_top">首页</a></li>
            <li class="qc">
              <a
                href="https://www.tmall.com/?spm=a21bo.21814703.201859.1.49fa11d9BdGwQk"
                >天猫</a
              >
            </li>
            <li class="qc">
              <a target="_blank"
                href="https://pages.tmall.com/wow/a/act/ju/dailygroup/2199/wupr?wh_pid=daily-222239&bid=3&spm=a21bo.21814703.201859.2.49fa11d9BdGwQk"
                >聚划算</a
              >
            </li>
            <li class="qc">
              <a target="_blank"
                href="https://chaoshi.tmall.com/?spm=a21bo.21814703.201859.3.49fa11d9BdGwQk"
                >天猫超市</a
              >
            </li>
            <li class="qc last">
              <a target="_blank"
                href="https://www.fliggy.com/?spm=a21bo.21814703.201859.5.49fa11d9BdGwQk"
                >飞猪旅行</a
              >
            </li>
          </ul>
        </div>
      </div>
      <ol class="am-breadcrumb am-breadcrumb-slash">
        <li><a href="#">首页</a></li>
        <li><a href="#">分类</a></li>
        <li class="am-active">内容</li>
      </ol>
      <div class="scoll">
        <section class="slider"></section>
      </div>

      <!--放大镜-->

      <div class="item-inform">
        <div class="clearfixLeft" id="clearcontent">
          <div class="box">
            <div class="choose" ref="choose">
              <div
                class="content"
                ref="content"
                @mousemove="handleMove"
                @mouseout="handleOut"
              >
                 <img :src="ImgUrl" />
                <div class="shadow" ref="shadow"></div>
              </div>
              <div style="display: flex">
                <ul v-for="img in imgUrl" :key="img.index" id="listshow">
                              
                  <li @click="getIndex(img.url)" class="selected">
                                    <img :src="img.url" />             
                  </li>
                          
                </ul>
              </div>
            </div>
            <div class="larger" ref="larger">
              <img :src="imgsrc" ref="big" />
            </div>
          </div>

          <div class="clear"></div>
        </div>

        <div
          class="clearfixRight"
          v-for="good in goodparam"
          :key="good.Paramid"
        >
          <!--规格属性-->
          <!--名称-->
          <div class="tb-detail-hd">
            <h1>
              {{ good.Good.GoodfuName }}
            </h1>
          </div>
          <div class="tb-detail-list">
            <!--价格-->
            <div class="tb-detail-price">
              <li class="price iteminfo_price">
                <dt style="font-size: 15px;font-weight: bold;color: black;">促销价:</dt>
                <dd>
                  <em>¥</em
                  ><b class="sys_item_price">{{ good.Good.GoodPrcieper }}</b>
                </dd>
              </li>
              <li class="price iteminfo_mktprice">
                <dt style="font-size: 15px;font-weight: bold;color: black;">原价:</dt>
                <dd>
                  <em>¥</em
                  ><b class="sys_item_mktprice">{{ good.Good.GoodPrice }}</b>
                </dd>
              </li>
              <div class="clear"></div>
            </div>
            <div class="clear"></div>

            <!--销量-->
            <ul class="tm-ind-panel">
              <li>
                <div>
                  <span class="tm-label" style="font-size: 15px;font-weight: bold;color: black;">月销量:</span
                  ><span class="tm-count">{{ good.Good.Goodsales }}</span>
                </div>
              </li>
            </ul>
            <div class="clear"></div>
            <!--各种规格-->
            <dl class="iteminfo_parameter sys_item_specpara">
              <dt class="theme-login">
                <div class="cart-title">
                  可选规格<span class="am-icon-angle-right"></span>
                </div>
              </dt>
              <dd>
                <!--操作页面-->

                <div class="theme-popover-mask"></div>

                <div class="theme-popover">
                  <div class="theme-span"></div>
                  <div class="theme-poptit">
                    <a href="javascript:;" title="关闭" class="close">×</a>
                  </div>
                  <div class="theme-popbod dform">
                    <form
                      class="theme-signin"
                      name="loginform"
                      action=""
                      method="post"
                    >
                      <div class="theme-signin-left">
                        <div class="theme-options">
                          <div class="cart-title" style="font-size: 15px;font-weight: bold;color: black;">口味:</div>
                          <el-radio-group class="el-radio__label"
                            v-model="radio1"
                            v-for="kowei in goodkoweis"
                            :key="kowei.Goodkoweiid"
                          >
                            <el-radio-button
                              :label="kowei.Goodkoweiname"
                            ></el-radio-button
                            ><br />
                          </el-radio-group>
                        </div>
                        <div class="theme-options">
                          <div class="cart-title number" style="font-size: 15px;font-weight: bold;color: black;">数量:</div>
                          <el-input-number
                            v-model="num"
                            @change="handleChange"
                            :min="1"
                            :max="good.Good.Goodnum"
                            label="描述文字"
                          ></el-input-number>
                          <span id="Stock" class="tb-hidden" style="font-size: 15px;color: black;margin-left: 20px;"
                            >库存:<span class="stock">{{
                              good.Good.Goodnum
                            }}</span
                            >件</span
                          >
                        </div>
                        <div class="clear"></div>
                      </div>
                    </form>
                  </div>
                </div>
              </dd>
            </dl>
            <div class="clear"></div>
          </div>
          <div class="pay">
            <div class="pay-opt">
              <a href="home.html"
                ><span class="am-icon-home am-icon-fw">首页</span></a
              >
              <a><span class="am-icon-heart am-icon-fw">收藏</span></a>
            </div>
            <li>
              <div class="clearfix tb-btn tb-btn-buy theme-login">
                <a
                  id="LikBuy"
                  title="点此按钮到下一步确认购买信息"
                  href="#"
                  @click="gouma"
                  >立即购买</a
                >
              </div>
            </li>
            <li>
              <div class="clearfix tb-btn tb-btn-basket theme-login">
                <a id="LikBasket" title="加入购物车" href="#" @click="gouwu"
                  ><i></i>加入购物车</a
                >
              </div>
            </li>
          </div>
        </div>

        <div class="clear"></div>
      </div>

      <div class="clear"></div>

      <!-- introduce-->

      <div class="introduce" v-for="goods in goodparam" :key="goods.Paramid">
        <div class="browse">
          <div class="mc">
            <ul>
              <div class="mt">
                <h2>看了又看</h2>
              </div>
              <li
                class="first"
                v-for="(itemsd, index) in goodlists"
                :key="itemsd.index"
              >
                <div class="p-img" v-if="index < 5">
                  <a href="#">
                    <img
                      class=""
                      :src="'http://81.68.132.153:7070/img/' + itemsd.GoodImage"
                    />
                  </a>
                </div>
                <div class="p-name" v-if="index < 3">
                  <a href="#">
                    {{ itemsd.GoodName }}
                  </a>
                </div>
                <div class="p-price" v-if="index < 3">
                  <strong>￥{{ itemsd.GoodPrice }}</strong>
                </div>
              </li>
            </ul>
          </div>
        </div>
        <div class="introduceMain">
          <div class="am-tabs" data-am-tabs>
            <ul class="am-avg-sm-3 am-tabs-nav am-nav am-nav-tabs">
              <li class="am-active">
                <a href="#">
                  <span class="index-needs-dt-txt">宝贝详情</span></a
                >
              </li>

              <li>
                <a href="#">
                  <span class="index-needs-dt-txt">全部评价</span></a
                >
              </li>
            </ul>

            <div class="am-tabs-bd">
              <div class="am-tab-panel am-fade am-in am-active">
                <div class="J_Brand">
                  <div class="attr-list-hd tm-clear">
                    <h4>产品参数：</h4>
                  </div>
                  <div class="clear"></div>
                  <ul id="J_AttrUL">
                    <li title="">原料产地:&nbsp;{{ goods.Paramsite }}</li>
                    <li title="">产地:&nbsp;{{ goods.Paramproduct }}</li>
                    <li title="">产品规格:&nbsp;{{ goods.Paramcontent }}</li>
                    <li title="">保质期:&nbsp;{{ goods.Paramdate }}天</li>
                    <li title="">产品标准号:&nbsp;{{ goods.Paramstandard }}</li>
                    <li title="">
                      生产许可证编号：&nbsp;{{ goods.ParamProductionid }}
                    </li>
                    <li title="">储存方法：&nbsp;{{ goods.Parammethod }}</li>
                    <li title="">食用方法：&nbsp;{{ goods.Paramedible }}</li>
                  </ul>
                  <div class="clear"></div>
                </div>

                <div class="details">
                  <div class="attr-list-hd after-market-hd">
                    <h4>商品细节</h4>
                  </div>
                  <div class="twlistNews">
                    <img
                      :src="'http://81.68.132.153:7070/img/' + goods.Goodimage1"
                    />
                    <img
                      :src="'http://81.68.132.153:7070/img/' + goods.Goodimage2"
                    />
                    <img
                      :src="'http://81.68.132.153:7070/img/' + goods.Goodimage3"
                    />
                    <img
                      :src="'http://81.68.132.153:7070/img/' + goods.Goodimage4"
                    />
                  </div>
                </div>
                <div class="clear"></div>
              </div>

              <div class="am-tab-panel am-fade">
                <!-- <div class="actor-new">
                  <div class="rate">
                    <strong>100<span>%</span></strong
                    ><br />
                    <span>好评度</span>
                  </div>
                  <dl>
                    <dt>买家印象</dt>
                    <dd class="p-bfc">
                      <q class="comm-tags"
                        ><span>味道不错</span><em>(2177)</em></q
                      >
                      <q class="comm-tags"
                        ><span>颗粒饱满</span><em>(1860)</em></q
                      >
                      <q class="comm-tags"
                        ><span>口感好</span><em>(1823)</em></q
                      >
                      <q class="comm-tags"
                        ><span>商品不错</span><em>(1689)</em></q
                      >
                      <q class="comm-tags"
                        ><span>香脆可口</span><em>(1488)</em></q
                      >
                      <q class="comm-tags"
                        ><span>个个开口</span><em>(1392)</em></q
                      >
                      <q class="comm-tags"
                        ><span>价格便宜</span><em>(1119)</em></q
                      >
                      <q class="comm-tags"
                        ><span>特价买的</span><em>(865)</em></q
                      >
                      <q class="comm-tags"><span>皮很薄</span><em>(831)</em></q>
                    </dd>
                  </dl>
                </div> -->
                <div class="clear"></div>
                <!-- <div class="tb-r-filter-bar">
                  <ul class="tb-taglist am-avg-sm-4">
                    <li class="tb-taglist-li tb-taglist-li-current">
                      <div class="comment-info">
                        <span>全部评价</span>
                        <span class="tb-tbcr-num">({{quanbupi}})</span>
                      </div>
                    </li>

                    <li class="tb-taglist-li tb-taglist-li-1">
                      <div class="comment-info">
                        <span>好评</span>
                        <span class="tb-tbcr-num">({{youpi}})</span>
                      </div>
                    </li>

                    <li class="tb-taglist-li tb-taglist-li-0">
                      <div class="comment-info">
                        <span>中评</span>
                        <span class="tb-tbcr-num">({{zhongpi}})</span>
                      </div>
                    </li>

                    <li class="tb-taglist-li tb-taglist-li--1">
                      <div class="comment-info">
                        <span>差评</span>
                        <span class="tb-tbcr-num">({{chapi}})</span>
                      </div>
                    </li>
                  </ul>
                </div> -->
                <div class="clear"></div>

                <ul class="am-comments-list am-comments-list-flip">
                  <li class="am-comment" v-for="pingjiasd in pingjialist" :key="pingjiasd.Scoreid">
                    <!-- 评论容器 -->
                    <a href="">
                      <img
                        class="am-comment-avatar"
                        :src="'http://81.68.132.153:7070/img/'+pingjiasd.Userxix.Userxixnich"
                      />
                      <!-- 评论者头像 -->
                    </a>

                    <div class="am-comment-main">
                      <!-- 评论内容容器 -->
                      <header class="am-comment-hd">
                        <!--<h3 class="am-comment-title">评论标题</h3>-->
                        <div class="am-comment-meta">
                          <!-- 评论元数据 -->
                          <a href="#link-to-user" class="am-comment-author"
                            >{{pingjiasd.Userxix.Userxixname}}</a
                          >
                          <!-- 评论者 -->
                          评论于
                          <time datetime="">{{pingjiasd.Scoredate | dateFormat}}</time>
                        </div>
                      </header>

                      <div class="am-comment-bd">
                        <div class="tb-rev-item" data-id="255776406962">
                          <div class="J_TbcRate_ReviewContent tb-tbcr-content">
                            {{pingjiasd.Scoreidcontent}}
                          </div>
                          <div class="tb-r-act-bar">
                <div class="filePic" style="display: flex;">
                                <div v-for="or in pingjiasd.imaged" :key="or.index">
                                <img :src="'http://81.68.132.153:7070/img/'+or" style="width:100px;height:100px;">
                                </div>
                                </div>
                          </div>
                        </div>
                      </div>
                      <!-- 评论内容 -->
                    </div>
                  </li>
                </ul>
                <div class="clear"></div>
                <!--分页 -->
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
                <div class="clear"></div>
                <div class="tb-reviewsft">
                  <div class="tb-rate-alert type-attention">
                    购买前请查看该商品的
                    <a href="#" target="_blank">购物保障</a
                    >，明确您的售后保障权益。
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="clear"></div>
          <div class="footer">
							<div class="footer-hd">
								<p>
									<a href="#">关于熙林食品零售商城</a>
									<b>|</b>
									<a href="#">商城详情</a>
									<b>|</b>
									<a href="https://aiqicha.baidu.com/company_detail_32280303359195?rq=es&pd=ee&from=ps">支付宝</a>
									<b>|</b>
									<a href="https://www.kuaidi100.com/?from=openv">物流</a>
								</p>
							</div>
							<div class="footer-bd">
								<p>
									<a href="#">关于熙林食品零售商城</a>
									<a href="#">合作伙伴</a>
									<a href="#">联系我们</a>
									<a href="#">网站地图</a>
									<em>© 2015-2025 Hengwang.com 版权所有</em>
								</p>
							</div>
						</div>
        </div>
      </div>
    </div>
    <!--菜单 -->
    <div class="tip">
      <div id="sidebar" style="background-color: white">
        <div id="wrap">
          <div class="quick_toggle">
            <li class="qtitem">
              <a href="#top" class="return_top"><span class="top"></span></a>
            </li>
          </div>
          <!--回到顶部 -->
          <div id="quick_links_pop" class="quick_links_pop hide"></div>
        </div>
      </div>
    </div>
    <el-dialog title="登录" :visible.sync="dialogVisible" width="30%">
      <el-form
        :model="ruleForm"
        ref="ruleForm"
        label-width="100px"
        class="demo-ruleForm"
      >
        <el-form-item
          prop="name"
          label="用户名"
          style="position: relative; top: 0px; left: 0px"
        >
          <el-input
            v-model="ruleForm.name"
            prefix-icon="el-icon-user-solid"
            placeholder="邮箱/手机/用户名"
          ></el-input>
        </el-form-item>
        <el-form-item
          label="密码"
          style="position: relative; top: 0px; left: 0px"
          prop="password"
        >
          <el-input
            v-model="ruleForm.password"
            prefix-icon="el-icon-s-goods"
            placeholder="请输入密码"
            show-password
          ></el-input>
        </el-form-item>
      </el-form>
      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="dengliu">确 定</el-button>
      </span>
    </el-dialog>
  </div>
  </el-scrollbar>
</template>

<script>
import "../../assets/AmazeUI-2.4.2/assets/js/amazeui.js";
// import "../../assets/basic/js/quick_links.js";
// import "../../assets/js/jquery.imagezoom.min.js";
// import "../../assets/js/jquery.flexslider.js";
// import "../../assets/js/list.js";
export default {
  data() {
    return {
      imgUrl: [
        { index: 0, url: "" },
        { index: 1, url: "" },
        { index: 2, url: "" },
        { index: 3, url: "" },
        { index: 4, url: "" },
      ], //大图片默认显示第一张
      ImgUrl: "",
      //接受商品名称
      names: "",
      //判断用户有没有登录
      namess: "",
      //接收商品属性
      goodparam: [],
      //
      goodkoweis: [],
      //口味复选框
      radio1: "",
      //放大的第一张图片
      imgsrc: "",
      //数量
      num: 0,
      //控制用户登录是否显示
      dialogVisible: false,
      ruleForm: {
        name: "",
        password: "",
      },
      //获取所有商品
      goodlists: [],
      //获取购物车信息
      shopping: {},
      shoppingss: {
        Goodid: 0,
        Userxixid: 0,
        shoppingnum: 0,
        shoppingdate: "",
        shoppingmoney: "",
      },
      //接收用户的id
      usid:"",
      //添加收藏的数据
      footprint:{
      Goodid:0,footprintdate:"",Userxixid:0
      },
      pingjialist:[
        {
          Good:"",
          Goodid:"",
          Order:"",
          Orderid:"",
          Scoredate:"",
          Scoreid:"",
          Scoreidcontent:"",
          Scoreidpf:"",
          Scoreimage:"",
          Userxix:"",
           Userxixid:"",
           imaged:""
        }
      ],
      url:[],
      goodids:"",
       //当前的页数
      pagenum: 1,
      //当前每页的数据
      pagesize: 5,
      //获取总共的页数
      total: 0,
      //全部评论
      quanbupi:"",
      //差评
      chapi:"",
      //中评
      zhongpi:"",
      //优评
      youpi:"",
      //商品id
      goodisl:""
    };
  },
  methods: {
    //点击小图片时将图片路径赋值给大图
    getIndex(imgUrl) {
      this.ImgUrl = imgUrl;
      this.imgsrc = this.ImgUrl;
    },
    // 获取元素到文档区域的坐标
    getPosition: function (element) {
      var dc = document,
        rec = element.getBoundingClientRect(),
        x = rec.left, // 获取元素相对浏览器视窗window的左、上坐标
        y = rec.top;
      // 与html或body元素的滚动距离相加就是元素相对于文档区域document的坐标位置
      x += dc.documentElement.scrollLeft || dc.body.scrollLeft;
      y += dc.documentElement.scrollTop || dc.body.scrollTop;
      return {
        left: x,
        top: y,
      };
    },
    handleMove(evt) {
      var larger = this.$refs.larger;
      var shadow = this.$refs.shadow;
      var big = this.$refs.big;
      var pos = this.getPosition(this.$refs.choose);
      var shadowRect = shadow.getBoundingClientRect();
      var bigRect = big.getBoundingClientRect();
      var contentRect = this.$refs.content.getBoundingClientRect();
      var maxX = contentRect.width - shadowRect.width;
      var maxY = contentRect.height - shadowRect.height;

      var X = evt.pageX - pos.left - shadowRect.width / 2;
      var Y = evt.pageY - pos.top - shadowRect.height / 2;

      if (X <= 0) {
        X = 0;
      }
      if (X >= maxX) {
        X = maxX;
      }
      if (Y <= 0) {
        Y = 0;
      }
      if (Y >= maxY) {
        Y = maxY;
      }
      // 防止遮罩层粘滞，跟随鼠标一起滑出大图位置
      var bigX = (X * bigRect.width) / contentRect.width;
      var bigY = (Y * bigRect.height) / contentRect.height;
      //  bigX / bigW = X / contentW,主图和遮罩层之间存在两倍关系，放大图和原图之间也有两倍关系
      shadow.style.left = X + "px";
      shadow.style.top = Y + "px";

      // console.log(X, Y, bigX, bigY);

      big.style.left = -bigX + "px";
      big.style.top = -bigY + "px";

      larger.style.display = "block";
      shadow.style.display = "block";
    },
    handleOut(evt) {
      var larger = this.$refs.larger;
      var shadow = this.$refs.shadow;
      larger.style.display = "none";
      shadow.style.top = "-1000px";
    },
    //根据商品名称查询商品属性和商品
    getparam() {
      this.$axios.get("/api/Food/Paramname?name=" + this.names).then((s) => {
        this.goodparam = s.data;
        var d = s.data[0].Good.GoodImagefu;
        this.ImgUrl = "http://81.68.132.153:7070/img/" + s.data[0].Good.GoodImage;
        this.imgsrc = "http://81.68.132.153:7070/img/" + s.data[0].Good.GoodImage;
        this.goodids=s.data[0].Good.Goodid;
        // this.num=s.data[0].Good.Goodnum;
        //把获取到的商品副图片切割
        let imgss = s.data[0].Good.GoodImagefu.split("/");
        for (let i = 0; i < this.imgUrl.length; i++) {
          console.log(1);
          this.imgUrl[i].url = "http://81.68.132.153:7070/img/" + imgss[i];
        }
        console.log(imgss);
        console.log(d);
         console.log("ddd");
        console.log(this.goodparam);
      });
      
    },
    //查询所有口味
    getkouweilist() {
      this.$axios
        .get("/api/Food/goodkoweisnames?name=" + this.names)
        .then((s) => {
          this.goodkoweis = s.data;
          this.radio1 = s.data[0].Goodkoweiname;
          console.log(this.goodkoweis);
          this.shopping = s.data;
          console.log("shopping");
          console.log(this.shopping);
        });
    },
    //
    handleChange(value) {
      console.log(value);
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
    //跳转到购物车
    goodshopp() {
      if (this.namess == "") {
        this.dialogVisible = true;
      } else {
        console.log();

        this.$axios
          .get("/api/Food/foodUsersname?name=" + this.namess)
          .then((sd) => {
            if (sd.data != "") {
              this.shoppingss.Userxixid = sd.data[0].Userxixid;
              this.$router.push({
                path: "/qianduan/shopgowuche",
                query: {
                  userids: this.shoppingss.Userxixid,
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
      if (this.namess == "") {
        this.dialogVisible = true;
      } else {
        this.$axios
          .get("/api/Food/foodUsersname?name=" + this.namess)
          .then((sd) => {
            if (sd.data != "") {
              this.shoppingss.Userxixid = sd.data[0].Userxixid;
              this.$router.push({
                path: "/qianduan/shopgowuche",
                query: {
                  userids: this.shoppingss.Userxixid,
                },
              });
            } else {
              this.$message.error("查询用户失败!");
            }
          });
      }
    },
    //跳转到个人中心
    goodusers() {
      if (this.namess == "") {
         this.$router.push("/Login");
      } else {
        this.$axios
          .get("/api/Food/foodUsersname?name=" + this.namess)
          .then((sd) => {
            if (sd.data != "") {
              this.shoppingss.Userxixid = sd.data[0].Userxixid;
              this.$router.push({
                path: "/qianduan/security",
                query: {
                  userids: this.shoppingss.Userxixid,
                },
              });
            } else {
              this.$message.error("查询用户失败!");
            }
          });
      }
    },
    //判断用户是否登录，登录就可以购买，没登录就躺出登录
    gouma() {
      if (this.namess == "") {
         this.$router.push("/Login");
      } else {
        
         this.$router.push({
                      path: "/qianduan/pay",
                      query: {
                        shoppid: this.usid,
                        koweis:this.radio1,
                        nums:this.num
                      },
                    });
        console.log();
      }
    },
    //加入购物车
    gouwu() {
      if (this.namess == "") {
        this.$router.push("/Login");
        // this.dialogVisible = true;
      } else {
        console.log("shopping1");
        console.log(this.shopping);
        this.shoppingss.Goodid = this.shopping[0].Goodid;
        this.shoppingss.shoppingmoney = this.shopping[0].Good.GoodPrcieper;
        this.shoppingss.shoppingnum = this.num;
        // this.shoppingss.Goodkoweiid = this.goodkoweis[0].Goodkoweiid;
        this.$axios
          .get("/api/Food/foodUsersname?name=" + this.namess)
          .then((sd) => {
            if (sd.data != "") {
              this.shoppingss.Userxixid = sd.data[0].Userxixid;
              //  alert(this.shoppingss.Userxixid);
              this.$axios.get('/api/Food/goodkoweiz?name='+this.radio1).then(l=>{
          if (l.data!="") {
            this.shoppingss.Goodkoweiid = l.data[0].Goodkoweiid;
             console.log("this.shoppingss.Goodkoweiid");
            console.log(this.shoppingss.Goodkoweiid);
            console.log(l.data);
              this.$axios
                .post("/api/Food/shoppingADD", this.shoppingss)
                .then((s) => {
                  if (s.data == "添加成功") {
                    this.$message.success("添加购物车成功");
                    this.$router.push({
                      path: "/qianduan/shopgowuche",
                      query: {
                        ids: this.shopping[0].Goodid,
                        kowdi: this.radio1,
                        userid: this.shoppingss.Userxixid,
                      },
                    });
                  } else {
                    this.$message.error("添加购物车失败!");
                  }
                });
            } else {
              this.$message.error("查询用户失败!");
            }
          });}
        })
      }
    },
    //用户登录
    dengliu() {
      this.$axios
        .post(
          "/api/Food/foodUser",
          this.$qstring.stringify({
            Userxixname: this.ruleForm.name,
            Userxixphone: this.ruleForm.name,
            Userxixemail: this.ruleForm.name,
            Usermima: this.ruleForm.password,
          })
        )
        .then((s) => {
          console.log(s);
          if (s.data != "") {
            this.$message({
              message: "用户登录成功",
              type: "success",
            });
            this.dialogVisible = false;
            this.namess = s.data[0].Userxixname;
            window.sessionStorage.setItem('token',this.namess)
          } else {
            this.$message({
              message: "登录失败",
              type: "warning",
            });
          }
        });
    },
    //查询所有商品
    getgoodlist() {
      this.$axios.get("/api/Food/goods").then((s) => {
        this.goodlists = s.data;
      });
    },
    //跳转到首页
    s(){
			this.$router.push("/");
		},
    //根据用户的用户名查询用户
    getuserlists(){
      this.$axios.get('/api/Food/foodUsersname?name='+this.namess).then(s=>{
       this.usid=s.data[0].Userxixid;
      }   
      )
    },
    //点击加入收藏添加收藏的数据
    getfootpring(){
      // this.footprint.Goodid=
      // this.$axios.post('/api/Food/footprintADD',this.footprint).then(s=>{

      // })
    },
    //查询差评
    getchapi(){ 
     this.$axios.get('/api/Food/scoresselectchapi?id='+this.goodisl).then(s=>{
       this.chapi=s.data.length;
       console.log("s.data");
       console.log(s.data);
     });
    },
    //查询中评
    getzhongpi(){ 
     this.$axios.get('/api/Food/scoresselectzhongpi?id='+this.goodisl).then(s=>{
       this.zhongpi=s.data.length;
       console.log("s.data");
       console.log(s.data);
     });
    },
    //查询优评
    getyoupi(){ 
     this.$axios.get('/api/Food/scoresselectyoupi?id='+this.goodisl).then(s=>{
       this.youpi=s.data.length;
       console.log("s.data");
       console.log(s.data);
     });
    },
    //查询评价
     getpingjia(){
         this.$axios.get("/api/Food/scoresselectfy", {
          params: {
            pagenum: this.pagenum,
            pagesize: this.pagesize,
            query: this.names,
          },
        }).then(s=>{
              if (s.data!="") {
                 this.pingjialist=s.data.data;
                  this.total=s.data.total;
                 console.log(this.pingjialist);
                 let imgss=[];
                 this.quanbupi=s.data.data.length;
                 for (let i = 0; i < s.data.total; i++) {
                    // this.url=s.data[i].Scoreimage;
             imgss.push(s.data.data[i].Scoreimage.split("/"));
              this.pingjialist[i].imaged=imgss[i];
              // console.log("imagss");
              // console.log(imgss);
              //  this.url=imgss;
         
               console.log(this.url);
                 }  
                 this.getgoodan();
                this.getchapi();
                this.getzhongpi();
                this.getyoupi();
             } 
             console.log(this.pingjialist)
         });
     },
       //监听pagesize改变的事件
    handleSizeChange(newSieze) {
      console.log(newSieze + "pagesize=");
      this.pagesize = newSieze;
     this.getpingjia();
    },
    //监听页码值改变的事件
    handleCurrentChange(newPage) {
      console.log(newPage + "pagenum");
      this.pagenum = newPage;
      this.getpingjia();
    },
    getgoodan(){
       this.$axios.get('/api/Food/goodsnameS?name='+this.names).then(s=>{
         if (s.data!="") {
          //  alert(1);
           this.goodisl=s.data[0].Goodid;
             
         }
       });
    },
     //跳到搜索页面
    shuosuo(){
       this.$router.push({
          path: '/qianduan/search',
          query: {
            namess: this.namess
          }
        });
            //  this.$router.push('/qianduan/search');
    },
  },
  created() {
    this.names = this.$route.query.ids;
    this.getkouweilist();
    console.log(this.names);
    this.getparam();
            // this.getzhongpi();
            //  this.getyoupi();
             this.getgoodlist();
    this.getpingjia();
    
    const tokenstr = window.sessionStorage.getItem("token");
    
    if (tokenstr != null) {
      this.namess = tokenstr;
      this.getuserlists();
      console.log(this.namess);
    } else {
      // this.namess = this.$route.query.namess;
      // this.dengliu();
      // alert(this.namess);
    }
  },
};
</script>
<style scoped>
@import "../../assets/AmazeUI-2.4.2/assets/css/admin.css";
@import "../../assets/AmazeUI-2.4.2/assets/css/amazeui.css";
@import "../../assets/css/optstyle.css";
@import "../../assets/basic/css/demo.css";
@import "../../assets/css/style.css";
@media only screen and (min-width: 1260px) {
  ul.am-tabs-nav.am-nav.am-nav-tabs {
    left: auto;
    right: auto;
    width: 960px;
    background-color: #fff;
  }
}
html {
  background-color: #fff !important;
}
.el-input-number {
  position: relative;
  display: inline-block;
  width: 151px !important;
  line-height: 38px;
}
@media only screen and (min-width: 1025px) {
  .theme-options {
    overflow: visible;
    padding: 9px 0px;
  }
}
@media only screen and (min-width: 1025px) {
  .listMain {
    /* margin-right: 146px; */
  }
}
@media only screen and (min-width: 1025px) {
  .tb-detail-price {
    background: #f7f7f7;
    overflow: hidden;
    height: 82px;
    padding-top: 12px;
  }
}
form label {
  width: 63px !important;
}
.choose {
  width: 400px;
  height: 600px;
  float: left;
  margin: 10px 0 0 10px;
}

.content {
  width: 400px;
  height: 400px;
  position: relative;
}

.content img {
  width: 400px;
  height: 400px;
}
#listshow {
  width: 79px;
  height: 100px;
  margin-top: 20px;
}

#listshow li {
  width: 72px;
  height: 72px;
  float: left;
  border: 1px solid #666;
}

#listshow li img {
  width: 70px;
  height: 70px;
}

#listshow .selected {
  border-color: brown;
}

.larger {
  width: 400px;
  height: 400px;
  position: absolute;
  top: 251px;
  left: 563px;
  float: left;
  z-index: 100;
  overflow: hidden;
  display: none;
}

.larger img {
  width: 800px;
  height: 800px;
  position: absolute;
  left: 0;
  top: 0;
}

.shadow {
  width: 200px;
  height: 200px;
  background-color: rgba(145, 200, 200, 0.4);
  position: absolute;
  left: 0;
  top: 0;
  z-index: 10;
  display: none;
}
.el-radio__label  {
  text-overflow: ellipsis !important;
  white-space: normal !important;
  line-height: 18px !important;
  vertical-align: middle !important;
}
.el-radio-button__inner, .el-radio-group {
   display: flex !important;
    line-height: 1;
    vertical-align: middle;
}
</style>