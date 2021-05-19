<template>
  <div id="footer">
    <v-footer absolute>
      <p class="mr-auto font-weight-bold">
        Tổng số tài sản: {{ this.$store.state.assets.length }}
      </p>
      <p class="ml-auto font-weight-bold">Tổng nguyên giá: {{ total | formatMoney}}</p>
    </v-footer>
  </div>
</template>

<script>
export default {
  data() {
    return {
      total: 0,
    };
  },

  filters: {
    /**
     * Chuyển đổi kiểu hiển thị tiền theo VND
     * @param {Int}
     * CreatedBy: DMTIEN (15/5/2021)
     */
    formatMoney(salary) {
      if (!salary) {
        return " Không có dữ liệu ";
      }
      var formatter = new Intl.NumberFormat("de-DE", {
        style: "currency",
        currency: "VND",
        minimumFractionDigits: 0,
      });
      return formatter.format(salary);
    },
  },

  methods: {
    async countPrice() {
      try {
        await this.$store.dispatch("getAssets");
        let records = this.$store.state.assets;
        for (let i = 0; i < records.length; i++) {
          if (records[i].OriginalPrice)
            this.total += parseInt(records[i].OriginalPrice);
        }
      } catch (ex) {
        ex;
      }
    },
  },
  mounted() {
    this.countPrice();
  },
};
</script>

<style>
#footer .v-footer {
  height: 60px;
  background-color: #ffffff;
  width: calc(100% - 139px);
}
</style>
