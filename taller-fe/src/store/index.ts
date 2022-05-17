import Vue from 'vue'
import Vuex from 'vuex'

import TaskList from "@/models/TaskList";
import serviceAPI from '@/services/service'; // @ is an alias to /src
import { APIStatus } from '@/http-config';

Vue.use(Vuex)

export default new Vuex.Store({
   state: {
      listas: Array<TaskList>(),
      error: ""
   },
   getters: {
      getAll(state) {
         return state.listas;
      },
      getCount(state) {
         return state.listas.length;
      },
      getNextId(state) {
         return state.listas.length>0?state.listas[state.listas.length-1].id+1:1;
      },
      getVisible: (state) => (index: number) => {
         return state.listas[index].visible;
      },
      getError(state) {
         return state.error;
      }
   },
   mutations: {
      setLists(state, lists) {
         state.listas = lists;
      },
      add(state, lista: TaskList) {
         state.listas.push(lista);
      },
      del(state, index: number) {
         state.listas.splice(index, 1);
      },
      setVisible(state, index:number) {
         state.listas[index].visible = (state.listas[index].visible ? false : true);
      }
   },
   actions: {
      getLists({ commit }) {
         this.state.error="";
         serviceAPI.getRaw("APIListas").then(r=> {
            if (r.status==APIStatus.OK) {
               commit('setLists', r.respuesta)
            } else {
               this.state.error=r.error;   
            }
         }).catch(e=> {
            this.state.error=e;
         });
      }, 
      addList({ commit }, lista) {
         this.state.error="";
         lista.fecha = lista.fecha.format("YYYY-MM-DDTHH:mm:ss");
         lista.visible = lista.visible?"S":"N";
         serviceAPI.post("APIListas", lista).then(r=> {
            if (r.status==APIStatus.OK) {
               commit('add', r.respuesta)
            } else {
               this.state.error=r.error;   
            }
         }).catch(e=> {
            this.state.error=e;
         });
      }
   },
   modules: {
   }
})
