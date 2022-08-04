<template>
	<div id="warp">
		你选择的是：
		<mark v-for="(item,index) in arr">
			<span>{{item.name}}</span><a style="color: red;" href="javascript:;" @click="remove(index,item.id)">X</a>
		</mark>
		<!-- <span v-for="(item,index) in arr">{{item.name}}</span> -->
		<div>
			<ul>
				<li v-for="(item,index) in phoneData">
					<span>{{item.title}}:</span>
					<a href="javascript:;" v-for="option,i in item.list" v-bind:class="{active:item.index===i}" @click="listBundle(option,index,i)">{{option}}
					</a>
				</li>
			</ul>
		</div>
	</div>
</template>

<script>
	export default {
		data() {
			return {
				phoneData: [{
						title: '手机',
						list: ['小米6', '一加5', '荣耀9', '红米Note', '4X', '华为-mate 9', '红米4X', '美图M8', '锤子-坚果', 'PRO']
					},
					{
						title: '平板',
						list: ['小米6', '一加5', '荣耀9', '红米Note', '4X', '华为-mate 9', '红米4X', '美图M8', '锤子-坚果', 'PRO']
					},
					{
						title: '电脑',
						list: ['小米6', '一加5', '荣耀9', '红米Note', '4X', '华为-mate 9', '红米4X', '美图M8', '锤子-坚果', 'PRO']
					},
					{
						title: '数码',
						list: ['小米6', '一加5', '荣耀9', '红米Note', '4X', '华为-mate 9', '红米4X', '美图M8', '锤子-坚果', 'PRO']
					}
				],
				// listData: this.phoneData,
				arr: []
			}
		},
		methods: {
			listBundle(option, index, i) {
				//找到操作的这一行，把这一行的数据中的index，设置为点击的标签的下标 
				this.phoneData[index].index = i;
				let param = { //获取到元素的index 和 name
					id: index,
					name: option
				}
				this.arr.push(param) //将获取的元素放到数组里面
				// 用户点击重复的之后去除重复的数据 保证只存在一个相同的id
				for (let i = 0; i < this.arr.length; i++) {
					for (let j = i + 1; j < this.arr.length; j++) {
						if (this.arr[i]['id'] == this.arr[j]['id']) { //判断是否存在重复的
							// 将最后点击的id的name 赋值给现有的id里面的name
							this.arr[i]["name"] = this.arr[j]['name']
							this.arr.splice(j, 1) // 移除数据里面重复的
						}
					}
				}
			},
			remove(index, id) {
				this.$delete(this.arr, index, 1); //删除arr里面用户点击的id
				this.phoneData[id].index = -1;
			}
		}
	}
</script>

<style scoped="scoped">
	#warp {
		width: 800px;
		height: 260px;
		margin: 0 auto;
		border: 1px solid #ccc;
		background-color: pink;
	}

	mark {
		width: 100%;
		height: 30px;
		border: 1px solid pink;
	}

	li {
		list-style: none;
		float: left;
		margin: 10px 20px 0 0;
		width: 100%;
		height: 70;
		border-bottom: 1px dashed #ccc;
	}

	#warp div {
		width: 100%;
		height: 100%;
	}

	a {
		display: inline-block;
		margin: 10px 20px 0 0;
		text-decoration: none;
	}

	.active {
		background-color: red;
	}
</style>

