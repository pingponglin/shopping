<template>
  <div>
    <el-breadcrumb separator-class="el-icon-arrow-right">
      <el-breadcrumb-item :to="{ path: '/shou' }">首页</el-breadcrumb-item>
      <el-breadcrumb-item>订单管理</el-breadcrumb-item>
      <el-breadcrumb-item>订单列表</el-breadcrumb-item>
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
              style="width: 180px"
            ></el-input>
            <el-date-picker
              style="width: 180px; margin-left: 20px"
              v-model="kaishi"
              type="date"
              placeholder="开始日"
            >
            </el-date-picker>
            <el-date-picker
              style="width: 180px; margin-left: 20px"
              v-model="jieshu"
              type="date"
              placeholder="截止日"
            >
            </el-date-picker>
            <el-select
              v-model="dingdan"
              style="width: 150px; margin-left: 20px"
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
          <el-button type="primary" @click="getselectss">刷新</el-button>
           <el-button @click="exportExcel"  size="medium" type="success">导出excel</el-button>
        </el-col>
      </el-row>

      <!-- 用户列表区域 -->
      <el-table :data="tableData" id="ta" border stripe style="width: 100%">
        <el-table-column prop="Orderid" label="订单id" width="100">
        </el-table-column>
        <el-table-column prop="Ordername" label="订单编号" width="190">
        </el-table-column>
        <el-table-column prop="Good.GoodName" label="商品名称" width="150">
        </el-table-column>
        <el-table-column
          prop="Goodtypetwo.Goodtypetwoname"
          label="食品分类名称"
          width="150"
        >
        </el-table-column>
        <el-table-column prop="Ordernum" label="订单数量" width="150">
        </el-table-column>
        <el-table-column prop="Ordersum" label="订单总金额" width="150">
        </el-table-column>
        <el-table-column prop="Orderstatus" label="订单状态" width="150">
        </el-table-column>
        <el-table-column prop="Address.Addressname" label="收货人" width="150">
        </el-table-column>
        <el-table-column prop="Ordertime" label="下单时间" width="170">
          <template v-slot="tableData">
            {{ tableData.row.Ordertime | dateFormat }}
          </template>
        </el-table-column>
        <el-table-column prop="Orderwuliu" label="物流方式" width="150">
        </el-table-column>
        <el-table-column fixed="right" label="操作" width="300">
          <!-- 发货 -->
          <template slot-scope="tableData">
             <el-button
                size="mini"
                 @click="orderding(tableData.row.Orderid)"
              >查看订单</el-button>
            <el-button
              v-show="isshows(tableData.row)"
              type="success"
              size="mini"
              @click="faUserd(tableData.row.Orderid)"
              >发货</el-button
            >
              <el-button
                type="primary"
                size="mini"
                 @click="faUserdzhu(tableData.row.Orderid)"
              >订单跟踪</el-button>

            <!-- 删除用户 -->
            <el-tooltip
              effect="dark"
              content="删除订单"
              placement="top"
              :enterable="false"
            >
              <el-button
                v-show="isshow(tableData.row)"
                type="danger"
                icon="el-icon-delete"
                size="mini"
                @click="deletes(tableData.row.Orderid)"
              ></el-button
            ></el-tooltip>
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
    <el-dialog title="发货列表" :visible.sync="faVisible" width="50%">
      <el-form :model="faform" label-width="70px" class="demo-ruleForm">
        <el-form-item
          label="订单编号"
          style="position: relative; top: 0px; left: 0px"
          prop="Ordername"
        >
          <el-input v-model="faform.Ordername" disabled></el-input>
        </el-form-item>
        <el-form-item
          label="收货人"
          style="position: relative; top: 0px; left: 0px"
          prop="Userxixname"
        >
          <el-input v-model="faform.Address.Addressname" disabled></el-input>
        </el-form-item>
        <el-form-item
          label="手机号码"
          style="position: relative; top: 0px; left: 0px"
          prop="Userxixphone"
        >
          <el-input v-model="faform.Address.Addressphone" disabled></el-input>
        </el-form-item>
        <el-form-item
          label="收货地址"
          style="position: relative; top: 0px; left: 0px"
          prop="Useraddress"
        >
          <el-input v-model="faform.Address.Addresssuozaidiqu" disabled></el-input>
        </el-form-item>
        <el-form-item
          label="配送方式"
          style="position: relative; top: 0px; left: 0px"
          prop="dingdan"
        >
          <el-select
            v-model="faform.Orderwuliu"
            style="width: 150px; margin-left: 20px"
            placeholder="请选择物流方式"
          >
            <el-option
              v-for="item in optionss"
              :key="item.value"
              :label="item.label"
              :value="item.value"
            >
            </el-option>
          </el-select>
        </el-form-item>
      </el-form>
      <span slot="footer" class="dialog-footer">
        <el-button @click="faVisible = false">取 消</el-button>
        <el-button type="primary" @click="faInfo">确认发货</el-button>
      </span>
    </el-dialog>
    <!-- 订单跟踪对话框 -->
    <el-dialog title="订单跟踪" :visible.sync="dingdanVisible" width="50%">
         <div style="height: 300px;">
  <el-steps direction="vertical" :active="ding" finish-status="success">
    <el-step title="订单已提交,待付款"></el-step>
    <el-step title="订单付款成功"></el-step>
    <el-step title="到达目的地,快递很快进行派送"></el-step>
    <el-step title="订单已签收,期待再次为您服务"></el-step>
  </el-steps>
</div>
      <span slot="footer" class="dialog-footer">
        <el-button @click="dingdanVisible = false">取 消</el-button>
        <el-button type="primary" @click="dingdanVisible = false">确认</el-button>
      </span>
    </el-dialog>
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
      //控制订单追踪对话框的显示与隐藏
      dingdanVisible:false,
      //控制发货对话框的显示与隐藏
      faVisible: false,
      faform: {
        Address: {
          Addressid: "",
          Addressname: "",
          Addresssuozaidiqu: "",
          Addressxiangxidiqu: "",
          Addressyoubian: "",
           Addressphone: "",
        },
      },
      //开始日期
      kaishi: "",
      //结受日期
      jieshu: "",
      //订单状态
      dingdan: "",
      options: [
        {
          value: "待付款",
          label: "待付款",
        },
        {
          value: "待发货",
          label: "待发货",
        },
        {
          value: "待收货",
          label: "待收货",
        },
        {
          value: "待评价",
          label: "待评价",
        },
        {
          value: "已完成",
          label: "已完成",
        },
      ],
      optionss: [
        {
          value: "顺丰快递",
          label: "顺丰快递",
        },
        {
          value: "圆通快递",
          label: "圆通快递",
        },
        {
          value: "中通快递",
          label: "中通快递",
        },
        {
          value: "韵达快递",
          label: "韵达快递",
        },

        {
          value: "申通快递",
          label: "申通快递",
        },
      ],
      //订单跟踪状态
      ding:1
    };
  },
  methods: {
    async getUserList() {
      this.$axios
        .get("/api/Food/orderfy", {
          params: {
            pagenum: this.pagenum,
            pagesize: this.pagesize,
          },
        })
        .then((d) => {
          this.tableData = d.data.data;
          this.total = d.data.total;
          // if (d.data.data[1].Orderstatus=="已完成") {
          //   alert(1);
          //   this.shan="display: none;";
          // }
          console.log(d.data);
        })
        .catch((l) => {
          console.log(l);
        });
    },
    //查询
    async getselect() {
      this.$axios
        .get("/api/Food/orderselect", {
          params: {
            pagenum: this.pagenum,
            pagesize: this.pagesize,
            query: this.query,
            kaishi: this.kaishi,
            jieshu: this.jieshu,
            dingdan: this.dingdan,
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
    // //查询用户对话框
    // async updateDialog(id) {
    //   this.updateVisible = true;
    //   console.log(id);
    //   this.$axios
    //     .get("/api/Food/goodidselect", {
    //       params: {
    //         goodid: id,
    //       },
    //     })
    //     .then((dt) => {
    //       if (dt.data != "") {
    //         this.updateform = dt.data[0];
    //       } else {
    //         this.$message.error("查询用户信息失败");
    //       }
    //     })
    //     .catch((l) => {
    //       console.log(l);
    //     });
    // },
    // //修改对话框的关闭按钮和事件
    // updateDialogClosed() {
    //   this.$refs.updateformref.resetFields();
    // },
    //修改用户并提交
    // updateInfo() {
    //   this.$refs.updateformref.validate((valid) => {
    //     if (!valid) return;
    //     //发起数据请求
    //     this.$axios.post("/api/Food/goodUpdate", this.updateform).then((d) => {
    //       if (d.data == "修改成功") {
    //         this.updateVisible = false;
    //         this.getUserList();
    //         console.log(d.data);
    //         return this.$message.success("更新用户信息成功!");
    //       } else {
    //         return this.$message.error("更新用户信息失败!");
    //       }
    //     });
    //     console.log(valid);
    //   });
    // },
    //根据id删除用户
    // deleteUser(id) {
    //   console.log(id);
    //   this.$confirm("此操作将永久删除该用户, 是否继续?", "提示", {
    //     confirmButtonText: "确定",
    //     cancelButtonText: "取消",
    //     type: "warning",
    //   })
    //     .then(async () => {
    //       this.$axios
    //         .get("/api/Food/gooddelete", {
    //           params: {
    //             id: id,
    //           },
    //         })
    //         .then((d) => {
    //           if (d.data == "删除成功") {
    //             this.$message({
    //               type: "success",
    //               message: "删除成功!",
    //             });
    //             location.reload();
    //           } else {
    //             this.$message({
    //               type: "success",
    //               message: "删除失败!",
    //             });
    //           }
    //         })
    //         .catch((l) => {
    //           console.log(l);
    //         });
    //     })
    //     .catch(() => {
    //       this.$message({
    //         type: "info",
    //         message: "已取消删除",
    //       });
    //     });
    // },
    getselectss() {
      this.$axios
        .get("/api/Food/order")
        .then((s) => {
          // this.total = s.data.length;
          this.dingdan = "";
          this.kaishi = "";
          this.jieshu = "";
          this.query = "";
          this.getUserList();
        })
        .catch({});
    },
    //查询发货信息
    faUserd(id) {
      this.faVisible = true;
      this.$axios
        .get("/api/Food/ordersselect?id=" + id)
        .then((d) => {
          if (d.data != "") {
            this.faform = d.data[0];
            // this.faform.Userxixid=d.data[0].Userxixid.Userxixname;
            console.log(d.data[0].Userxixid.Userxixname);
          } else {
            this.$message.error("查询发货信息失败");
          }
        })
        .catch();
    },
    //提交发货
    faInfo() {
      this.$axios.post("/api/Food/ordersupdate", this.faform).then((d) => {
        if (d.data == "发货成功") {
          this.faVisible = false;
          this.getUserList();
          this.$message.success("发货成功!");
        } else {
          this.$message.error("发货失败!");
        }
      });
    },
    //如果已完成，就把删除按钮隐藏
    isshow(sender) {
      if (sender.Orderstatus == "已完成") {
        return true;
      }
      return false;
    },
    //如果未发货，就把按钮显示出来
    isshows(sender) {
      if (
        sender.Orderstatus == "待发货" 
      ) {
        return true;
      }
      return false;
    },
    //根据id删除订单
    deletes(id) {
      this.$confirm("此操作将永久删除该用户, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      }).then(async () => {
        this.$axios.get("/api/Food/orderdelete?id=" + id).then((d) => {
          if (d.data == "删除成功") {
            this.$message({
              type: "success",
              message: "删除成功!",
            });
            this.getUserList();
            location.reload();
          } else {
            this.$message({
              type: "success",
              message: "删除失败!",
            });
          }
        });
      });
    },
    //根据id查询dingd
    faUserdzhu(id){
this.dingdanVisible = true;
      this.$axios
        .get("/api/Food/ordersselect?id=" + id)
        .then((d) => {
          if (d.data != "") {
            if (d.data[0].Orderstatus=="待付款") {
              this.ding=1;
            }
            if (d.data[0].Orderstatus=="待发货") {
              this.ding=2;
            }
            if (d.data[0].Orderstatus=="待收货") {
              this.ding=3;
            }
            if (d.data[0].Orderstatus=="已完成") {
              this.ding=4;
            }
             if (d.data[0].Orderstatus=="待评价") {
              this.ding=4;
            }
            console.log(d.data);
          } else {
            this.$message.error("查询发货信息失败");
          }
        })
        .catch();
    },
    orderding(id){
this.$router.push({
          path: '/order/orderding',
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
    this.getUserList();
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
