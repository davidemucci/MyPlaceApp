<template>
  <div class="wrapper">
    <nav>
      <img
        alt="Vue logo"
        height="70px"
        src="https://uploads-ssl.webflow.com/60db19814054913970b08123/61b99b14fcacb9036f212d40_MyPlace_betalogo_baseorange%403x.png"
      />

      <div class="col">
        <router-link to="/">Dashboard</router-link> |
        <router-link to="/addreservation">Prenota</router-link>
      </div>
    </nav>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component
export default class NavbarComponent extends Vue {}
</script>
