<template>
  <main class="container-fluid mt-2">
    <div class="row">
      <div class="col-12 col-md-4">
        <div class="card">
          <img class="card-img-top" :src="profile.picture" alt="">
          <div class="card-body">
            <h4 class="card-title">{{profile.name}}</h4>
            <p class="card-text">Keeps: {{myKeeps.length}} Vaults:{{publicVaults.length}}</p>
          </div>
        </div>
      </div>
      <div class="col-12 col-md-4">
        <div class="row">
          <div class="col-12"><h4>My Keeps <button type="button" class="btn btn-success" data-toggle="modal" data-target="#newKeep">New</button></h4> </div>
          <div class="col-12 card-columns"><keep v-for="keep in myKeeps" :key="keep.id" :keepData="keep"  v-on:selected="toggleModal"/></div>
        </div>
      </div>
      <div class="col-12 col-md-4">
        <div class="row">
          <div class="col-12"><h4>My Vaults<button type="button" class="btn btn-success" data-toggle="modal" data-target="#newVault">New</button></h4></div>
          <div class="col-12 card-columns"><vault v-for="vault in myVaults" :key="vault.id" :vaultData="vault"  v-on:selected="toggleModal"/></div>
        </div>
      </div>
    </div>
    <keepModal/>
        <div class="modal fade" id="newKeep" tabindex="-1" role="dialog">
          <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">New Keep</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body row">
                <form @submit.prevent="addKeep">
                  <div class="form-group">
                    <label for="">Name</label>
                    <input v-model="newKeep.name" type="text" class="form-control" placeholder="" aria-describedby="helpId">
                    <label for="">Description</label>
                    <input v-model="newKeep.description" type="text" class="form-control" placeholder="" aria-describedby="helpId">
                    <label for="">Img URL</label>
                    <input v-model="newKeep.img" type="text" class="form-control" placeholder="" aria-describedby="helpId">
                    <button type="submit" class="btn btn-primary mt-1">Submit</button>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div> 
        <div class="modal fade" id="newVault" tabindex="-1" role="dialog">
          <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">New Vault</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body row">
                <form @submit.prevent="addVault">
                  <div class="form-group">
                    <label for="">Name</label>
                    <input v-model="newVault.name" type="text" class="form-control" placeholder="" aria-describedby="helpId">
                    <label for="">Description</label>
                    <input v-model="newVault.description" type="text" class="form-control" placeholder="" aria-describedby="helpId">
                    <label for="">Private</label>
                    <input v-model="newVault.isprivate" type="checkbox" class="form-control" placeholder="" aria-describedby="helpId">
                    <button type="submit" class="btn btn-primary mt-1">Submit</button>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div> 
  </main>
</template>

<script>
import keep from '../components/keep'
import vault from '../components/vaultCard'
import keepModal from '../components/keepModal'
export default {
name:"profile",
mounted(){
  this.$store.dispatch("getProfileStuff", this.$route.params.id)
  this.$store.dispatch("getOtherProfile", this.$route.params.id)
},
computed: {
  profile(){
    return this.$store.state.otherProfile
  },
  keeps(){
    return this.$store.state.profileKeeps
  },
  vaults(){
    return this.$store.state.profileVaults
  }
},  
methods: {
  toggleModal(){
    $('#keepModal').modal('show')
  }
},
components:{
  keep,
  keepModal,
  vault
}
}
</script>

<style>

</style>