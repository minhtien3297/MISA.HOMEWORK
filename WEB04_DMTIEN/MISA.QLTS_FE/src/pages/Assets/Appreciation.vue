<template>
  <div id="appreciation">
    <!-- header -->
    <Header :Route="appreciationRoute" />

    <!-- toolbar -->
    <Toolbars />

    <!-- table -->
    <Table />

    <!-- footer -->
    <Footer />
  </div>
</template>

<script>
import Header from "../../components/Layout/Header";
import Toolbars from "../../components/Contents/Toolbars";
import Table from "../../components/Contents/Table.vue";
import Footer from "../../components/Contents/Footer.vue";
import { mapActions } from "vuex";

export default {
  components: { Header, Toolbars, Table, Footer },

  data() {
    return {};
  },

  computed: {
    appreciationRoute() {
      return this.$store.getters.submenuFilter("Ghi tăng");
    },
  },

  // Lấy dữ liệu tài sản vào state
  created() {
    this.getData();
  },

  methods: {
    ...mapActions(["getAssets", "getAssetsType", "getDepartment"]),

    /**
     * lấy dữ liệu tài sản, loại tài sản, phòng ban
     * CreatedBy: DMTIEN (15/5/2021)
     */
    async getData() {
      await this.getAssets();
      await this.getAssetsType();
      await this.getDepartment();
    },
  },
};
</script>

<style></style>
