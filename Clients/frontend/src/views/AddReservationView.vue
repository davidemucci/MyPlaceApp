<template>
  <div class="wrapper">
    <h1>Add New Reservation:</h1>
    <div class="form-box">
      <form class="w-50 m-auto" method="post">
        <DatePickerComponent></DatePickerComponent>
        <!-- <input type="date" name="date" /> -->
        <div class="mb-3">
          <label for="" class="form-label">Building</label>
          <select
            class="form-select form-select-lg"
            name="building"
            id="building"
            v-model="buildingId"
          >
            <option
              v-for="building in buildingList"
              :key="building.id"
              :value="building.id"
            >
              {{ building.name }}
            </option>
          </select>
        </div>
        <div class="mb-3">
          <label for="" class="form-label">Office</label>
          <select
            v-model="officeId"
            class="form-select form-select-lg"
            name="officeId"
            id="officeList"
          >
            <option
              v-for="office in officeList"
              :value="office.id"
              :key="office.id"
            >
              {{ office.name }}
            </option>
          </select>
        </div>
        <button type="submit" class="btn btn-primary">Submit</button>
      </form>
    </div>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Watch } from "vue-property-decorator";
import axios from "axios";
import DatePickerComponent from "@/components/DatePickerComponent.vue";
@Component({
  components: {
    DatePickerComponent,
  },
})
export default class AddReservationView extends Vue {
  officeList: Array<any> | null = null;
  officeId = 1;
  buildingList: Array<any> | null = null;
  buildingId = 1;
  date!: string;
  getOfficeEvent(event: any) {
    console.log(event.target.value);
    this.getOffice(event.target.value);
  }
  getOffice(buildingId: number): void {
    axios
      .get(`https://localhost:7052/api/building/${buildingId}/office`)
      .then((resp) => {
        console.log(resp.data);
        this.officeList = [];
        this.officeList = resp.data;
        if (resp.data.length > 0) {
          this.officeId = resp.data[0].id;
        }
      })
      .catch((e) => console.error(e));
  }
  getBuilding(): void {
    axios
      .get("https://localhost:7052/api/buildings")
      .then((resp) => {
        this.buildingList = resp.data;
        console.log(resp.data);
      })
      .catch((e) => console.error(e));
  }
  mounted() {
    this.getBuilding();
    this.getOffice(this.buildingId);
  }
  @Watch("buildingId")
  onPropertyChanged(value: number) {
    this.getOffice(value);
  }
}
</script>
