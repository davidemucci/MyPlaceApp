<template>
  <div class="wrapper">
    <div class="container">
      <div class="text-center">
        <h2>Benvenuto {{ UserStore.name }}</h2>
        <a
          class="btn btn-primary"
          v-on:click="UserStore.changeUser()"
          role="button"
          >Change User</a
        >
      </div>
      <div class="table-responsive-lg">
        <table class="table table-dark">
          <thead>
            <tr>
              <th scope="col">CodeId</th>
              <th scope="col">Data</th>
              <th scope="col">Ufficio</th>
              <th scope="col">Edificio</th>
            </tr>
          </thead>
          <tbody v-if="reservationList != undefined">
            <tr
              class=""
              v-for="res in reservationList"
              :key="res.reservationCode"
            >
              <td scope="row">{{ res.reservationCode }}</td>
              <td>{{ res.date }}</td>
              <td>{{ res.office.name }}</td>
              <td>{{ res.office.building.name }}</td>
            </tr>
          </tbody>
          <tbody v-else class="text-center">
            <h2>Loading</h2>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Watch } from "vue-property-decorator";
import { useUserStore } from "@/states/UserState";
import axios from "axios";
import { Reservation } from "@/interfaces/Entities";
@Component({
  components: {
    DashboardComponent,
  },
})
export default class DashboardComponent extends Vue {
  reservationList: Reservation[] | null = null;
  UserStore = useUserStore();

  getValue(userId: number): void {
    axios
      .get(`https://localhost:7052/api/users/${userId}/reservations`)
      .then((result) => {
        this.reservationList = result.data;
      })
      .catch((e) => console.error(e));
  }
  mounted() {
    this.getValue(this.UserStore.userId);
  }

  @Watch("UserStore.userId")
  OnPropertyChanged(value: number) {
    this.getValue(value);
  }
}
</script>
