import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import register from '../views/register.vue'
import Admin from '../views/Admin.vue'
import admins from '../components/admin/Users/Users.vue'
import shou from '../components/admin/shou.vue'
import goodsliebiao from '../components/admin/goods/goodsliebiao.vue'
import Add from '../components/admin/goods/Add.vue'
import kowei from '../components/admin/goods/kowei.vue'
import Param from '../components/admin/goods/Param.vue'
import ParamADD from '../components/admin/goods/ParamADD.vue'
import goodtype from '../components/admin/goods/goodtype.vue'
import goodtypeone from '../components/admin/goods/goodtypeone.vue'
import order from '../components/admin/order/orders.vue'
import ordertuihuo from '../components/admin/order/ordertuihuo.vue'
import orderding from '../components/admin/order/orderding.vue'
import tuihuoding from '../components/admin/order/tuihuoding.vue'
import index from '../components/qianduan/index.vue'
import s from '../views/s.vue'
import shopping from '../components/qianduan/shopping.vue'
import shopgowuche from '../components/qianduan/shopgowuche.vue'
import g from '../views/g.vue'
import Information from '../components/qianduan/Information.vue'
import tou from '../components/qianduan/tou.vue'
import security from '../components/qianduan/security.vue'
import usersafety from '../components/qianduan/usersafety.vue'
import userdizhi from '../components/qianduan/userdizhi.vue'
import pay from '../components/qianduan/pay.vue'
import sao from '../views/sao.vue'
import shouchang from '../components/qianduan/shouchang.vue'
import userorder from '../components/qianduan/userorder.vue'
import ordersuccess from '../components/qianduan/ordersuccess.vue'
import orderrefund from '../components/qianduan/orderrefund.vue'
import editor from  '../components/editor.vue'
import tuihuoguanli from '../components/qianduan/tuihuoguanli.vue'
import orderxiangqi from '../components/qianduan/orderxiangqi.vue'
import search from '../components/qianduan/search.vue'
import pingjia from '../components/qianduan/pingjia.vue'
import pingjiaguanli from '../components/qianduan/pingjiaguanli.vue'

Vue.prototype.$router = router
Vue.use(VueRouter)

const routes = [{
    path: '/Home',
    name: 'Home',
    component: Home
  },
  {
    path: '/Login',
    name: "Login",
    component: Login
  },
  {
    path: '/register',
    name: "register",
    component: register
  },
  {
    path: '/Admin',
    component: Admin,
    redirect: '/admins',
    children: [
      {
        path: '/shou',
        component: shou
      },
      {
      path: '/admins',
      component: admins
    },
    {
      path: '/goodsliebiao',
      component: goodsliebiao
    }
    ,
    {
      path: '/goods/Add',
      component: Add
    }
    ,
    {
      path: '/goods/kowei',
      component: kowei
    },
    {
      path: '/goods/Param',
      component: Param
    },
    {
      path: '/goods/ParamADD',
      component: ParamADD
    },
    {
      path: '/goods/goodtype',
      component: goodtype
    },
    {
      path: '/goods/goodtypeone',
      component: goodtypeone
    },
    {
      path: '/order/order',
      component: order
    },
    {
      path: '/order/ordertuihuo',
      component: ordertuihuo
    },
    {
      path: '/order/tuihuoding',
      component: tuihuoding
    }
    ,
    {
      path: '/order/orderding',
      component: orderding
    }
]
  },
  {
    path: '/admins',
    name: "admins",
    component: admins
  },
  {
    path: '/goodsliebiao',
    name: "goodsliebiao",
    component: goodsliebiao
  }
  ,
  {
    path: '/goods/Add',
    name: "Add",
    component: Add
  }
  ,
  {
    path: '/goods/kowei',
    name: "kowei",
    component: kowei
  },
  {
    path: '/goods/Param',
    name: "Param",
    component: Param
  }
  ,
  {
    path: '/goods/ParamADD',
    name: "ParamADD",
    component: ParamADD
  },
  {
    path: '/goods/goodtype',
    name: "goodtype",
    component: goodtype
  },
  {
    path: '/goods/goodtypeone',
    name: "goodtypeone",
    component: goodtypeone
  }
  ,
  {
    path: '/order/order',
    name: "order",
    component: order
  }
  ,
  {
    path: '/order/ordertuihuo',
    name: "ordertuihuo",
    component: ordertuihuo
  },
  {
    path: '/order/tuihuoding',
    name: "tuihuoding",
    component: tuihuoding
  }
  , 
  {
    path: '/order/orderding',
    name:"orderding",
    component: orderding
  },
  {
    path: '/',
    name: "index",
    component: index
  }
  ,
  {
    path: '/s',
    name: "s",
    component: s
  },
  {
    path: '/g',
    name: "g",
    component: g
  },
  {
    path: '/qianduan/shopping',
    name: "shopping",
    component: shopping
  },
  {
    path: '/qianduan/shopgowuche',
    name: "shopgowuche",
    component: shopgowuche
  }
  ,
  {
    path: '/qianduan/Information',
    component:Information,
    redirect: '/qianduan/security',
    children: [
      {
        path: '/qianduan/security',
        component: security
      },
      {
        path: '/qianduan/usersafety',
        component: usersafety
      },
      {
        path: '/qianduan/userdizhi',
        component: userdizhi
      },
      {
        path: '/qianduan/shouchang',
        component: shouchang
      },
      {
        path:"/qianduan/userorder",
        component:userorder
      },
      {
        path:"/qianduan/orderrefund",
        component:orderrefund
      },
      {
        path:"/qianduan/tuihuoguanli",
        component:tuihuoguanli
      },
      {
        path:"/qianduan/orderxiangqi",
        component:orderxiangqi
      },
      {
        path:"/qianduan/pingjia",
        component:pingjia
      },
      {
        path:"/qianduan/pingjiaguanli",
        component:pingjiaguanli
      }
    ]
  },
  {
    path: '/qianduan/Information',
    name: "Information",
    component: Information,
  }
  ,
  {
    path: '/qianduan/tou',
    name: "tou",
    component: tou
  }
  ,
  {
    path: '/qianduan/security',
    name: "security",
    component: security
  },
  {
    path: '/qianduan/usersafety',
    name: "usersafety",
    component: usersafety
  },
  {
    path: '/qianduan/userdizhi',
    name: "userdizhi",
    component: userdizhi
  },
  {
    path: '/qianduan/pay',
    name: "pay",
    component: pay
  },
  {
    path: '/sao',
    name: "sao",
    component: sao
  },
  {
    path:"/qianduan/shouchang",
    name:"shouchang",
    component:shouchang
  },
  {
    path:"/qianduan/userorder",
    name:"userorder",
    component:userorder
  }
  ,
  {
    path:"/qianduan/ordersuccess",
    name:"ordersuccess",
    component:ordersuccess
  } ,
  {
    path:"/qianduan/orderrefund",
    name:"orderrefund",
    component:orderrefund
  },
  {
    path:"/editor",
    name:"editor",
    component:editor
  },
  {
    path:"/qianduan/tuihuoguanli",
    name:"tuihuoguanli",
    component:tuihuoguanli
  },
  {
    path:"/qianduan/orderxiangqi",
    name:"orderxiangqi",
    component:orderxiangqi
  },
  {
    path:"/qianduan/search",
    name:"search",
    component:search
  },
  {
    path:"/qianduan/pingjia",
    name:"pingjia",
    component:pingjia
  }
  ,
  {
    path:"/qianduan/pingjiaguanli",
    name:"pingjiaguanli",
    component:pingjiaguanli
  }
]
// history hash
const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router