<template>
  <div class="customer">
    <!-- content header -->
    <div class="content-header">
      <!-- content header input field -->
      <input-fields :title="title"></input-fields>

      <!-- content header buttons -->
      <Buttons :title="title" />
      <!-- @isShowValue="sendIsShow($event)" -->
    </div>

    <!-- content table -->
    <Table />

    <!-- form -->
    <Form :title="title"></Form>
  </div>
</template>

<script>
import Table from "../components/pages/table.vue";
import InputFields from "../components/pages/input-fields.vue";
import Buttons from "../components/pages/buttons.vue";
import Form from "../components/pages/form/form.vue";

export default {
  components: {
    Table,
    InputFields,
    Buttons,
    Form,
  },

  data() {
    return {
      title: "khách hàng",
    };
  },
};
</script>

<style>
</style>