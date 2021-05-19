import Vue from "vue";
import VueRouter from "vue-router";
import Overview from "../pages/Overview.vue";
import Assets from "../pages/Assets.vue";
import Appreciation from "../pages/Assets/Appreciation.vue";
import Transfer from "../pages/Assets/Transfer.vue";
import Depreciation from "../pages/Assets/Depreciation.vue";
import Decrease from "../pages/Assets/Decrease.vue";
import Tools from "../pages/Tools.vue";
import Category from "../pages/Category.vue";
import Search from "../pages/Search.vue";
import System from "../pages/System.vue";
import Report from "../pages/Report.vue";

Vue.use(VueRouter);

const routes = [
  // Tổng quan
  {
    path: "/overview",
    name: "Overview",
    component: Overview,
  },

  // tài sản
  {
    path: "/assets",
    name: "Assets",
    component: Assets,
    children: [
      // Ghi tăng
      {
        path: "appreciation",
        name: "appreciation",
        component: Appreciation,
      },

      // Điều chuyển
      {
        path: "transfer",
        name: "transfer",
        component: Transfer,
      },

      // Tính hao mòn
      {
        path: "depreciation",
        name: "depreciation",
        component: Depreciation,
      },

      // Ghi giảm
      {
        path: "decrease",
        name: "decrease",
        component: Decrease,
      },
    ],
  },

  // Công cụ dụng cụ
  {
    path: "/tools",
    name: "tools",
    component: Tools,
  },

  // Danh mục
  {
    path: "/category",
    name: "category",
    component: Category,
  },

  // Tra cứu
  {
    path: "/search",
    name: "search",
    component: Search,
  },

  // Hệ thống
  {
    path: "/system",
    name: "system",
    component: System,
  },

  // Báo cáo
  {
    path: "/report",
    name: "report",
    component: Report,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
