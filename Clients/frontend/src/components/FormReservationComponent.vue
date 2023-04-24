<template>
  <form class="w-50 m-auto" method="post" @submit.prevent="onSubmit">
    <input type="date" name="date" v-model="selectedDate" />
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
</template>
<script lang="ts">
import { Component, Watch, Vue } from "vue-property-decorator";
import { useUserStore } from "@/states/UserState";
import axios from "axios";
import { Building, Office } from "@/interfaces/Entities";
@Component
export default class AddReservationView extends Vue {
  useUserStore = useUserStore();
  userId = useUserStore().userId;
  officeList: Array<Office> | null = null;
  officeId = null;
  buildingList: Array<Building> | null = null;
  buildingId: number | null = null;
  selectedDate: string | null = null;
  getOfficeEvent(event): void {
    console.log(event.target.value);
    this.getOffice(event.target.value);
  }
  getOffice(buildingId: number): void {
    axios
      .get(`https://localhost:7052/api/building/${buildingId}/office`)
      .then((resp) => {
        // console.log(resp.data);
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
        if (resp.data.length > 0) {
          this.buildingId = resp.data[0].id;
          this.getOffice(resp.data[0].id);
        }
      })
      .catch((e) => console.error(e));
  }
  onSubmit() {
    axios
      .post(`https://localhost:7052/api/users/${this.userId}/reservations`, {
        date: this.selectedDate,
        officeId: this.officeId,
        userId: this.userId,
      })
      .then(function (response) {
        console.log(response);
        alert("Salvataggio riuscito");
      })
      .catch(function (error) {
        console.log(error);
      });
  }
  getDate(value: string) {
    console.log(value);
  }
  mounted() {
    this.getBuilding();
  }
  @Watch("buildingId")
  onPropertyChanged(value: number) {
    this.getOffice(value);
  }
}
</script>
