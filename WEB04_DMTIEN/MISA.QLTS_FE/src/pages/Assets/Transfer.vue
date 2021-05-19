<template>
  <div id="transfer">
    <!-- header -->
    <Header :Route="transferRoute" />
  </div>
</template>

<script>
import Header from "../../components/Layout/Header";

export default {
  components: { Header },

  computed: {
    transferRoute() {
      return this.$store.getters.submenuFilter("Điều chuyển");
    },
  },
};
</script>

<style>
</style>