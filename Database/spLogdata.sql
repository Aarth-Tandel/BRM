alter procedure [BRM].[spLogs]
	@RowCount int,
	@RowFrom int
As
begin
	select logs.ID,application.Application,Release.Release,Changes.Changes, Environment.Environment,Server.Server,UserDetails.Username,logs.completedate,logs.Status
	from ((((((
	--(select * from brm.logs where logs.ID between (@RowFrom) and (@RowCount + @RowFrom) )logs
	(select * from brm.logs)logs
	inner join brm.application as application on logs.application_id = application.ID)
	inner join brm.release as release on logs.release_ID = release.ID)
	Inner join BRM.changes changes on logs.change_ID = changes.ID)
	Inner join BRM.environment environment on logs.environment_ID = environment.ID)
	Inner join BRM.Server Server on logs.Server_ID = Server.ID)
	Inner join BRM.userdetails userdetails on logs.users_ID = userdetails.ID)
	order by logs.id desc;
End
GO

