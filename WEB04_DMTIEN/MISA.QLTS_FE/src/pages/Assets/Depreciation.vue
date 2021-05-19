<template>
  <div id="depreciation">
    <!-- header -->
    <Header :Route="depreciationRoute" />
  </div>
</template>

<script>
import Header from "../../components/Layout/Header";

export default {
  components: { Header },

  computed: {
    depreciationRoute() {
      return this.$store.getters.submenuFilter("Tính hao mòn");
    },
  },
};
</script>

<style>
</style>