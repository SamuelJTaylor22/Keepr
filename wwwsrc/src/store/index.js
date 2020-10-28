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
    vaultKeeps: [],
    profileKeeps: [],
    profileVaults: [],
    myVaults: [],
    activeKeep: {creator:{}},
    activeVault:{}
  },
  mutations: {
    setProfile(state, profile) {
      state.profile = profile;
    },
    setOtherProfile(state, profile) {
      state.otherProfile = profile;
    },
    setProfileKeeps(state, profileKeeps) {
      state.profileKeeps = profileKeeps;
    },
    setProfileVaults(state, profileVaults) {
      state.profileVaults = profileVaults;
    },
    setMyVaults(state, profileVaults) {
      state.myVaults = profileVaults;
    },
    setKeeps(state, keeps){
      state.keeps = keeps
    },
    setVaultKeeps(state, keeps){
      state.vaultKeeps = keeps
    },
    setActiveKeep(state, keep){
      state.activeKeep = keep
    },
    setActiveVault(state, vault){
      state.activeVault = vault
    },
    addKeep(state, keep){
      state.profileKeeps.push(keep)
    },
    deleteKeep(state, id){
      state.profileKeeps = state.profileKeeps.filter(k => k.id != id)
    },
    deleteVault(state, id){
      state.profileVaults = state.profileVaults.filter(k => k.id != id)
    },
    removeKeepFromVault(state, id){
      state.vaultKeeps = state.vaultKeeps.filter(k => k.id != id)
    }
  },
  actions: {
    async getProfile({ commit, dispatch }) {
      try {
        let res = await api.get("profiles");
        commit("setProfile", res.data);
        dispatch("getMyVaults")
      } catch (error) {
        console.error(error);
      }
    },
    async getOtherProfile({ commit }, id) {
      try {
        let res = await api.get("profiles/"+id);
        commit("setOtherProfile", res.data);
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
        // console.log(res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async deleteKeep({commit}, id){
      try {
        await api.delete("keeps/"+id)
        commit("deleteKeep", id)
      } catch (error) {
        console.error(error);
      }
    },
    async getUserKeeps({commit}, id) {
      try {
        let res = await api.get(`profile/${id}/keeps`)
        commit("setKeeps", res.data)
        // console.log(res.data);
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
        // console.log(res.data);
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
        router.push({name:"Home"})
        console.error(error);
      }
    },
    async getMyVaults({commit, state}){
      try {
        let res = await api.get("profiles/"+state.profile.id + "/vaults")
        commit("setMyVaults", res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async deleteVault({commit}, id){
      try {
        await api.delete("vaults/"+id)
        commit("deleteVault", id)
      } catch (error) {
        console.error(error);
      }
    },
    //ANCHOR VaultKeeps Zone
    async getVaultKeeps({commit}, id){
      try {
        let res = await api.get("vaults/"+id+"/keeps")
        commit("setVaultKeeps", res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async addVaultKeep({commit}, payload){
      try {
        let res = await api.post("vaultkeeps", payload)
        // console.log(res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async removeKeepFromVault({commit}, payload){
      try {
        await api.delete("vaultkeeps/"+ payload.vaultKeepId)
        commit("removeKeepFromVault", payload.id)
      } catch (error) {
        console.error(error)
      }
    }
  },
});
