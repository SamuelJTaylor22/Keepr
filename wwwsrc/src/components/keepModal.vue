<template>
  <div class="">
        <div class="modal fade" id="keepModal" tabindex="-1" role="dialog">
          <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">{{activeKeep.name}}</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body row">
                <img class="img-fluid col-6" :src="activeKeep.img" alt="">
                <div class="col-6">
                  <h4>By: {{activeKeep.creator.name}}<img class="img-fluid" :src="activeKeep.creator.picture" alt=""></h4>
                  <p>Keeps: {{activeKeep.keeps}} Views: {{activeKeep.views}}</p>
                  <p>{{activeKeep.description}}</p>
                </div>
              </div>
              <div class="modal-footer">
                <button v-if="$auth.userInfo.id == activeKeep.creatorId && $route.name=='MyProfile'" type="button" class="btn btn-secondary" @click="deleteKeep">Delete</button>
                <button v-if="activeVault.creatorId == $auth.userInfo.id" type="button" class="btn btn-primary" @click="removeKeep">Remove from this Vault</button>
                <div v-if="$auth.isAuthenticated" class="btn-group" role="group" aria-label="">
                  <div class="btn-group" role="group">
                    <button id="dropdownId" type="button" class="btn btn-secondary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true"
                        aria-expanded="false">
                      Keep It!
                    </button>
                    <div class="dropdown-menu" aria-labelledby="dropdownId">
                      <a v-for="vault in myVaults" :key="vault.id" @click="keepIt(vault.id)" class="dropdown-item" href="#">{{vault.name}}</a>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div> 
      </div>
</template>

<script>
import as from '../services/alertsService'
export default {
name: "keepmodal",
computed:{
      activeKeep(){
      return this.$store.state.activeKeep
    },
      myVaults(){
    return this.$store.state.myVaults
    },
      activeVault(){
    return this.$store.state.activeVault    
      }
},
methods:{
  async deleteKeep(){
    if(await as.confirmAction()){
    this.$store.dispatch('deleteKeep', this.activeKeep.id)
    $('#keepModal').modal('toggle')
    }
  },
  keepIt(id){
    this.$store.dispatch("addVaultKeep", {vaultId: id, keepId: this.activeKeep.id})
  },
  removeKeep(event){
    this.$emit("remove", this.activeKeep.id)
  }
}
}
</script>

<style>

</style>