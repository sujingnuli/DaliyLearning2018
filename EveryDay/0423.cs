1.调用这个方法的时候，没有实现。
看看哪里，没有实现，打断电，调试。
2.Index的页面怎么写

<div class='row-fluid'>
	<div class='span4'>
		<a class='btn red' id='delete' href='javascript:;'><i class='icon-trash icon-white'></i>删除</a>
		<a class='btn blue thickbox' href='@Url.Action("Create")?TB_iframe=true&width=350&height=500' ><i class='icon-plus icon-white'></i>新增</a>
	</div>
	<div class='span8'>
		@using(Html.BeginForm(null,null,null,FormMethod.Get,new{id="search"})){
			
		}
	</div>
</div>