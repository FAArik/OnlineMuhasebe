export class Navigation{
    routerLnk:string ="";
    name:string="";
    icon:string="";
}

export const Navigations:Navigation[]=[
    {
        routerLnk:"/",
        name:"Ana Sayfa",
        icon:"fa fa-home"
    },
    {
        routerLnk:"ucafs",
        name:"Hesap planı",
        icon:"fa fa-file-signature"
    },
]