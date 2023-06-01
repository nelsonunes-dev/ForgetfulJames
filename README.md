# Brief

Build an application that allows a user to login and maintain a shopping list.

# Requirements

## Minimal
<ol>
	<li>[ ] The API must have OAuth2 login and demonstrate the workflow.</li>
	<li>[X] An endpoint to perform a CRUD operation on shopping items./</li>
	<li>[ ] Shopping list items belong only to the creating user:</li>
		<ol>
			<li>[ ] Only that user can can view them.</li>
			<li>[ ] Only that user can perform actions on them.</li>
		</ol>
	<li>Shopping list items can have attached images:</li>
		<ol>
			<li>[ ] Users must be able to upload images to attach to items.</li>
		</ol>
</ol>

## Optional
<ol>
	<li>[X] Swagger/Swashbuckle implemented to explore the API.</li>
</ol>

## Additional
<ol>
	<li>[X] Data must be stored in a database.</li>
	<li>[ ] Use of any of the following OAuth2 providers is acceptable:</li>
		<ol>
			<li>[X] Google.</li>
			<li>[X] Microsoft.</li>
			<li>[X] Facebook.</li>
			<li>[X] Okta.</li>
			<li>[ ] Steam.</li>
			<li>[ ] Blizzard.</li>
		</ol>
	<li>The project needs to be run in a containerized environment, including:</li>
		<ol>
			<li>[X] The WebAPI.</li>
			<li>[X] MS SQL Server.</li>
			<li>[ ] Minio.</li>
		</ol>
</ol>
