<template>
   <div>
      <h1>{{ titulo }}</h1>
      <button v-if="mode!='add'" v-on:click="addMode()" class="btn btn-primary">
         {{$t('add.btnAdd')}}
      </button>

      <div class="alert alert-danger" v-if="errGet!=''">Error: {{errGet}}</div>
      
      <div class="container" v-if="errGet=='' && mode=='list'">
         <fieldset>
            <legend>{{$t('list.titulo')}}</legend>
            <div class="row justify-content-end">
               <select class="form-control col-md-3" v-model="slctVisible">
                  <option value="T">{{$t('list.optTodas')}}</option>
                  <option value="V">{{$t('list.optVisibles')}}</option>
                  <option value="N">{{$t('list.optNOVisibles')}}</option>
               </select>
            </div>
            <template v-for="(list, index) in getAll()">
               <div class="card" v-bind:key="list.id" v-if="getVisibility(index)"
               v-bind:style="{ 'background-color': list.color}">
                  <div class="card-body">
                     <div class="tituloLista">
                        {{list.nombre}}
                        <div class="btn-group">
                           <button v-on:click="deleteList(index)" 
                           class="btn btn-sm btn-danger" 
                           v-bind:title="$t('delete.ttpBtn')">
                              <font-awesome-icon icon="trash"></font-awesome-icon>
                           </button>
                           <button v-if="list.visible==true"  v-on:click="visibleList(index)" 
                           class="btn btn-sm btn-info" v-bind:title="$t('list.ttpNoVisible')">
                              <font-awesome-icon icon="eye-slash"></font-awesome-icon>
                           </button>
                           <button v-if="list.visible==false" v-on:click="visibleList(index)" 
                           class="btn btn-sm btn-info" v-bind:title="$t('list.ttpVisible')">
                              <font-awesome-icon icon="eye"></font-awesome-icon>
                           </button>
                        </div>
                     </div>
                     <small>{{list.fecha | formatDate}}</small>
                  </div>
               </div>
            </template>
            <div v-if="getCount()==0" class="alert alert-warning">
               {{$t('list.noLists')}}
            </div>
         </fieldset>
      </div>

      <div class="container" v-if="errGet=='' && mode=='add'">
         <fieldset>
            <legend>{{$t('add.titulo')}}</legend>
            <form>
               <div class="form-group">
                  <label for="addListNombre">{{$t('add.lblNombre')}}</label>
                  <input ref="newList_nombre" v-model="newList.nombre" type="text" 
                  class="form-control" id="addListNombre" 
                  v-bind:placeholder="$t('add.ttpNombre')">
                  <span v-if="errList.nombre" class="small text-danger">
                        {{$t('add.errNombre')}}
                  </span>
               </div>
               <div class="form-group">
                  <label for="addListColor"> {{$t('add.lblColor')}}</label>
                  <input v-model="newList.color" type="color" class="form-control" 
                  id="addListColor">
               </div>  
            </form>
            <div class="btn-group">
               <button v-on:click="addList()" class="btn btn-primary">
                  {{$t('add.btnAddList')}}
               </button>
               <button v-on:click="listMode()" class="btn btn-danger">
                  {{$t('app.btnAtras')}}
               </button>
            </div> 
            <div class="alert alert-danger" v-if="errAdd!=''">Error: {{errAdd}}</div>
         </fieldset>
      </div>
   </div>
</template>

<style scoped>
.tituloLista { font-size: 2em;}
</style>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import TaskList from '@/models/TaskList';
import moment from 'moment';

@Component({
   filters: {
      formatDate: function (value: any) {
         //TODO, verificar que hay algo en value!
         let aux = moment(value);
         return aux.format("DD/MM/YYYY hh:mm:ss");
      }
   }
})

export default class Mislistas extends Vue {
   $refs!: {
    newList_nombre: HTMLFormElement
  }
   @Prop() private titulo!: string;
   mode="list";
   //VUEX: lists:TaskList[]=[];
   newList:TaskList=new TaskList();
   errList= {nombre: false};
   slctVisible='T';
   errGet="";
   errAdd="";
   mounted() {
      this.$store.dispatch("getLists");
      this.errGet="";
      if (this.hayError()) {
         this.errGet = this.getError();
      }
   }
   hayError() {
      return this.$store.getters.getError!=""; 
   }
   getError() {
      return this.$store.getters.getError;
   }
   getAll() {
      return this.$store.getters.getAll;
   }
   getCount() {
      return this.$store.getters.getCount;
   }
   addMode():void {
      //VUEX: let nextId= this.lists.length>0?this.lists[this.lists.length-1].id+1:+1;
      //API: let nextId= this.$store.getters.getNextId;
      this.newList = new TaskList();
      //API: this.newList.id= nextId;
      this.mode="add";
      this.errList.nombre=false;
   }
   listMode():void {
      this.mode="list";
   }
   addList():void {
      if (this.newList.nombre != "") {
         this.newList.fecha = moment();
			//VUEX: this.lists.push(this.newList);
         //API: this.$store.commit('add', this.newList);
         this.$store.dispatch("addList", this.newList);
         this.errAdd="";
         if (this.hayError()) {
            this.errAdd = this.getError();
         } else {
            this.mode = 'list';
         }
		} else {
			this.errList.nombre = true;
			this.$refs.newList_nombre.focus();
		}
   }
   deleteList(list:number) {
      //VUEX: this.lists.splice(list, 1);
      this.$store.commit('del', list);
   }
   visibleList(index:number) {
      //VUEX: this.lists[index].visible = (this.lists[index].visible ? false : true);
      this.$store.commit('setVisible', index);
   }
   getVisibility(index:number) {
      let res = true;
      switch (this.slctVisible) {
         case "V":
            //VUEX: res = this.lists[index].visible;
            res = this.$store.getters.getVisible(index);
            break;
         case "N":
            //VUEX: res = !this.lists[index].visible;
            res = !this.$store.getters.getVisible(index);
            break;
         default:
            res = true;
            break;
      }
      return res;
   }
}
</script>


