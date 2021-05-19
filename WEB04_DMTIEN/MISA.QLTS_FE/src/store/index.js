import Vue from "vue";
import Vuex from "vuex";
import {
  Route,
  AssetDomain,
  AssetTypeDomain,
  DepartmentDomain,
} from "../constants/constants";
import axios from "axios";

Vue.use(Vuex);

export const store = new Vuex.Store({
  state: {
    // Đóng/mở form
    dialog: false,

    // Menu và icon
    menu: [
      {
        text: "Tổng quan",
        href: Route + "overview",
        icon: require("../assets/computer-line.svg"),
        route: "/overview",
      },
      {
        text: "Tài sản",
        href: Route + "assets",
        icon: require("../assets/community-line.svg"),
        route: "/assets",
      },
      {
        text: "Công cụ dụng cụ",
        href: Route + "tools",
        icon: require("../assets/paint-brush-line.svg"),
        route: "/tools",
      },
      {
        text: "Danh mục",
        href: Route + "category",
        icon: require("../assets/common.svg"),
        route: "/category",
      },
      {
        text: "Tra cứu",
        href: Route + "search",
        icon: require("../assets/search-eye-line.svg"),
        route: "/search",
      },
      {
        text: "Hệ thống",
        href: Route + "system",
        icon: require("../assets/settings.svg"),
        route: "/system",
      },
      {
        text: "Báo cáo",
        href: Route + "report",
        icon: require("../assets/pie-chart-line.svg"),
        route: "/report",
      },
    ],

    // submenu
    submenu: [
      {
        text: "Ghi tăng",
        route: "/assets/appreciation",
      },
      {
        text: "Điều chuyển",
        route: "/assets/transfer",
      },
      {
        text: "Tính hao mòn",
        route: "/assets/depreciation",
      },
      {
        text: "Ghi giảm",
        route: "/assets/decrease",
      },
    ],

    // danh sách tài sản
    assets: [],

    // danh sách loại tài sản
    assetsType: [],

    // danh sách phòng ban
    department: [],
  },

  getters: {
    /**
     * Lọc route theo text truyền vào
     * @param {Object} state
     * @param {String} text
     * @returns menu tương ứng
     * CreatedBy: DMTIEN (15/5/2021)
     */
    routeFilter: (state) => (text) => {
      return state.menu.filter((item) => item.text == text);
    },

    /**
     * Lọc route cho submenu theo text truyền vào
     * @param {*} state
     * @param {*} getters
     * @param {String} text
     * @returns menu và submenu tương ứng
     * CreatedBy: DMTIEN (15/5/2021)
     */
    submenuFilter: (state, getters) => (text) => {
      return getters
        .routeFilter("Tài sản")
        .concat(state.submenu.filter((item) => item.text == text));
    },
  },

  mutations: {
    /**
     * Mở form
     * @param {Boolean}
     * CreatedBy: DMTIEN (15/5/2021)
     */
    openForm(state) {
      state.dialog = true;
    },

    /**
     * Đóng form
     * @param {Boolean}
     * CreatedBy: DMTIEN (15/5/2021)
     */
    closeForm(state) {
      state.dialog = false;
    },

    /**
     * Gán danh sách tài sản vào assets
     * @param {Array} state
     * @param {*} payload
     * CreatedBy: DMTIEN (15/5/2021)
     */
    setAssets: (state, payload) => {
      state.assets = payload;
    },

    /**
     * Gán danh sách loại tài sản vào assetsType
     * @param {Array} state
     * @param {*} payload
     * CreatedBy: DMTIEN (15/5/2021)
     */
    setAssetsType: (state, payload) => {
      // console.log(payload)
      state.assetsType = payload;
    },

    /**
     * Gán danh sách phòng ban vào department
     * @param {Array} state
     * @param {*} payload
     * CreatedBy: DMTIEN (15/5/2021)
     */
    setDepartment: (state, payload) => {
      state.department = payload;
    },
  },

  actions: {
    /**
     * Lấy dữ liệu tài sản
     * @param {*} context
     * CreatedBy: DMTIEN (15/5/2021)
     */
    async getAssets(context) {
      const res = await axios.get(AssetDomain);
      context.commit("setAssets", res.data);
    },

    /**
     * Lấy dữ liệu loại tài sản
     * @param {*} context
     * CreatedBy: DMTIEN (15/5/2021)
     */
    async getAssetsType(context) {
      const res = await axios.get(AssetTypeDomain);
      context.commit("setAssetsType", res.data);
    },

    /**
     * Lấy dữ liệu phòng ban
     * @param {*} context
     * CreatedBy: DMTIEN (15/5/2021)
     */
    async getDepartment(context) {
      const res = await axios.get(DepartmentDomain);
      context.commit("setDepartment", res.data);
    },

    /**
     * Xoá tài sản
     * CreatedBy: DMTIEN (15/5/2021)
     */
    async deleteAsset(context, id) {
      await axios.delete(AssetDomain + id);

      //  gọi lại dữ liệu
      await context.dispatch("getAssets");
    },
  },
});
