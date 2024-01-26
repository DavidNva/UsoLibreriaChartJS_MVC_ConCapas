create proc SP_RetornarVentas
 as
 begin

  declare @fecha_maxima datetime;
  declare @fecha_minimo datetime;

  set @fecha_maxima = ( select MAX(OrderDate) from [Sales].[SalesOrderHeader]);

  set @fecha_minimo =  DATEADD(MONTH,-2,@fecha_maxima);
  --vamos a restarle dias a nuestra fecha minima
  set @fecha_minimo =  DATEADD(DAY,- ( day(@fecha_minimo) - 1  )  ,@fecha_minimo);

  -- select @fecha_maxima;
  -- select @fecha_minimo;

  --agregamos el nombre de mes y los nombres de columnas
  select year(OrderDate)[anio], MONTH(OrderDate)[mes_valor],DATENAME(MONTH,OrderDate)[mes],COUNT(*)[cantidad] 
  from [Sales].[SalesOrderHeader] 
  where OrderDate between @fecha_minimo and @fecha_maxima
  group by year(OrderDate), MONTH(OrderDate),DATENAME(MONTH,OrderDate)
  order by year(OrderDate), MONTH(OrderDate) asc

 end
 exec  SP_RetornarVentas
 GO

 create proc SP_RetornarProductos
 as
 begin

  declare @fecha_maxima datetime;
  declare @fecha_minimo datetime;

  set @fecha_maxima = ( select MAX(OrderDate) from [Sales].[SalesOrderHeader]);

  set @fecha_minimo =  DATEADD(MONTH,-2,@fecha_maxima);
  --vamos a restarle dias a nuestra fecha minima
  set @fecha_minimo =  DATEADD(DAY,- ( day(@fecha_minimo) - 1  )  ,@fecha_minimo);


 --agregamos solo el top 4 y nombre de columnas
  select top 4 p.Name[producto],count(p.ProductID)[cantidad] from [Sales].[SalesOrderHeader] v
 inner join [Sales].[SalesOrderDetail] d on d.SalesOrderID = v.SalesOrderID
 inner join [Production].[Product] p on d.ProductID = p.ProductID
 where v.OrderDate between @fecha_minimo and @fecha_maxima
 group by p.Name
 order by count(p.ProductID) desc
end

exec SP_RetornarProductos