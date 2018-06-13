//1.�����WMBlog�����ݿ���
 ֪����ôд����bll,controller,Repository .
		EF��ܣ�Autofac ע�룬���Եģ��õ��˻�������ġ�
		Service���
DbContext ����ô�õġ�
DLL .
WMBlogDB 
public interface IBaseRepository<T> where T:class
{
	List<T> QueryWhere(Expression<Func<T,bool>> predicate);
	List<T> QueryJoin(Expression<Func<T,bool>> string[] tables);
	List<T> QueryOrder<S>(Expression<Func<T,bool>> predicate,Expression<Func<T,S>> orderBy,bool IsQueryOrderedBy);
	List<T> QueryByPage(int pageIndex,int pageSize,out int rowcount,Expiression<Func<T,bool>> predicate,Expression<Func<T,S>> keySelector,bool IsQueryOrderBy);

	void Edit(T model);
	void Delete(T model,bool isadded);
	void Add(T model);
	//ͳһ�ύ
	int SaveChanges();
	List<TResult> RunProc<TResult>(string sql,params object[] params);
}
public class BaseRepository<T>:IBaseRepository<T>
{
	//��ȡ���ݿ����ӣ����رգ��߳���Ψһ��
	WMBlogDB db{
		get{
			//�ȴ��̻߳���CallContext�� ����key ����EF�����������û�д����������浽CallContext�����С�
			//System.Runtime.Remoting.Messaging .
			var obj=CallContext.GetData(typeof(WMBlogDB).FullName);
			if(obj==null){
				obj=new WMBlogDB();
				CallContext.SetData(typeof(WMBlogDB).FullName,obj);
			}
			return obj;
		}
	}
	
	DbSet<T> _dbSet;

	public BaseRepository(){
		_dbSet=db.Set<T>();
	}

	public List<T> QueryWhere(Expression<Func<T,bool>> predicate){
		return _dbSet.Where(predicate).ToList();
	}
	public List<T> QueryJoin(Expression<Func<T,bool>> predicate,string[] tables){
		if(tables==null||tables.Any()==false){
			throw new Exception("ȱ�����ӱ���");
		}
		DbQuery<T> query=_dbSet;
		foreach(var table in tables){
			query=query.Include(table);
		}
		return query.Where(predicate).ToList();
	}
	public List<T> QueryOrderBy<S>(Expression<Func<T,bool>> predicate,Expression<Func<T,S>> keySelector,bool isQueryOrderBy){
		if(isQueryOrderBy){
			return _dbSet.Where(predicate).OrderBy(keySelector).ToList();
		}else{
			return _dbSet.Where(predicate).OrderByDescending(keySelector).ToList();
		}
	}

	public List<T> QueryByPage<S>(int pageIndex,int pageSize,Expression<Func<T,bool>> predicate,Expression<Func<T,S>> keySelector,bool IsQueryOrderBy){
		rowcount=_dbSet.Count(predicate);
		if(isQueryOrderBy){
			return _dbSet.Where(predicate).OrderBy(keySelector).Skip((pageIndex-1)*pageSize).Take(pageSize).ToList();
		}else{
			return _dbSet.Where(predicate).OrderByDescending(keySelector).Skip((pageIndex-1)*pageSize).Take(pageSize).ToList();
		}
	}
	public List<T> QueryByPageBegin<S>(int pageIndex,int pageSize,out int rowCount,Expression<Func<T,bool>> predicate,Expression<Func<T,S>> keySelector,bool isQueryOrderBy){
		rowCount=_dbSet.Count(predicate);
		if(isQueryOrderBy){
			return _dbSet.Where(predicate).OrderBy(keySelector).Skip(pageIndex).Take(pageSize).ToList();
		}else{
			return _dbSet.Where(predicate).OrderByDescending(keySelector).Skip(pageIndex).Take(pageSize).ToList();
		}
	}

	public void Edit(T model,string[] properties){
		if(model==null){
			throw new Exception("ʵ�岻��Ϊ��");
		}else if(propertys.Any()==false){
			throw new Exception("Ҫ�޸ĵ�����������һ��")
		}
		//��model׷����EF����
		DbEntityEntry entry=db.Entry(model);
		if(entry.State==EntityState.Detached){
			entry.State=EntityState.UnChanged;
			foreach(var item in propertys){
				entry.Property(item).IsModified=true;
			}
			//�ر�EF��ʵ��ĺϷ�����֤����
			db.Configuration.ValidateOnSaveEanbeld=false;
		}
	}

	public void Edit(T model){
		db.Entry(model).State=EntityState.Modified;
	}

	public void Add(T model){
		_dbSet.Add(model);
	}

	public void Delete(T model,bool isadded){
		if(!isadded){
			_dbSet.Attach(model);
		}
		_dbSet.Remove(model);
	}

	public int SaveChanges(){
		return db.SaveChanges();
	}

	public List<TResult> RunProc<TResult>(string sql,params object[] params){
		return db.Database.SqlQuery<TResult>(sql,params).ToList();
	} 

	public List<TResult> RunProc<TResult>(string sql,params object[] param){
		return db.Database.SqlQuery<TResult>(sql,params).ToList();
	}
}

public class AdvertisementRepository:BaseRepository<Advertisiment>:IAdvertisementRepository
{
}

public class BlogArticleRepostiory:BaseRepository<BlogArticle>,IBlogRepository
{
}
public class Guest
{
}

//Data
public class WMBlogDB:DbContext
{
	public WMBlogDB():base("name=WMBlogDB"){
	
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder){
		modelBuilder.Conventions.Remove<PluralizngTableNameConvention>();
		modelBuilder.Configurations.AddFormAssembly(Assembly.GetExecutingAssembly());
		base.OnModelCreating(modelBuilder);
	}
}

_Framework.

DAL .Ҫ�õ���������Repository .




������һ�¹���