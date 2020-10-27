import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    keeps: [],
    activeKeep: {}
  },
  mutations: {
    setProfile(state, profile) {
      state.profile = profile;
    },
    setKeeps(state, keeps){
      state.keeps = keeps
    },
    setActiveKeep(state, keep){
      state.activeKeep = keep
    }
  },
  actions: {
    async getProfile({ commit }) {
      try {
        let res = await api.get("profiles");
        commit("setProfile", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    //ANCHOR Keeps Section
    async getKeeps({commit}) {
      try {
        let res = await api.get("keeps")
        commit("setKeeps", res.data)
        console.log(res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async setActiveKeep({commit}, id){
      try {
        let res = await api.get("keeps/"+id)
        commit("setActiveKeep", res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async createKeep({commit}, newKeep){
      try {
        let res = await api.post("keeps", newKeep)
        console.log(res.data);
      }
      catch(error){
        console.error(error);
      }
    }
  },
});
