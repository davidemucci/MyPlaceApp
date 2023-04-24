import { defineStore } from "pinia";
export const useUserStore = defineStore("userStore", {
  state: () => ({ userId: 2, name: "Davide" }),
  getters: {
    getUserId: (state) => state.userId,
  },
  actions: {
    changeUser() {
      if (this.userId == 2) {
        (this.userId = 3), (this.name = "Luca");
      } else {
        (this.userId = 2), (this.name = "Davide");
      }
    },
  },
});
//# sourceMappingURL=UserState.js.map
