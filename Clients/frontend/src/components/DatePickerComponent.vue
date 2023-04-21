<template>
  <div class="">
    <date-pick v-model="date"></date-pick>
    <input
      class="d-none"
      name="date"
      type="date"
      :value="date"
      @change="setChildData"
    />
  </div>
</template>

<script>
import DatePick from "vue-date-pick";
import "vue-date-pick/dist/vueDatePick.css";

export default {
  components: { DatePick },
  data: () => ({
    date: "2023-01-01",
  }),
  methods: {
    setChildData() {
      this.$emit("set-child-date", this.date);
    },
  },
};
</script>
