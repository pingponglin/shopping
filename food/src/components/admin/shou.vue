<template>
  <div>
    <!-- 卡片区域 -->
    <el-card>
      <div class="d">
        <div
          style="background-color: #2dce89; position: relative; left: 10px"
          class="z-div"
        >
          <div class="zs">
            <span class="z-span">订单总数</span><br /><span
              style="position: relative; bottom: 40px; font-size: 20px"
              >{{dingdansum}}</span
            >
          </div>
          <div class="zd"><i class="el-icon-document zi"></i></div>
        </div>
        <div
          style="background-color: #5e72e4; position: relative; left: 60px"
          class="z-div"
        >
          <div class="zs">
            <span class="z-span">销售总额</span><br /><span class="z-span1"
              >￥{{moneys}}</span
            >
          </div>
          <div class="zd"><i class="el-icon-coin zi"></i></div>
        </div>
        <div
          style="background-color: #f5365c; position: relative; left: 110px"
          class="z-div"
        >
          <div class="zs">
            <span class="z-span">新增用户</span><br /><span class="z-span1"
              >{{userss}}</span
            >
          </div>
          <div class="zd"><i class="el-icon-user zi"></i></div>
        </div>
        <div
          style="background-color: #11cdef; position: relative; left: 160px"
          class="z-div"
        >
          <div class="zs">
            <span class="z-span">商品总数</span><br /><span class="z-span1"
              >{{goodd}}</span
            >
          </div>
          <div class="zd"><i class="el-icon-document zi"></i></div>
        </div>
      </div>
      <div>
        <ve-line
          :data="chartData"
          height="450px"
          :settings="charSettings"
          style="margin-top: 30px"
        ></ve-line>
        <!-- <div style="display: inline; float: left; width: 50%; height: 800px; border: #3b4151 solid 1px">
       
        <ve-histogram :data="chartData_1"  height="400px"></ve-histogram>
      </div>
      <div style="display: inline;float: right; width: 50%; border: #3b4151 solid 1px">
        <ve-pie :data="chartData" height="400px"></ve-pie>
        <ve-radar :data="chartData" height="400px"></ve-radar>
      </div> -->
      </div>
    </el-card>
  </div>
</template>

<script>
export default {
  data() {
    return {
      Ordertime: "Ordertime",
      charSettings: {
        labelMap: {
          Ordertime: "日期",
          Ordernum: "订单数量",
          Ordersum: "订单金额",
        },
      },
      chartData: {
        columns: ["Ordertime", "Ordernum", "Ordersum"],
        rows: [],
      },
      chartData_1: {
        columns: ["日期", "访问用户", "下单用户", "下单率"],
        rows: [
          { 日期: "1/1", 访问用户: 1393, 下单用户: 1093, 下单率: 0.32 },
          { 日期: "1/2", 访问用户: 3530, 下单用户: 3230, 下单率: 0.26 },
          { 日期: "1/3", 访问用户: 2923, 下单用户: 2623, 下单率: 0.76 },
          { 日期: "1/4", 访问用户: 1723, 下单用户: 1423, 下单率: 0.49 },
          { 日期: "1/5", 访问用户: 3792, 下单用户: 3492, 下单率: 0.323 },
          { 日期: "1/6", 访问用户: 4593, 下单用户: 4293, 下单率: 0.78 },
        ],
      },
      chartData_2: {
        columns: ["日期", "访问用户", "下单用户", "下单率"],
        rows: [
          { 日期: "1/1", 访问用户: 1393, 下单用户: 1093, 下单率: 0.32 },
          { 日期: "1/2", 访问用户: 3530, 下单用户: 3230, 下单率: 0.26 },
          { 日期: "1/3", 访问用户: 2923, 下单用户: 2623, 下单率: 0.76 },
          { 日期: "1/4", 访问用户: 1723, 下单用户: 1423, 下单率: 0.49 },
          { 日期: "1/5", 访问用户: 3792, 下单用户: 3492, 下单率: 0.323 },
          { 日期: "1/6", 访问用户: 4593, 下单用户: 4293, 下单率: 0.78 },
        ],
      },
      //订单的总数
       dingdansum:0,
      //订单的金额
      moneys:0,
      //新增用户的数量
      userss:0,
      //所有商品的数量
      goodd:0
    };
  },
  methods: {
    getlist() {
      this.$axios.get("/api/Food/order").then((s) => {
        this.chartData.rows=s.data;
        for(let i=0;i<this.chartData.rows.length;i++){
          const date=new Date(this.chartData.rows[i].Ordertime)
          this.chartData.rows[i].Ordertime=date.getFullYear() + '年' + date.getMonth() + '月' + date.getDate() +'日 '
        }
      });
    },
    //查询订单的总和
    dingdan(){
      this.$axios.get("/api/Food/ordersum").then((s) => {
        if (s.data!=0) {
          this.dingdansum=s.data;
        }
        else{
          this.$message.error("订单总数查询失败!");
        }
      });
    },
    //查询订单的总金额
    dingdanmoney(){
      this.$axios.get("/api/Food/ordermoney").then((s) => {
        if (s.data!=0) {
          this.moneys=s.data;
        }
        else{
          this.$message.error("订单金额查询失败!");
        }
      });
    },
     //查询所有用户
    userd(){
      this.$axios.get("/api/Food/foodUsers").then((s) => {
        if (s.data!="") {
          this.userss=s.data.length;
        }
        else{
          this.$message.error("新增用户查询失败!");
        }
      });
    },
    //查询所有商品
    goodlist(){
      this.$axios.get("/api/Food/goods").then((s) => {
        if (s.data!="") {
          this.goodd=s.data.length;
          console.log(s.data);
        }
        else{
          this.$message.error("新增用户查询失败!");
        }
      });
    }
  },
  created() {
    this.getlist();
    this.dingdan();
    this.dingdanmoney();
    this.userd();
    this.goodlist();
  },
  // computed:{
  //   Responsedate(){
  //     const date=new Date(this.chartData.rows)
  //     return date.getFullYear() + '年' + date.getMonth() + '月' + date.getDate() +
  //                     '日 ';
  //   }
  // }
};
</script>

<style scoped>
.d {
  display: flex;
  color: white;
}
.el-breadcrumb {
  margin-bottom: 15px;
  font-size: 12px;
}
.el-card {
  box-shadow: 0 1px 1px rgba(0, 0, 0, 0.15) !important;
  height: 100%;
}
.z-div {
  width: 270px;
  height: 100px;
  border-radius: 5px 5px;
  margin-top: 10px;
  box-shadow: 0 2px 10px rgb(0 0 0 / 8%);
}
.zd {
  width: 60px;
  height: 60px;
  border: 1px solid #dee2e6;
  position: relative;
  bottom: 100px;
  left: 160px;
  border-radius: 40px 40px;
}
.zi {
  font-size: 30px;
  position: relative;
  left: 14px;
  top: 14px;
}
.zs {
  position: relative;
  left: 24px;
}
.z-span {
  line-height: 90px;
}
.z-span1 {
  position: relative;
  bottom: 40px;
  font-size: 20px;
}
</style>