<template>
  <div>
    <el-breadcrumb separator-class="el-icon-arrow-right">
      <el-breadcrumb-item :to="{ path: '/shou' }">首页</el-breadcrumb-item>
      <el-breadcrumb-item>订单管理</el-breadcrumb-item>
      <el-breadcrumb-item>退货列表</el-breadcrumb-item>
    </el-breadcrumb>
    <!-- 卡片区域 -->
    <el-card>
      <!-- 搜索与添加区域 -->
      <el-row :gutter="32">
        <el-col :span="15">
          <div class="block">
            <el-input
              placeholder="请输入订单编号"
              v-model="query"
              style="width: 180px;"
            ></el-input>
            <el-date-picker
              style="width: 180px;margin-left:20px"
              v-model="kaishi"
              type="date"
              placeholder="开始日"
            >
            </el-date-picker>
            <el-date-picker
              style="width: 180px;margin-left:20px"
              v-model="jieshu"
              type="date"
              placeholder="截止日"
            >
            </el-date-picker>
            <el-select
              v-model="dingdan"
              style="width: 150px;margin-left:20px"
              placeholder="请选择订单状态"
            >
              <el-option
                v-for="item in options"
                :key="item.value"
                :label="item.label"
                :value="item.value"
              >
              </el-option>
            </el-select>
          </div>
        </el-col>
        <el-col :span="6">
          <el-button type="primary" icon="el-icon-search" @click="getselect"
            >搜索</el-button
          >
          <el-button type="primary" @click="getselectss" >刷新</el-button>
           <el-button @click="exportExcel"  size="medium" type="success">导出excel</el-button>
        </el-col>
      </el-row>
      <!-- 用户列表区域 -->
      <el-table :data="tableData" id="ta" border stripe style="width: 100%">
        <el-table-column prop="Ordertuihuoid" label="编号" width="100">
        </el-table-column>
         <el-table-column prop="Order.Ordername" label="订单编号" width="220">
        </el-table-column>
        <el-table-column prop="Ordertuihuomoneys" label="退款金额" width="150">
        </el-table-column>
        <el-table-column prop="Ordertuihuostatus" label="申请状态" width="150">
        </el-table-column>
        <el-table-column prop="Ordertuihuodate" label="处理时间" width="170">
           <template v-slot="tableData">
            {{ tableData.row.Ordertuihuodate | dateFormat }}
          </template>
        </el-table-column>
      <el-table-column prop="Good.GoodName" label="商品名称" width="320">
        </el-table-column>
        <el-table-column label="操作" width="143">
          <!-- 发货 -->
          <template slot-scope="tableData">
             <el-button
              type="primary"
              size="mini"
              @click="tuiUserd(tableData.row.Ordertuihuoid)"
            >查看退货详情</el-button>
          </template>
        </el-table-column>
      </el-table>
      <!-- 分页区域 -->
      <el-pagination
        @size-change="handleSizeChange"
        @current-change="handleCurrentChange"
        :current-page="pagenum"
        :page-sizes="[1, 2, 5, 10]"
        :page-size="pagesize"
        layout="total, sizes, prev, pager, next, jumper"
        :total="total"
      >
      </el-pagination>
    </el-card>
    <!-- 修改用户的对话框 -->
    <!-- @close关闭 -->
    <!-- 发货对话框 -->
    <!-- <el-dialog
      title="发货列表"
      :visible.sync="faVisible"
      width="50%"
    >
      <el-form
        :model="faform"
        label-width="70px"
        class="demo-ruleForm"
      >
        <el-form-item
          label="订单编号"
          style="position: relative; top: 0px; left: 0px"
          prop="GoodName"
        >
          <el-input v-model="faform.Ordername"></el-input>
        </el-form-item>
        <el-form-item
          label="收货人"
          style="position: relative; top: 0px; left: 0px"
          prop="GoodPrice"
        >
          <el-input v-model="faform.Userxix.Userxixname"></el-input>
        </el-form-item>
        <el-form-item
          label="手机号码"
          style="position: relative; top: 0px; left: 0px"
          prop="GoodPrcieper"
        >
          <el-input v-model="faform.Userxix.Userxixphone"></el-input>
        </el-form-item>
        <el-form-item
          label="收货地址"
          style="position: relative; top: 0px; left: 0px"
          prop="Goodnum"
        >
          <el-input v-model="faform.Userxix.Useraddress"></el-input>
        </el-form-item>
        <el-form-item
          label="配送方式"
          style="position: relative; top: 0px; left: 0px"
          prop="Goodnum"
        >
          <el-input v-model="faform.Orderwuliu"></el-input>
        </el-form-item>
      </el-form>
      <span slot="footer" class="dialog-footer">
        <el-button @click="faVisible = false">取 消</el-button>
        <el-button type="primary" @click="faInfo(faform.Orderid)">确认发货</el-button>
      </span>
    </el-dialog> -->
  </div>
</template>
<script>
import FileSaver from 'file-saver'
import XLSX from 'xlsx'
export default {
  data() {
    return {
      //获取用户的数据
      tableData: [],
      //当前的页数
      pagenum: 1,
      //当前每页的数据
      pagesize: 5,
      //获取总共的页数
      total: 0,
      //获取搜索的内容
      query: "",
      //控制发货对话框的显示与隐藏
      faVisible:false
      ,
      faform:{
          Userxix:{Userxixid:"",Userxixname:"",Userxixphone:"",Useraddress:""}
      }
      ,
      //开始日期
      kaishi: "",
      //结受日期
      jieshu: "",
      dingdan:"",
      options: [
        {
          value: "待处理",
          label: "待处理",
        },
        {
          value: "已拒绝",
          label: "已拒绝",
        },
        {
          value: "已完成",
          label: "已完成",
        }
      ],
    };
  },
  methods: {
    async getUserList() {
      this.$axios
        .get("/api/Food/ordertuihuofy", {
          params: {
            pagenum: this.pagenum,
            pagesize: this.pagesize,
          },
        })
        .then((d) => {
          this.tableData = d.data.data;
          this.total = d.data.total;
          console.log(d.data);
        })
        .catch((l) => {
          console.log(l);
        });
    },
    //查询
    async getselect() {
      this.$axios
        .get("/api/Food/ordertuihuoselect", {
          params: {
            pagenum: this.pagenum,
            pagesize: this.pagesize,
            query: this.query,
            kaishi:this.kaishi,
            jieshu:this.jieshu,
            dingdan:this.dingdan,
          },
        })
        .then((d) => {
          this.tableData = d.data.data;
          this.total = d.data.total;
          // if (this.query == "") {
          //   this.getUserList();
          // }
          // this.getUserList();
          console.log(d.data);
        })
        .catch((l) => {
          console.log(l);
        });
    },
    //监听pagesize改变的事件
    handleSizeChange(newSieze) {
      console.log(newSieze + "pagesize=");
      this.pagesize = newSieze;
      if (this.query == "") {
        this.getUserList();
      } else {
        // alert("pagesize"+this.pagesize);
        this.getselect();
      }
    },
    //监听页码值改变的事件
    handleCurrentChange(newPage) {
      console.log(newPage + "pagenum");
      this.pagenum = newPage;

      if (this.query == "") {
        this.getUserList();
      } else {
        // alert("pagesize"+this.pagesize);
        this.getselect();
      }
    },
    getselectss() {
      this.$axios
        .get("/api/Food/ordertuihuo")
        .then((s) => {
          // this.total = s.data.length;
          this.dingdan="";
          this.kaishi="";
          this.jieshu="";
          this.query="";
          this.getUserList();
        })
        .catch({});
    },
    tuiUserd(id){
      //  this.$router.push({path:'/order/tuihuoding',querys: {list: id}});
       this.$router.push({
          path: '/order/tuihuoding',
          query: {
            ids: id
          }
        })
    },
    exportExcel () {
    /* generate workbook object from table */
     let xlsxParam = { raw: true } // 导出的内容只做解析，不进行格式转换
     let wb = XLSX.utils.table_to_book(document.querySelector('#ta'), xlsxParam);
     /* get binary string as output */
     let wbout = XLSX.write(wb, { bookType: 'xlsx', bookSST: true, type: 'array' });
     try {
         FileSaver.saveAs(new Blob([wbout], { type: 'application/octet-stream' }), '用户提交返利表.xlsx');
     } catch (e)
     {
         if (typeof console !== 'undefined')
             console.log(e, wbout)
     }
     return wbout
 },
  },

  created() {
    // this.getselectss();
  
    this.getUserList();
    // this.faUserd();
    // this.getselect();
   
  },
};
</script>

<style scoped>
.el-breadcrumb {
  margin-bottom: 15px;
  font-size: 12px;
}
.el-card {
  box-shadow: 0 1px 1px rgba(0, 0, 0, 0.15) !important;
  height: 100%;
}
.el-table {
  margin-top: 15px !important;
}
</style>
