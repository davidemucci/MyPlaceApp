<template>
  <div class="wrapper">
    <h1>Add New Reservation:</h1>
    <div class="form-box">
      <FormReservation></FormReservation>
    </div>
  </div>
</template>
<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import FormReservation from "@/components/FormReservationComponent.vue";
@Component({
  components: {
    FormReservation: FormReservation,
  },
})
export default class AddReservationView extends Vue {}
</script>
