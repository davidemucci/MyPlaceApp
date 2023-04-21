<template>
  <div class="wrapper">
    <div class="container">
      <div class="text-center">
        <h2>Benvenuto {{ user.firstName + " " + user.lastName }}</h2>
        <a class="btn btn-primary" v-on:click="changeUser" role="button"
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
import axios from "axios";
import { Reservation } from "@/interfaces/Entities";

@Component
export default class DashboardComponent extends Vue {
  reservationList: Reservation[] | null = null;
  userId = 11;
  user = {
    firstName: "",
    lastName: "",
  };

  changeUser(): void {
    if (this.userId == 1) {
      this.userId = 11;
    } else {
      this.userId = 1;
    }
  }

  getValue(userId: number): void {
    axios
      .get(`https://localhost:7052/api/users/${userId}/reservations`)
      .then((result) => {
        this.reservationList = result.data;
        if (result.data.length > 0) {
          this.user.firstName = result.data[0].user.firstName;
          this.user.lastName = result.data[1].user.lastName;
        }
        console.log(this.reservationList);
      })
      .catch((e) => console.error(e));
  }
  mounted() {
    this.getValue(this.userId);
  }

  @Watch("userId")
  OnPropertyChanged(value: number) {
    this.getValue(value);
  }
}
</script>
