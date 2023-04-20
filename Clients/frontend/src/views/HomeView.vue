<template>
  <div class="home">
    <DashboardComponent />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import DashboardComponent from "@/components/DashboardComponent.vue";

@Component({
  components: {
    DashboardComponent,
  },
})
export default class HomeView extends Vue {}
</script>
