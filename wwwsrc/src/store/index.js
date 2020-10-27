import Vue from "vue";
import Vuex from "vuex";
import router from "../router/index.js";
import { api } from "../services/AxiosService.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    otherProfile:{},
    keeps: [],
    profileKeeps: [],
    profileVaults: [],
    activeKeep: {creator:{}},
    activeVault:{}
  },
  mutations: {
    setProfile(state, profile) {
      state.profile = profile;
    },
    setProfileKeeps(state, profileKeeps) {
      state.profileKeeps = profileKeeps;
    },
    setProfileVaults(state, profileVaults) {
      state.profileVaults = profileVaults;
    },
    setKeeps(state, keeps){
      state.keeps = keeps
    },
    setActiveKeep(state, keep){
      state.activeKeep = keep
    },
    setActiveVault(state, vault){
      state.activeVault = vault
    },
    addKeep(state, keep){
      state.profileKeeps.push(keep)
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
    async getProfileStuff({ commit }, id) {
      try {
        let reskeeps = await api.get("profiles/"+id +"/keeps");
        commit("setProfileKeeps", reskeeps.data);
        let resvaults = await api.get("profiles/"+id +"/vaults");
        commit("setProfileVaults", resvaults.data);
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
    async getUserKeeps({commit}, id) {
      try {
        let res = await api.get(`profile/${id}/keeps`)
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
    async createKeep({commit, dispatch, state}, newKeep){
      try {
        let res = await api.post("keeps", newKeep)
        commit("addKeep", res.data)
        dispatch("setActiveKeep", res.data.id)
        dispatch("getProfileStuff", state.profile.id)
        console.log(res.data);
      }
      catch(error){
        console.error(error);
      }
    },
    //ANCHOR Vault Zone
    async createVault({commit, dispatch}, newVault){
      try {
        let res = await api.post("vaults", newVault)
        router.push({name:"Vault", params:{id:res.data.id}})
      } catch (error) {
        console.error(error);
      }
    },
    async getVault({commit}, id){
      try {
        let res = await api.get("vaults/"+id)
        commit("setActiveVault", res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async getVaultKeeps({commit}, id){
      try {
        let res = await api.get("vaults/"+id+"/keeps")
        commit("setKeeps", res.data)
      } catch (error) {
        console.error(error);
      }
    }
  },
});
