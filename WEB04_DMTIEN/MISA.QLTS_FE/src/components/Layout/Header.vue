<template>
  <div id="header">
    <v-app-bar dense flat app height="50">
      <!-- link tiêu đề -->
      <v-breadcrumbs
        class="font-weight-bold"
        large
        :items="Route"
      ></v-breadcrumbs>

      <div
        class="ml-auto d-flex justify-space-between align-center"
        style="width: 400px"
      >
        <span class="font-weight-bold">Sở tài chính</span>

        <!-- input năm -->
        <div class="year">
          <input type="number" min="1990" max="2200" value="2021" />
        </div>

        <!-- nút dấu hỏi trợ giúp -->
        <v-btn depressed small color="#ffffff" icon
          ><img src="../../assets/help.svg"
        /></v-btn>

        <!-- chuông thông báo -->
        <v-btn depressed small color="#ffffff" icon>
          <v-badge color="#1EB5FE" content="1" overlap>
            <img src="../../assets/bell.svg" /></v-badge
        ></v-btn>

        <!-- gạch phân chia -->
        <img class="mx-4" src="../../assets/Divider.svg" />

        <!-- avatar -->
        <v-avatar size="33"
          ><img src="../../assets/avatar-default.png"
        /></v-avatar>

        <!-- nút mũi tên xuống -->
        <v-btn depressed small color="#ffffff" icon
          ><img src="../../assets/i_arrow_up_small.svg"
        /></v-btn>
      </div>
    </v-app-bar>
  </div>
</template>

<script>
import { mapState } from "vuex";

export default {
  props: {
    Route: Array,
  },

  data() {
    return {};
  },

  // Gán dữ liệu của menu từ store
  computed: mapState({
    menu: (state) => state.menu,
  }),
};
</script>

<style>
#header {
  margin: 0px 21px 0px 21px;
}

/* link route */
#header .v-breadcrumbs {
  padding-left: 4px;
}

#header div.v-breadcrumbs__item {
  color: #5e5f5f !important;
}

.v-application a {
  color: #00abfe !important;
}

#header .v-app-bar {
  background-color: #ffffff;
  border-bottom: 1px solid #ececec;
}

/* input năm */
#header .v-app-bar input[type="number"] {
  border: 1px solid #cecece;
  border-radius: 4px;
  padding: 5px 15px 5px 45px;
}

/* Hiện mũi tên lên xuống */
#header .v-app-bar input[type="number"]::-webkit-inner-spin-button {
  opacity: 1;
}

/* Hiện chữ Năm */
#header .v-app-bar .year {
  display: inline-block;
  position: relative;
}

#header .v-app-bar .year::before {
  position: absolute;
  left: 1em;
  top: 6px;
  content: "Năm";
}

#header .v-badge__badge {
  border-radius: 50%;
  display: inline-block;
  font-size: 11px;
  height: 13px;
  letter-spacing: -1px;
  line-height: 0;
  min-width: 13px;
  padding: 7px 0px;
  font-weight: 200;
  inset: auto auto calc(100% - 7px) calc(100% - 7px) !important;
}
</style>
