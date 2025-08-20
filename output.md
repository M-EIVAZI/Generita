## Tree for Generita
```
├── .dockerignore
├── .editorconfig
├── .github/
│   └── workflows/
├── .gitignore
├── Generita.sln
├── README.md
└── src/
    ├── Generita.Api/
    │   ├── appsettings.Development.json
    │   ├── appsettings.json
    │   ├── Controllers/
    │   │   ├── ApiController.cs
    │   │   ├── AudioController.cs
    │   │   ├── AuthController.cs
    │   │   ├── BooksController.cs
    │   │   ├── HomeController.cs
    │   │   └── UsersController.cs
    │   ├── Dockerfile
    │   ├── FakeDataGenerator.cs
    │   ├── Generita.Api.csproj
    │   ├── Generita.Api.http
    │   ├── Program.cs
    │   └── Properties/
    │       └── launchSettings.json
    ├── Generita.Application/
    │   ├── Audios/
    │   │   ├── Commands/
    │   │   └── Queries/
    │   │       ├── GetEntityAudioTags/
    │   │       │   ├── GetEntityAudioHandler.cs
    │   │       │   ├── GetEntityAudioQuery.cs
    │   │       │   └── GetEntityAudioValidator.cs
    │   │       └── GetParagraphAudioTags/
    │   │           ├── AudioTagsRequest.cs
    │   │           ├── GetAudioTagsHandler.cs
    │   │           ├── GetAudioTagsQuery.cs
    │   │           └── GetAudioTagValidator.cs
    │   ├── Authentication/
    │   │   ├── Login/
    │   │   │   ├── LoginCommand.cs
    │   │   │   ├── LoginHandler.cs
    │   │   │   └── LoginResponse.cs
    │   │   ├── Me/
    │   │   │   ├── MeCommand.cs
    │   │   │   ├── MeHandler.cs
    │   │   │   ├── MeResponse.cs
    │   │   │   └── MeResponseSubscription.cs
    │   │   ├── Refresh/
    │   │   │   ├── RefreshCommand.cs
    │   │   │   ├── RefreshHandler.cs
    │   │   │   ├── RefreshRequest.cs
    │   │   │   └── RefreshResponse.cs
    │   │   └── Register/
    │   │       ├── RegisterCommand.cs
    │   │       ├── RegisterCommandValidator.cs
    │   │       └── RegisterHandler.cs
    │   ├── Books/
    │   │   ├── Commands/
    │   │   │   ├── AddBook/
    │   │   │   │   ├── AddBookCommand.cs
    │   │   │   │   └── AddBookHandler.cs
    │   │   │   ├── RemoveBook/
    │   │   │   │   ├── RemoveBookCommand.cs
    │   │   │   │   └── RemoveBookHandler.cs
    │   │   │   └── UpdateBook/
    │   │   │       ├── UpdateBookCommand.cs
    │   │   │       └── UpdateBookHandler.cs
    │   │   └── Queries/
    │   │       ├── GetBookById/
    │   │       │   ├── GetBookByIdHandler.cs
    │   │       │   └── GetBookByIdQuery.cs
    │   │       ├── GetBookContent/
    │   │       │   ├── BookConentResponse.cs
    │   │       │   ├── GetBookByContentHandler.cs
    │   │       │   ├── GetBookByContentQuery.cs
    │   │       │   └── GetBookContentValidator.cs
    │   │       └── SearchBook/
    │   │           ├── SearchBookHandler.cs
    │   │           ├── SearchBookQuery.cs
    │   │           ├── SearchBookRequest.cs
    │   │           ├── SearchBookValidator.cs
    │   │           ├── SearchMode.cs
    │   │           └── SearchResultOrder.cs
    │   ├── Common/
    │   │   ├── Behaviors/
    │   │   │   └── ValidationPipelineBehavior.cs
    │   │   ├── Dtos/
    │   │   │   ├── AddBookDto.cs
    │   │   │   ├── AddTolibraryControllerDto.cs
    │   │   │   ├── AudioTagsDto.cs
    │   │   │   ├── AudioTagsResponse.cs
    │   │   │   ├── BannerBookDto.cs
    │   │   │   ├── EntitiesDto.cs
    │   │   │   ├── EntityDto.cs
    │   │   │   ├── GetAudioTagsDto.cs
    │   │   │   ├── GetBookDto.cs
    │   │   │   ├── HomeBookDto.cs
    │   │   │   ├── LoginDto.cs
    │   │   │   ├── ParagraphDto.cs
    │   │   │   ├── RefreshDto.cs
    │   │   │   ├── RegisterDto.cs
    │   │   │   ├── RegisterResponse.cs
    │   │   │   └── SearchBookDto.cs
    │   │   ├── Interfaces/
    │   │   │   ├── IPasswordHasher.cs
    │   │   │   ├── ITokenGenerator.cs
    │   │   │   └── Repository/
    │   │   │       ├── IAuthorRepository.cs
    │   │   │       ├── IBookCategoryRepository.cs
    │   │   │       ├── IBookRepository.cs
    │   │   │       ├── IEntityRepository.cs
    │   │   │       ├── IGenericRepository.cs
    │   │   │       ├── IParagraphRepository.cs
    │   │   │       ├── IPlansRepository.cs
    │   │   │       ├── IRefreshTokenRepository.cs
    │   │   │       ├── ISongCategoryRepository.cs
    │   │   │       ├── ISongRepository.cs
    │   │   │       ├── ITransactionsRepository.cs
    │   │   │       └── IUserRepository.cs
    │   │   └── Messaging/
    │   │       ├── ICommand.cs
    │   │       ├── ICommandHandler.cs
    │   │       ├── IQuery.cs
    │   │       └── IQueryHandler.cs
    │   ├── DependencyInjection.cs
    │   ├── Generita.Application.csproj
    │   ├── Home/
    │   │   └── Query/
    │   │       ├── HomeHandler.cs
    │   │       ├── HomeQuery.cs
    │   │       └── HomeResponse.cs
    │   ├── Transactions/
    │   └── Users/
    │       ├── Commands/
    │       │   ├── AddBookToLibrary/
    │       │   │   ├── AddUserLibrarayResponse.cs
    │       │   │   ├── AddUserLibraryHandler.cs
    │       │   │   ├── AddUserLibraryQuery.cs
    │       │   │   └── AddUserLibraryRequest.cs
    │       │   └── RemvoeBookFromLibrary/
    │       │       ├── RemoveBookFromLibraryHandler.cs
    │       │       └── RemoveBookFromLibraryQuery.cs
    │       └── Queries/
    │           └── GetUserLibrary/
    ├── Generita.Domain/
    │   ├── Common/
    │   │   ├── Abstractions/
    │   │   │   ├── AggregateRoot.cs
    │   │   │   └── BaseEntity.cs
    │   │   ├── Enums/
    │   │   │   ├── AgeClasses.cs
    │   │   │   ├── BookAccess.cs
    │   │   │   ├── MusicSense.cs
    │   │   │   ├── OwnerShip.cs
    │   │   │   └── States.cs
    │   │   ├── Interfaces/
    │   │   │   ├── IDomainEvent.cs
    │   │   │   └── IUnitOfWork.cs
    │   │   └── ValueObjects/
    │   │       └── Name.cs
    │   ├── Generita.Domain.csproj
    │   └── Models/
    │       ├── Author.cs
    │       ├── Book.cs
    │       ├── BookCategory.cs
    │       ├── BookLikes.cs
    │       ├── BookSong.cs
    │       ├── Diagram.mmd
    │       ├── Entity.cs
    │       ├── Paragraph.cs
    │       ├── Plans.cs
    │       ├── RefreshTokens.cs
    │       ├── SongCategory.cs
    │       ├── Songs.cs
    │       ├── Transactions.cs
    │       ├── User.cs
    │       ├── UserBook.cs
    │       ├── UserPlan.cs
    │       └── Views.cs
    └── Generita.Infrustructure/
        ├── Authentication/
        │   ├── PasswordHasher.cs
        │   └── TokenGenerator/
        │       ├── JwtSettings.cs
        │       └── TokenGenerator.cs
        ├── DependencyInjection.cs
        ├── Generita.Infrustructure.csproj
        ├── Migrations/
        │   ├── 20250802183636_Init.cs
        │   ├── 20250802183636_Init.Designer.cs
        │   ├── 20250803134904_AddRefreshTokenTable.cs
        │   ├── 20250803134904_AddRefreshTokenTable.Designer.cs
        │   ├── 20250803180541_ChangePasswordLimit.cs
        │   ├── 20250803180541_ChangePasswordLimit.Designer.cs
        │   ├── 20250803221827_adduserbooks.cs
        │   ├── 20250803221827_adduserbooks.Designer.cs
        │   ├── 20250805203313_AddParagraphTableEditEntityTable.cs
        │   ├── 20250805203313_AddParagraphTableEditEntityTable.Designer.cs
        │   ├── 20250807175148_EditUserBookTable.cs
        │   ├── 20250807175148_EditUserBookTable.Designer.cs
        │   ├── 20250810114541_removesongcategory.cs
        │   ├── 20250810114541_removesongcategory.Designer.cs
        │   └── GeneritaDbContextModelSnapshot.cs
        └── Persistance/
            ├── Configurations/
            │   ├── AuthorConfig.cs
            │   ├── BookCategoryConfig.cs
            │   ├── BookConfig.cs
            │   ├── BookLikesConfig.cs
            │   ├── EntityConfig.cs
            │   ├── ParagraphConfig.cs
            │   ├── PlansConfig.cs
            │   ├── RefreshTokenConfig.cs
            │   ├── SongCategoryConfig.cs
            │   ├── SongConfig.cs
            │   ├── TransactionsConfig.cs
            │   ├── UserBookConfig.cs
            │   ├── UserConfig.cs
            │   └── ViewsConfig.cs
            ├── GeneritaDbContext.cs
            ├── Repositories/
            │   ├── AuthorRepository.cs
            │   ├── BookCategoryRepository.cs
            │   ├── BookRepository.cs
            │   ├── EntityRepository.cs
            │   ├── ParagraphRepository.cs
            │   ├── PlansRepository.cs
            │   ├── RefreshTokenRepository.cs
            │   ├── SongCategoryRepository.cs
            │   ├── SongsRepository.cs
            │   ├── TransactionRepository.cs
            │   └── UserRepository.cs
            └── UnitOfWork.cs
```

## File: .dockerignore
```
**/.classpath
**/.dockerignore
**/.env
**/.git
**/.gitignore
**/.project
**/.settings
**/.toolstarget
**/.vs
**/.vscode
**/*.*proj.user
**/*.dbmdl
**/*.jfm
**/azds.yaml
**/bin
**/charts
**/docker-compose*
**/Dockerfile*
**/node_modules
**/npm-debug.log
**/obj
**/secrets.dev.yaml
**/values.dev.yaml
LICENSE
README.md
!**/.gitignore
!.git/HEAD
!.git/config
!.git/packed-refs
!.git/refs/heads/**
```
## File: .editorconfig
```
root = true

# All files
[*]
indent_style = space

# Xml files
[*.xml]
indent_size = 2

# C# files
[*.cs]

#### Core EditorConfig Options ####

# Indentation and spacing
indent_size = 4
tab_width = 4

# New line preferences
end_of_line = crlf
insert_final_newline = false

#### .NET Coding Conventions ####
[*.{cs,vb}]

# Organize usings
dotnet_separate_import_directive_groups = true
dotnet_sort_system_directives_first = true
file_header_template = unset

# this. and Me. preferences
dotnet_style_qualification_for_event = false:silent
dotnet_style_qualification_for_field = false:silent
dotnet_style_qualification_for_method = false:silent
dotnet_style_qualification_for_property = false:silent

# Language keywords vs BCL types preferences
dotnet_style_predefined_type_for_locals_parameters_members = true:silent
dotnet_style_predefined_type_for_member_access = true:silent

# Parentheses preferences
dotnet_style_parentheses_in_arithmetic_binary_operators = always_for_clarity:silent
dotnet_style_parentheses_in_other_binary_operators = always_for_clarity:silent
dotnet_style_parentheses_in_other_operators = never_if_unnecessary:silent
dotnet_style_parentheses_in_relational_binary_operators = always_for_clarity:silent

# Modifier preferences
dotnet_style_require_accessibility_modifiers = for_non_interface_members:silent

# Expression-level preferences
dotnet_style_coalesce_expression = true:suggestion
dotnet_style_collection_initializer = true:suggestion
dotnet_style_explicit_tuple_names = true:suggestion
dotnet_style_null_propagation = true:suggestion
dotnet_style_object_initializer = true:suggestion
dotnet_style_operator_placement_when_wrapping = beginning_of_line
dotnet_style_prefer_auto_properties = true:suggestion
dotnet_style_prefer_compound_assignment = true:suggestion
dotnet_style_prefer_conditional_expression_over_assignment = true:suggestion
dotnet_style_prefer_conditional_expression_over_return = true:suggestion
dotnet_style_prefer_inferred_anonymous_type_member_names = true:suggestion
dotnet_style_prefer_inferred_tuple_names = true:suggestion
dotnet_style_prefer_is_null_check_over_reference_equality_method = true:suggestion
dotnet_style_prefer_simplified_boolean_expressions = true:suggestion
dotnet_style_prefer_simplified_interpolation = true:suggestion

# Field preferences
dotnet_style_readonly_field = true:warning

# Parameter preferences
dotnet_code_quality_unused_parameters = all:suggestion

# Suppression preferences
dotnet_remove_unnecessary_suppression_exclusions = none

#### C# Coding Conventions ####
[*.cs]

# var preferences
csharp_style_var_elsewhere = false:silent
csharp_style_var_for_built_in_types = false:silent
csharp_style_var_when_type_is_apparent = false:silent

# Expression-bodied members
csharp_style_expression_bodied_accessors = true:silent
csharp_style_expression_bodied_constructors = false:silent
csharp_style_expression_bodied_indexers = true:silent
csharp_style_expression_bodied_lambdas = true:suggestion
csharp_style_expression_bodied_local_functions = false:silent
csharp_style_expression_bodied_methods = false:silent
csharp_style_expression_bodied_operators = false:silent
csharp_style_expression_bodied_properties = true:silent

# Pattern matching preferences
csharp_style_pattern_matching_over_as_with_null_check = true:suggestion
csharp_style_pattern_matching_over_is_with_cast_check = true:suggestion
csharp_style_prefer_not_pattern = true:suggestion
csharp_style_prefer_pattern_matching = true:silent
csharp_style_prefer_switch_expression = true:suggestion

# Null-checking preferences
csharp_style_conditional_delegate_call = true:suggestion

# Modifier preferences
csharp_prefer_static_local_function = true:warning
csharp_preferred_modifier_order = public,private,protected,internal,static,extern,new,virtual,abstract,sealed,override,readonly,unsafe,volatile,async:silent

# Code-block preferences
csharp_prefer_braces = true:silent
csharp_prefer_simple_using_statement = true:suggestion

# Expression-level preferences
csharp_prefer_simple_default_expression = true:suggestion
csharp_style_deconstructed_variable_declaration = true:suggestion
csharp_style_inlined_variable_declaration = true:suggestion
csharp_style_pattern_local_over_anonymous_function = true:suggestion
csharp_style_prefer_index_operator = true:suggestion
csharp_style_prefer_range_operator = true:suggestion
csharp_style_throw_expression = true:suggestion
csharp_style_unused_value_assignment_preference = discard_variable:suggestion
csharp_style_unused_value_expression_statement_preference = discard_variable:silent

# 'using' directive preferences
csharp_using_directive_placement = outside_namespace:silent

#### C# Formatting Rules ####

# New line preferences
csharp_new_line_before_catch = true
csharp_new_line_before_else = true
csharp_new_line_before_finally = true
csharp_new_line_before_members_in_anonymous_types = true
csharp_new_line_before_members_in_object_initializers = true
csharp_new_line_before_open_brace = all
csharp_new_line_between_query_expression_clauses = true

# Indentation preferences
csharp_indent_block_contents = true
csharp_indent_braces = false
csharp_indent_case_contents = true
csharp_indent_case_contents_when_block = true
csharp_indent_labels = one_less_than_current
csharp_indent_switch_labels = true

# Space preferences
csharp_space_after_cast = false
csharp_space_after_colon_in_inheritance_clause = true
csharp_space_after_comma = true
csharp_space_after_dot = false
csharp_space_after_keywords_in_control_flow_statements = true
csharp_space_after_semicolon_in_for_statement = true
csharp_space_around_binary_operators = before_and_after
csharp_space_around_declaration_statements = false
csharp_space_before_colon_in_inheritance_clause = true
csharp_space_before_comma = false
csharp_space_before_dot = false
csharp_space_before_open_square_brackets = false
csharp_space_before_semicolon_in_for_statement = false
csharp_space_between_empty_square_brackets = false
csharp_space_between_method_call_empty_parameter_list_parentheses = false
csharp_space_between_method_call_name_and_opening_parenthesis = false
csharp_space_between_method_call_parameter_list_parentheses = false
csharp_space_between_method_declaration_empty_parameter_list_parentheses = false
csharp_space_between_method_declaration_name_and_open_parenthesis = false
csharp_space_between_method_declaration_parameter_list_parentheses = false
csharp_space_between_parentheses = false
csharp_space_between_square_brackets = false

# Wrapping preferences
csharp_preserve_single_line_blocks = true
csharp_preserve_single_line_statements = true
csharp_style_namespace_declarations = block_scoped:silent
csharp_style_prefer_method_group_conversion = true:silent
csharp_style_prefer_top_level_statements = true:silent
csharp_style_prefer_primary_constructors = true:suggestion

#### Naming styles ####
[*.{cs,vb}]

# Naming rules

dotnet_naming_rule.types_and_namespaces_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.types_and_namespaces_should_be_pascalcase.symbols = types_and_namespaces
dotnet_naming_rule.types_and_namespaces_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.interfaces_should_be_ipascalcase.severity = suggestion
dotnet_naming_rule.interfaces_should_be_ipascalcase.symbols = interfaces
dotnet_naming_rule.interfaces_should_be_ipascalcase.style = ipascalcase

dotnet_naming_rule.type_parameters_should_be_tpascalcase.severity = suggestion
dotnet_naming_rule.type_parameters_should_be_tpascalcase.symbols = type_parameters
dotnet_naming_rule.type_parameters_should_be_tpascalcase.style = tpascalcase

dotnet_naming_rule.methods_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.methods_should_be_pascalcase.symbols = methods
dotnet_naming_rule.methods_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.properties_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.properties_should_be_pascalcase.symbols = properties
dotnet_naming_rule.properties_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.events_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.events_should_be_pascalcase.symbols = events
dotnet_naming_rule.events_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.local_variables_should_be_camelcase.severity = suggestion
dotnet_naming_rule.local_variables_should_be_camelcase.symbols = local_variables
dotnet_naming_rule.local_variables_should_be_camelcase.style = camelcase

dotnet_naming_rule.local_constants_should_be_camelcase.severity = suggestion
dotnet_naming_rule.local_constants_should_be_camelcase.symbols = local_constants
dotnet_naming_rule.local_constants_should_be_camelcase.style = camelcase

dotnet_naming_rule.parameters_should_be_camelcase.severity = suggestion
dotnet_naming_rule.parameters_should_be_camelcase.symbols = parameters
dotnet_naming_rule.parameters_should_be_camelcase.style = camelcase

dotnet_naming_rule.public_fields_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.public_fields_should_be_pascalcase.symbols = public_fields
dotnet_naming_rule.public_fields_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.private_fields_should_be__camelcase.severity = suggestion
dotnet_naming_rule.private_fields_should_be__camelcase.symbols = private_fields
dotnet_naming_rule.private_fields_should_be__camelcase.style = _camelcase

dotnet_naming_rule.private_static_fields_should_be_s_camelcase.severity = suggestion
dotnet_naming_rule.private_static_fields_should_be_s_camelcase.symbols = private_static_fields
dotnet_naming_rule.private_static_fields_should_be_s_camelcase.style = s_camelcase

dotnet_naming_rule.public_constant_fields_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.public_constant_fields_should_be_pascalcase.symbols = public_constant_fields
dotnet_naming_rule.public_constant_fields_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.private_constant_fields_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.private_constant_fields_should_be_pascalcase.symbols = private_constant_fields
dotnet_naming_rule.private_constant_fields_should_be_pascalcase.style = _camelcase

dotnet_naming_rule.public_static_readonly_fields_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.public_static_readonly_fields_should_be_pascalcase.symbols = public_static_readonly_fields
dotnet_naming_rule.public_static_readonly_fields_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.private_static_readonly_fields_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.private_static_readonly_fields_should_be_pascalcase.symbols = private_static_readonly_fields
dotnet_naming_rule.private_static_readonly_fields_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.enums_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.enums_should_be_pascalcase.symbols = enums
dotnet_naming_rule.enums_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.local_functions_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.local_functions_should_be_pascalcase.symbols = local_functions
dotnet_naming_rule.local_functions_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.non_field_members_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.non_field_members_should_be_pascalcase.symbols = non_field_members
dotnet_naming_rule.non_field_members_should_be_pascalcase.style = pascalcase

# Symbol specifications

dotnet_naming_symbols.interfaces.applicable_kinds = interface
dotnet_naming_symbols.interfaces.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected
dotnet_naming_symbols.interfaces.required_modifiers = 

dotnet_naming_symbols.enums.applicable_kinds = enum
dotnet_naming_symbols.enums.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected
dotnet_naming_symbols.enums.required_modifiers = 

dotnet_naming_symbols.events.applicable_kinds = event
dotnet_naming_symbols.events.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected
dotnet_naming_symbols.events.required_modifiers = 

dotnet_naming_symbols.methods.applicable_kinds = method
dotnet_naming_symbols.methods.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected
dotnet_naming_symbols.methods.required_modifiers = 

dotnet_naming_symbols.properties.applicable_kinds = property
dotnet_naming_symbols.properties.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected
dotnet_naming_symbols.properties.required_modifiers = 

dotnet_naming_symbols.public_fields.applicable_kinds = field
dotnet_naming_symbols.public_fields.applicable_accessibilities = public, internal
dotnet_naming_symbols.public_fields.required_modifiers = 

dotnet_naming_symbols.private_fields.applicable_kinds = field
dotnet_naming_symbols.private_fields.applicable_accessibilities = private, protected, protected_internal, private_protected
dotnet_naming_symbols.private_fields.required_modifiers = 

dotnet_naming_symbols.private_static_fields.applicable_kinds = field
dotnet_naming_symbols.private_static_fields.applicable_accessibilities = private, protected, protected_internal, private_protected
dotnet_naming_symbols.private_static_fields.required_modifiers = static

dotnet_naming_symbols.types_and_namespaces.applicable_kinds = namespace, class, struct, interface, enum
dotnet_naming_symbols.types_and_namespaces.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected
dotnet_naming_symbols.types_and_namespaces.required_modifiers = 

dotnet_naming_symbols.non_field_members.applicable_kinds = property, event, method
dotnet_naming_symbols.non_field_members.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected
dotnet_naming_symbols.non_field_members.required_modifiers = 

dotnet_naming_symbols.type_parameters.applicable_kinds = namespace
dotnet_naming_symbols.type_parameters.applicable_accessibilities = *
dotnet_naming_symbols.type_parameters.required_modifiers = 

dotnet_naming_symbols.private_constant_fields.applicable_kinds = field
dotnet_naming_symbols.private_constant_fields.applicable_accessibilities = private, protected, protected_internal, private_protected
dotnet_naming_symbols.private_constant_fields.required_modifiers = const

dotnet_naming_symbols.local_variables.applicable_kinds = local
dotnet_naming_symbols.local_variables.applicable_accessibilities = local
dotnet_naming_symbols.local_variables.required_modifiers = 

dotnet_naming_symbols.local_constants.applicable_kinds = local
dotnet_naming_symbols.local_constants.applicable_accessibilities = local
dotnet_naming_symbols.local_constants.required_modifiers = const

dotnet_naming_symbols.parameters.applicable_kinds = parameter
dotnet_naming_symbols.parameters.applicable_accessibilities = *
dotnet_naming_symbols.parameters.required_modifiers = 

dotnet_naming_symbols.public_constant_fields.applicable_kinds = field
dotnet_naming_symbols.public_constant_fields.applicable_accessibilities = public, internal
dotnet_naming_symbols.public_constant_fields.required_modifiers = const

dotnet_naming_symbols.public_static_readonly_fields.applicable_kinds = field
dotnet_naming_symbols.public_static_readonly_fields.applicable_accessibilities = public, internal
dotnet_naming_symbols.public_static_readonly_fields.required_modifiers = readonly, static

dotnet_naming_symbols.private_static_readonly_fields.applicable_kinds = field
dotnet_naming_symbols.private_static_readonly_fields.applicable_accessibilities = private, protected, protected_internal, private_protected
dotnet_naming_symbols.private_static_readonly_fields.required_modifiers = readonly, static

dotnet_naming_symbols.local_functions.applicable_kinds = local_function
dotnet_naming_symbols.local_functions.applicable_accessibilities = *
dotnet_naming_symbols.local_functions.required_modifiers = 

# Naming styles

dotnet_naming_style.pascalcase.required_prefix = 
dotnet_naming_style.pascalcase.required_suffix = 
dotnet_naming_style.pascalcase.word_separator = 
dotnet_naming_style.pascalcase.capitalization = pascal_case

dotnet_naming_style.ipascalcase.required_prefix = I
dotnet_naming_style.ipascalcase.required_suffix = 
dotnet_naming_style.ipascalcase.word_separator = 
dotnet_naming_style.ipascalcase.capitalization = pascal_case

dotnet_naming_style.tpascalcase.required_prefix = T
dotnet_naming_style.tpascalcase.required_suffix = 
dotnet_naming_style.tpascalcase.word_separator = 
dotnet_naming_style.tpascalcase.capitalization = pascal_case

dotnet_naming_style._camelcase.required_prefix = _
dotnet_naming_style._camelcase.required_suffix = 
dotnet_naming_style._camelcase.word_separator = 
dotnet_naming_style._camelcase.capitalization = camel_case

dotnet_naming_style.camelcase.required_prefix = 
dotnet_naming_style.camelcase.required_suffix = 
dotnet_naming_style.camelcase.word_separator = 
dotnet_naming_style.camelcase.capitalization = camel_case

dotnet_naming_style.s_camelcase.required_prefix = s_
dotnet_naming_style.s_camelcase.required_suffix = 
dotnet_naming_style.s_camelcase.word_separator = 
dotnet_naming_style.s_camelcase.capitalization = camel_case
tab_width = 4
indent_size = 4
end_of_line = crlf
```
## File: .gitignore
```
## Ignore Visual Studio temporary files, build results, and
## files generated by popular Visual Studio add-ons.
##
## Get latest from `dotnet new gitignore`

# dotenv files
.env

# User-specific files
*.rsuser
*.suo
*.user
*.userosscache
*.sln.docstates

# User-specific files (MonoDevelop/Xamarin Studio)
*.userprefs

# Mono auto generated files
mono_crash.*

# Build results
[Dd]ebug/
[Dd]ebugPublic/
[Rr]elease/
[Rr]eleases/
x64/
x86/
[Ww][Ii][Nn]32/
[Aa][Rr][Mm]/
[Aa][Rr][Mm]64/
bld/
[Bb]in/
[Oo]bj/
[Ll]og/
[Ll]ogs/

# Visual Studio 2015/2017 cache/options directory
.vs/
# Uncomment if you have tasks that create the project's static files in wwwroot
#wwwroot/

# Visual Studio 2017 auto generated files
Generated\ Files/

# MSTest test Results
[Tt]est[Rr]esult*/
[Bb]uild[Ll]og.*

# NUnit
*.VisualState.xml
TestResult.xml
nunit-*.xml

# Build Results of an ATL Project
[Dd]ebugPS/
[Rr]eleasePS/
dlldata.c

# Benchmark Results
BenchmarkDotNet.Artifacts/

# .NET
project.lock.json
project.fragment.lock.json
artifacts/

# Tye
.tye/

# ASP.NET Scaffolding
ScaffoldingReadMe.txt

# StyleCop
StyleCopReport.xml

# Files built by Visual Studio
*_i.c
*_p.c
*_h.h
*.ilk
*.meta
*.obj
*.iobj
*.pch
*.pdb
*.ipdb
*.pgc
*.pgd
*.rsp
*.sbr
*.tlb
*.tli
*.tlh
*.tmp
*.tmp_proj
*_wpftmp.csproj
*.log
*.tlog
*.vspscc
*.vssscc
.builds
*.pidb
*.svclog
*.scc

# Chutzpah Test files
_Chutzpah*

# Visual C++ cache files
ipch/
*.aps
*.ncb
*.opendb
*.opensdf
*.sdf
*.cachefile
*.VC.db
*.VC.VC.opendb

# Visual Studio profiler
*.psess
*.vsp
*.vspx
*.sap

# Visual Studio Trace Files
*.e2e

# TFS 2012 Local Workspace
$tf/

# Guidance Automation Toolkit
*.gpState

# ReSharper is a .NET coding add-in
_ReSharper*/
*.[Rr]e[Ss]harper
*.DotSettings.user

# TeamCity is a build add-in
_TeamCity*

# DotCover is a Code Coverage Tool
*.dotCover

# AxoCover is a Code Coverage Tool
.axoCover/*
!.axoCover/settings.json

# Coverlet is a free, cross platform Code Coverage Tool
coverage*.json
coverage*.xml
coverage*.info

# Visual Studio code coverage results
*.coverage
*.coveragexml

# NCrunch
_NCrunch_*
.*crunch*.local.xml
nCrunchTemp_*

# MightyMoose
*.mm.*
AutoTest.Net/

# Web workbench (sass)
.sass-cache/

# Installshield output folder
[Ee]xpress/

# DocProject is a documentation generator add-in
DocProject/buildhelp/
DocProject/Help/*.HxT
DocProject/Help/*.HxC
DocProject/Help/*.hhc
DocProject/Help/*.hhk
DocProject/Help/*.hhp
DocProject/Help/Html2
DocProject/Help/html

# Click-Once directory
publish/

# Publish Web Output
*.[Pp]ublish.xml
*.azurePubxml
# Note: Comment the next line if you want to checkin your web deploy settings,
# but database connection strings (with potential passwords) will be unencrypted
*.pubxml
*.publishproj

# Microsoft Azure Web App publish settings. Comment the next line if you want to
# checkin your Azure Web App publish settings, but sensitive information contained
# in these scripts will be unencrypted
PublishScripts/

# NuGet Packages
*.nupkg
# NuGet Symbol Packages
*.snupkg
# The packages folder can be ignored because of Package Restore
**/[Pp]ackages/*
# except build/, which is used as an MSBuild target.
!**/[Pp]ackages/build/
# Uncomment if necessary however generally it will be regenerated when needed
#!**/[Pp]ackages/repositories.config
# NuGet v3's project.json files produces more ignorable files
*.nuget.props
*.nuget.targets

# Microsoft Azure Build Output
csx/
*.build.csdef

# Microsoft Azure Emulator
ecf/
rcf/

# Windows Store app package directories and files
AppPackages/
BundleArtifacts/
Package.StoreAssociation.xml
_pkginfo.txt
*.appx
*.appxbundle
*.appxupload

# Visual Studio cache files
# files ending in .cache can be ignored
*.[Cc]ache
# but keep track of directories ending in .cache
!?*.[Cc]ache/

# Others
ClientBin/
~$*
*~
*.dbmdl
*.dbproj.schemaview
*.jfm
*.pfx
*.publishsettings
orleans.codegen.cs

# Including strong name files can present a security risk
# (https://github.com/github/gitignore/pull/2483#issue-259490424)
#*.snk

# Since there are multiple workflows, uncomment next line to ignore bower_components
# (https://github.com/github/gitignore/pull/1529#issuecomment-104372622)
#bower_components/

# RIA/Silverlight projects
Generated_Code/

# Backup & report files from converting an old project file
# to a newer Visual Studio version. Backup files are not needed,
# because we have git ;-)
_UpgradeReport_Files/
Backup*/
UpgradeLog*.XML
UpgradeLog*.htm
ServiceFabricBackup/
*.rptproj.bak

# SQL Server files
*.mdf
*.ldf
*.ndf

# Business Intelligence projects
*.rdl.data
*.bim.layout
*.bim_*.settings
*.rptproj.rsuser
*- [Bb]ackup.rdl
*- [Bb]ackup ([0-9]).rdl
*- [Bb]ackup ([0-9][0-9]).rdl

# Microsoft Fakes
FakesAssemblies/

# GhostDoc plugin setting file
*.GhostDoc.xml

# Node.js Tools for Visual Studio
.ntvs_analysis.dat
node_modules/

# Visual Studio 6 build log
*.plg

# Visual Studio 6 workspace options file
*.opt

# Visual Studio 6 auto-generated workspace file (contains which files were open etc.)
*.vbw

# Visual Studio 6 auto-generated project file (contains which files were open etc.)
*.vbp

# Visual Studio 6 workspace and project file (working project files containing files to include in project)
*.dsw
*.dsp

# Visual Studio 6 technical files
*.ncb
*.aps

# Visual Studio LightSwitch build output
**/*.HTMLClient/GeneratedArtifacts
**/*.DesktopClient/GeneratedArtifacts
**/*.DesktopClient/ModelManifest.xml
**/*.Server/GeneratedArtifacts
**/*.Server/ModelManifest.xml
_Pvt_Extensions

# Paket dependency manager
.paket/paket.exe
paket-files/

# FAKE - F# Make
.fake/

# CodeRush personal settings
.cr/personal

# Python Tools for Visual Studio (PTVS)
__pycache__/
*.pyc

# Cake - Uncomment if you are using it
# tools/**
# !tools/packages.config

# Tabs Studio
*.tss

# Telerik's JustMock configuration file
*.jmconfig

# BizTalk build output
*.btp.cs
*.btm.cs
*.odx.cs
*.xsd.cs

# OpenCover UI analysis results
OpenCover/

# Azure Stream Analytics local run output
ASALocalRun/

# MSBuild Binary and Structured Log
*.binlog

# NVidia Nsight GPU debugger configuration file
*.nvuser

# MFractors (Xamarin productivity tool) working folder
.mfractor/

# Local History for Visual Studio
.localhistory/

# Visual Studio History (VSHistory) files
.vshistory/

# BeatPulse healthcheck temp database
healthchecksdb

# Backup folder for Package Reference Convert tool in Visual Studio 2017
MigrationBackup/

# Ionide (cross platform F# VS Code tools) working folder
.ionide/

# Fody - auto-generated XML schema
FodyWeavers.xsd

# VS Code files for those working on multiple tools
.vscode/*
!.vscode/settings.json
!.vscode/tasks.json
!.vscode/launch.json
!.vscode/extensions.json
*.code-workspace

# Local History for Visual Studio Code
.history/

# Windows Installer files from build outputs
*.cab
*.msi
*.msix
*.msm
*.msp

# JetBrains Rider
*.sln.iml
.idea

##
## Visual studio for Mac
##


# globs
Makefile.in
*.userprefs
*.usertasks
config.make
config.status
aclocal.m4
install-sh
autom4te.cache/
*.tar.gz
tarballs/
test-results/

# Mac bundle stuff
*.dmg
*.app

# content below from: https://github.com/github/gitignore/blob/master/Global/macOS.gitignore
# General
.DS_Store
.AppleDouble
.LSOverride

# Icon must end with two \r
Icon


# Thumbnails
._*

# Files that might appear in the root of a volume
.DocumentRevisions-V100
.fseventsd
.Spotlight-V100
.TemporaryItems
.Trashes
.VolumeIcon.icns
.com.apple.timemachine.donotpresent

# Directories potentially created on remote AFP share
.AppleDB
.AppleDesktop
Network Trash Folder
Temporary Items
.apdisk

# content below from: https://github.com/github/gitignore/blob/master/Global/Windows.gitignore
# Windows thumbnail cache files
Thumbs.db
ehthumbs.db
ehthumbs_vista.db

# Dump file
*.stackdump

# Folder config file
[Dd]esktop.ini

# Recycle Bin used on file shares
$RECYCLE.BIN/

# Windows Installer files
*.cab
*.msi
*.msix
*.msm
*.msp

# Windows shortcuts
*.lnk

# Vim temporary swap files
*.swp
```
## File: Generita.sln
```
﻿
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.11.35312.102
MinimumVisualStudioVersion = 10.0.40219.1
Project("{2150E333-8FDC-42A3-9474-1A3956D46DE8}") = "src", "src", "{DA2DECCB-6829-41B0-BC18-C79928F83D44}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Generita.Domain", "src\Generita.Domain\Generita.Domain.csproj", "{5F2A2C5B-3A91-484E-AEFB-397F99A77B18}"
EndProject
Project("{2150E333-8FDC-42A3-9474-1A3956D46DE8}") = "Solution Items", "Solution Items", "{90745A64-5604-4C55-942C-A12FD2BC1693}"
	ProjectSection(SolutionItems) = preProject
		.editorconfig = .editorconfig
		.gitignore = .gitignore
	EndProjectSection
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Generita.Application", "src\Generita.Application\Generita.Application.csproj", "{C1B1B2DC-C465-43AF-B6F4-ABBE948CCFE4}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Generita.Infrustructure", "src\Generita.Infrustructure\Generita.Infrustructure.csproj", "{7601B534-E2B0-4494-B520-5CA9AD64ABDC}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "Generita.Api", "src\Generita.Api\Generita.Api.csproj", "{A9840CED-47DE-49D9-9CC2-3BFC42041DF0}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{5F2A2C5B-3A91-484E-AEFB-397F99A77B18}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{5F2A2C5B-3A91-484E-AEFB-397F99A77B18}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{5F2A2C5B-3A91-484E-AEFB-397F99A77B18}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{5F2A2C5B-3A91-484E-AEFB-397F99A77B18}.Release|Any CPU.Build.0 = Release|Any CPU
		{C1B1B2DC-C465-43AF-B6F4-ABBE948CCFE4}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{C1B1B2DC-C465-43AF-B6F4-ABBE948CCFE4}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{C1B1B2DC-C465-43AF-B6F4-ABBE948CCFE4}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{C1B1B2DC-C465-43AF-B6F4-ABBE948CCFE4}.Release|Any CPU.Build.0 = Release|Any CPU
		{7601B534-E2B0-4494-B520-5CA9AD64ABDC}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{7601B534-E2B0-4494-B520-5CA9AD64ABDC}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{7601B534-E2B0-4494-B520-5CA9AD64ABDC}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{7601B534-E2B0-4494-B520-5CA9AD64ABDC}.Release|Any CPU.Build.0 = Release|Any CPU
		{A9840CED-47DE-49D9-9CC2-3BFC42041DF0}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{A9840CED-47DE-49D9-9CC2-3BFC42041DF0}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{A9840CED-47DE-49D9-9CC2-3BFC42041DF0}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{A9840CED-47DE-49D9-9CC2-3BFC42041DF0}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(NestedProjects) = preSolution
		{5F2A2C5B-3A91-484E-AEFB-397F99A77B18} = {DA2DECCB-6829-41B0-BC18-C79928F83D44}
		{C1B1B2DC-C465-43AF-B6F4-ABBE948CCFE4} = {DA2DECCB-6829-41B0-BC18-C79928F83D44}
		{7601B534-E2B0-4494-B520-5CA9AD64ABDC} = {DA2DECCB-6829-41B0-BC18-C79928F83D44}
		{A9840CED-47DE-49D9-9CC2-3BFC42041DF0} = {DA2DECCB-6829-41B0-BC18-C79928F83D44}
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {321165EF-F083-46DE-8B63-E4BDBAF922A3}
	EndGlobalSection
EndGlobal
```
## File: README.md
```markdown
# Generita
```
## File: src\Generita.Api\appsettings.Development.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```
## File: src\Generita.Api\appsettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": ""
  },
  "JwtSettings": {
    "Secret": "very_long_secret_key_here_which_is_very_secure123123",
    "Issuer": "GeneritaApi",
    "Audience": "GeneritaClient",
    "ExpiryMinutes": 3
  },
  "AllowedHosts": "*"
}
```
## File: src\Generita.Api\Dockerfile
```
# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Generita.Api/Generita.Api.csproj", "src/Generita.Api/"]
RUN dotnet restore "./src/Generita.Api/Generita.Api.csproj"
COPY . .
WORKDIR "/src/src/Generita.Api"
RUN dotnet build "./Generita.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Generita.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Generita.Api.dll"]
```
## File: src\Generita.Api\FakeDataGenerator.cs
```csharp
﻿using Bogus;

using Generita.Application.Common.Interfaces;
using Generita.Domain.Common.Enums;
using Generita.Domain.Enums;
using Generita.Domain.Models;
using Generita.Domain.ValueObjects;
using Generita.Infrustructure.Persistance;

namespace Generita.Api
{
    public  static class FakeDataGenerator
    {
        public static void GenerateData(GeneritaDbContext dbContext,IPasswordHasher passwordHasher)
        {
            var categories = new[] { "Fiction", "Science", "History", "Philosophy", "Art", "Biography" };

            var bookCategoryFaker = new Faker<BookCategory>()
                .CustomInstantiator(f => new BookCategory(Guid.NewGuid()))
                .RuleFor(c => c.CategoryName, f => f.PickRandom(categories));
            var bookCategories = bookCategoryFaker.Generate(6); 
            var authorFaker = new Faker<Author>()
                .CustomInstantiator(f => new Author(Guid.NewGuid()))
                .RuleFor(a => a.Name, f => new Name(f.Person.FirstName, f.Person.LastName))
                .RuleFor(a => a.BirthDate, f => DateOnly.FromDateTime(f.Date.Past(80, DateTime.Now.AddYears(-18)))) 
                .RuleFor(a => a.age, (f, a) => DateTime.Now.Year - a.BirthDate.Year)
                .RuleFor(a => a.Nationality, f => f.Address.Country());
            var authors = authorFaker.Generate(10); 
            var bookAccessValues = Enum.GetValues(typeof(BookAccess)).Cast<BookAccess>().ToArray();

            var bookFaker = new Faker<Book>()
                .CustomInstantiator(f => new Book(Guid.NewGuid()))
                .RuleFor(b => b.Title, f => f.Commerce.ProductName())
                .RuleFor(b => b.PublishedDate, f => DateOnly.FromDateTime(f.Date.Past(50)))
                .RuleFor(b => b.AuthorId, f => f.PickRandom(authors).Id)       
                .RuleFor(b => b.CategoryId, f => f.PickRandom(bookCategories).Id)  
                .RuleFor(b => b.Synopsis, f => f.Lorem.Paragraph())
                .RuleFor(b => b.Cover, f => f.Image.PicsumUrl(200, 300))
                .RuleFor(b => b.Access, f => f.PickRandom(bookAccessValues))
                .RuleFor(b => b.FilePath, f => f.Internet.Url())
                .RuleFor(b => b.ImagePath, f => f.Internet.Url());
            var books = bookFaker.Generate(10);
            var planNames = new[] { "Basic", "Standard", "Premium", "Student", "Family" };

            var plansFaker = new Faker<Plans>()
                .CustomInstantiator(f => new Plans(Guid.NewGuid()))
                .RuleFor(p => p.Name, f => f.PickRandom(planNames))
                .RuleFor(p => p.Description, f => f.Lorem.Sentence(5, 8))
                .RuleFor(p => p.Price, f => f.Random.Int(100000, 300000)) 
                .RuleFor(p => p.Duration, f => f.Random.Int(7, 365));
            var plans=plansFaker.Generate(4);
            var hashedPasswordResult = passwordHasher.HashPassword("M@hdi1382");

            if (hashedPasswordResult.IsError)
            {
                throw new Exception("Password hashing failed: " + hashedPasswordResult.FirstError.Description);
            }

            var hashedPassword = hashedPasswordResult.Value;
            var userFaker = new Faker<User>()
                .CustomInstantiator(f => new User(Guid.NewGuid()))
                .RuleFor(u => u.Name, f => f.Person.FullName)
                .RuleFor(u => u.CreateAt, f => f.Date.Past(2).ToUniversalTime())
                .RuleFor(u => u.UpdateAt, (f, u) => u.CreateAt.AddMinutes(f.Random.Int(1, 1000)).ToUniversalTime())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Password, f => hashedPassword);
            var users = userFaker.Generate(5);

            var transactionStates = Enum.GetValues(typeof(States)).Cast<States>().ToArray();

            var transactionsFaker = new Faker<Transactions>()
                .CustomInstantiator(f => new Transactions(Guid.NewGuid()))
                .RuleFor(t => t.UserId, f => f.PickRandom(users).Id)    
                .RuleFor(t => t.PlanId, f => f.PickRandom(plans).Id)
                .RuleFor(t => t.CreateAt, f => f.Date.Recent(90).ToUniversalTime())
                .RuleFor(t => t.Price, (f, t) => plans.First(p => p.Id == t.PlanId).Price)
                .RuleFor(t => t.States, f => f.PickRandom(transactionStates));
            var transactions = transactionsFaker.Generate(50);


            var userbookfaker = new Faker<UserBook>()
                .CustomInstantiator(f => new UserBook(Guid.NewGuid()))
                .RuleFor(x => x.AddedAt, f => f.Date.Recent().ToUniversalTime())
                .RuleFor(x => x.UserId, f => f.PickRandom(users).Id)
                .RuleFor(x => x.BookId, f => f.PickRandom(books).Id);
            var userbooks = userbookfaker.Generate(20);

            var ownerShipValues = Enum.GetValues(typeof(OwnerShip)).Cast<OwnerShip>().ToArray();

            var songFaker = new Faker<Songs>()
                .CustomInstantiator(f => new Songs(Guid.NewGuid()))
                .RuleFor(s => s.Name, f => f.Lorem.Sentence(2, 3)) 
                .RuleFor(s => s.Duration, f => TimeSpan.FromSeconds(f.Random.Int(120, 360)))
                .RuleFor(s => s.CreateAt, f => f.Date.Past(2).ToUniversalTime())
                .RuleFor(s => s.UpdateAt, (f, s) => s.CreateAt.AddDays(f.Random.Int(0, 200)).ToUniversalTime())
                .RuleFor(s => s.FilePath, f => f.Internet.UrlWithPath("https", "example.com", $"songs/{f.Random.Guid()}.mp3"))
                .RuleFor(s => s.Owner, f => f.PickRandom(ownerShipValues));
            var songs = songFaker.Generate(10);
            var ageClassesValues = Enum.GetValues(typeof(AgeClasses)).Cast<AgeClasses>().ToArray();
            var musicSenseValues = Enum.GetValues(typeof(MusicSense)).Cast<MusicSense>().ToArray();

            var paragraphFaker = new Faker<Paragraph>()
                .CustomInstantiator(f => new Paragraph(Guid.NewGuid()))
                .RuleFor(p => p.Text, f => f.Lorem.Paragraph(3))
                .RuleFor(p => p.AgeClass, f => f.PickRandom(ageClassesValues))
                .RuleFor(p => p.MusicSense, f => f.PickRandom(musicSenseValues))
                .RuleFor(p => p.BookId, f => f.PickRandom(books).Id)
                .RuleFor(p => p.SongId, f => f.PickRandom(songs).Id);

            var paragraphs= paragraphFaker.Generate(20);
            var entityTypes = new[] { "Character", "Place", "Event", "Object", "Symbol" };

            var entityFaker = new Faker<Entity>()
                .CustomInstantiator(f => new Entity(Guid.NewGuid()))
                .RuleFor(e => e.type, f => f.PickRandom(entityTypes))
                .RuleFor(e => e.sample, f => f.Lorem.Sentence(3))
                .RuleFor(e => e.Position, f => f.Random.Int(1, 100))
                .RuleFor(e => e.ParagraphId, f => f.PickRandom(paragraphs).Id) 
                .RuleFor(e => e.MusicId, f => f.PickRandom(songs).Id);
            var entities = entityFaker.Generate(10);
            dbContext.BookCategory.AddRange(bookCategories);
            dbContext.Author.AddRange(authors);
            dbContext.SaveChanges();

            dbContext.Book.AddRange(books);
            dbContext.SaveChanges();

            dbContext.Plans.AddRange(plans);
            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();

            dbContext.Transactions.AddRange(transactions);
            dbContext.SaveChanges();

            dbContext.Songs.AddRange(songs);
            dbContext.SaveChanges();

            dbContext.Paragraph.AddRange(paragraphs);
            dbContext.SaveChanges();

            dbContext.Entity.AddRange(entities);
            dbContext.SaveChanges();

            dbContext.UsersBook.AddRange(userbooks);
            dbContext.SaveChanges();
            }






        }
    }
```
## File: src\Generita.Api\Generita.Api.csproj
```
﻿<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <UserSecretsId>bbcdf826-dfed-4ad3-ae68-cc4407eabd77</UserSecretsId>
    <DockerDefaultTargetOS>Linux</DockerDefaultTargetOS>
    <DockerfileContext>..\..</DockerfileContext>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Bogus" Version="35.6.3" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.7">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.VisualStudio.Azure.Containers.Tools.Targets" Version="1.21.0" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.4.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\Generita.Infrustructure\Generita.Infrustructure.csproj" />
  </ItemGroup>

</Project>
```
## File: src\Generita.Api\Generita.Api.http
```
@Generita.Api_HostAddress = http://localhost:5062

GET {{Generita.Api_HostAddress}}/weatherforecast/
Accept: application/json

###
```
## File: src\Generita.Api\Program.cs
```csharp
using Generita.Api;
using Generita.Application;
using Generita.Application.Common.Interfaces;
using Generita.Infrustructure;
using Generita.Infrustructure.Persistance;

using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true)
    .AddUserSecrets<Program>(optional: true)
    .AddEnvironmentVariables();
builder.Services.AddApplication();
builder.Services.AddInfrustructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Please enter JWT token like: Bearer {your token here}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<GeneritaDbContext>();
//    var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

//    FakeDataGenerator.GenerateData(dbContext, passwordHasher);
//}
app.Run();
```
## File: src\Generita.Application\DependencyInjection.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

namespace Generita.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });
            return services;
        }

    }
}
```
## File: src\Generita.Application\Generita.Application.csproj
```
﻿<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="ErrorOr" Version="2.0.1" />
    <PackageReference Include="FluentValidation" Version="12.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.7" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\Generita.Domain\Generita.Domain.csproj" />
  </ItemGroup>

  <ItemGroup>
    <Folder Include="Audios\Commands\" />
    <Folder Include="Transactions\" />
    <Folder Include="Users\Queries\GetUserLibrary\" />
  </ItemGroup>

</Project>
```
## File: src\Generita.Domain\Generita.Domain.csproj
```
﻿<Project Sdk="Microsoft.NET.Sdk">

    <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
        <ImplicitUsings>enable</ImplicitUsings>
        <Nullable>enable</Nullable>
    </PropertyGroup>

    <ItemGroup>
      <PackageReference Include="MediatR" Version="13.0.0" />
    </ItemGroup>

</Project>
```
## File: src\Generita.Infrustructure\DependencyInjection.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Common.Interfaces;
using Generita.Infrustructure.Authentication;
using Generita.Infrustructure.Authentication.TokenGenerator;
using Generita.Infrustructure.Persistance;
using Generita.Infrustructure.Persistance.Repositories;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Generita.Infrustructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrustructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<GeneritaDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<ISongRepository,SongsRepository>();
            services.AddScoped<IBookRepository,BookRepository>();
            services.AddScoped<IBookCategoryRepository,BookCategoryRepository>();
            services.AddScoped<ITransactionsRepository,TransactionRepository>();
            services.AddScoped<IPlansRepository,PlansRepository>();
            services.AddScoped<IParagraphRepository,ParagraphRepository>();
            services.AddScoped<IEntityRepository,EntityRepository>();
            services.AddScoped<IAuthorRepository,AuthorRepository>();
            services.AddScoped<IRefreshTokenRepository,RefreshTokenRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<ITokenGenerator, TokenGenerator>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"])),

                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }

    }
}
```
## File: src\Generita.Infrustructure\Generita.Infrustructure.csproj
```
﻿<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="BCrypt.Net-Next" Version="4.0.3" />
    <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="8.0.18" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.7" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.7">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.7">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="9.0.4" />
    <PackageReference Include="System.IdentityModel.Tokens.Jwt" Version="8.13.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\Generita.Application\Generita.Application.csproj" />
  </ItemGroup>

</Project>
```
## File: src\Generita.Infrustructure\Authentication\PasswordHasher.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces;

namespace Generita.Infrustructure.Authentication
{
    public partial class PasswordHasher : IPasswordHasher
    {
        private static readonly Regex PasswordRegex = StrongPasswordRegex();

        public ErrorOr<string> HashPassword(string password)
        {
            return !PasswordRegex.IsMatch(password)
                ? Error.Validation(description: "Password too weak")
                : BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public bool IsCorrectPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
        }

        [GeneratedRegex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", RegexOptions.Compiled)]
        private static partial Regex StrongPasswordRegex();
    }
}
```
## File: src\Generita.Infrustructure\Migrations\20250802183636_Init.cs
```csharp
﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name_firtName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Name_LastName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    Nationality = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SongCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    PublishedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Synopsis = table.Column<string>(type: "text", nullable: false),
                    Cover = table.Column<string>(type: "text", nullable: false),
                    Access = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_BookCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BookCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    Owner = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_SongCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SongCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    States = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Views",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    ViewAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Views", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Views_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Views_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookSongs",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "uuid", nullable: false),
                    SongsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSongs", x => new { x.BooksId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_BookSongs_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookSongs_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Descriptions = table.Column<string[]>(type: "text[]", nullable: false),
                    SongId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entity_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entity_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entity_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSongs_SongsId",
                table: "BookSongs",
                column: "SongsId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_AuthorId",
                table: "Entity",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_BookId",
                table: "Entity",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entity_SongId",
                table: "Entity",
                column: "SongId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_CategoryId",
                table: "Songs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PlanId",
                table: "Transactions",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Views_BookId",
                table: "Views",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Views_UserId",
                table: "Views",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookSongs");

            migrationBuilder.DropTable(
                name: "Entity");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Views");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SongCategories");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "BookCategories");
        }
    }
}
```
## File: src\Generita.Infrustructure\Migrations\20250802183636_Init.Designer.cs
```csharp
﻿// <auto-generated />
using System;
using Generita.Infrustructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    [DbContext(typeof(GeneritaDbContext))]
    [Migration("20250802183636_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookSongs", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SongsId")
                        .HasColumnType("uuid");

                    b.HasKey("BooksId", "SongsId");

                    b.HasIndex("SongsId");

                    b.ToTable("BookSongs");
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("age")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Authors", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Access")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("PublishedDate")
                        .HasColumnType("date");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.BookCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("BookCategories", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.PrimitiveCollection<string[]>("Descriptions")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SongId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.HasIndex("SongId")
                        .IsUnique();

                    b.ToTable("Entity", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Plans", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Plans", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.SongCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SongCategories", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Songs", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Transactions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uuid");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<string>("States")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Views", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ViewAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Views", (string)null);
                });

            modelBuilder.Entity("BookSongs", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Songs", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.OwnsOne("Generita.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("AuthorId")
                                .HasColumnType("uuid");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)");

                            b1.Property<string>("firtName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)");

                            b1.HasKey("AuthorId");

                            b1.ToTable("Authors");

                            b1.WithOwner()
                                .HasForeignKey("AuthorId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.HasOne("Generita.Domain.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.BookCategory", "BookCategory")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("BookCategory");
                });

            modelBuilder.Entity("Generita.Domain.Models.Entity", b =>
                {
                    b.HasOne("Generita.Domain.Models.Author", null)
                        .WithMany("Entities")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithOne("Entity")
                        .HasForeignKey("Generita.Domain.Models.Entity", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Songs", "Song")
                        .WithOne("Entity")
                        .HasForeignKey("Generita.Domain.Models.Entity", "SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.HasOne("Generita.Domain.Models.SongCategory", "Category")
                        .WithMany("Songs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Generita.Domain.Models.Transactions", b =>
                {
                    b.HasOne("Generita.Domain.Models.Plans", "Plan")
                        .WithMany("Transactions")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Views", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("Views")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("Views")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Entities");
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.Navigation("Entity")
                        .IsRequired();

                    b.Navigation("Views");
                });

            modelBuilder.Entity("Generita.Domain.Models.BookCategory", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Generita.Domain.Models.Plans", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Generita.Domain.Models.SongCategory", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.Navigation("Entity")
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.User", b =>
                {
                    b.Navigation("Transactions");

                    b.Navigation("Views");
                });
#pragma warning restore 612, 618
        }
    }
}
```
## File: src\Generita.Infrustructure\Migrations\20250803134904_AddRefreshTokenTable.cs
```csharp
﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExpiresOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Token",
                table: "RefreshTokens",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");
        }
    }
}
```
## File: src\Generita.Infrustructure\Migrations\20250803134904_AddRefreshTokenTable.Designer.cs
```csharp
﻿// <auto-generated />
using System;
using Generita.Infrustructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    [DbContext(typeof(GeneritaDbContext))]
    [Migration("20250803134904_AddRefreshTokenTable")]
    partial class AddRefreshTokenTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookSongs", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SongsId")
                        .HasColumnType("uuid");

                    b.HasKey("BooksId", "SongsId");

                    b.HasIndex("SongsId");

                    b.ToTable("BookSongs");
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("age")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Authors", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Access")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("PublishedDate")
                        .HasColumnType("date");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.BookCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("BookCategories", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.PrimitiveCollection<string[]>("Descriptions")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SongId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.HasIndex("SongId")
                        .IsUnique();

                    b.ToTable("Entity", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Plans", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Plans", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.RefreshTokens", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpiresOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.SongCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SongCategories", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Songs", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Transactions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uuid");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<string>("States")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Views", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ViewAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Views", (string)null);
                });

            modelBuilder.Entity("BookSongs", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Songs", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.OwnsOne("Generita.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("AuthorId")
                                .HasColumnType("uuid");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)");

                            b1.Property<string>("firtName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)");

                            b1.HasKey("AuthorId");

                            b1.ToTable("Authors");

                            b1.WithOwner()
                                .HasForeignKey("AuthorId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.HasOne("Generita.Domain.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.BookCategory", "BookCategory")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("BookCategory");
                });

            modelBuilder.Entity("Generita.Domain.Models.Entity", b =>
                {
                    b.HasOne("Generita.Domain.Models.Author", null)
                        .WithMany("Entities")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithOne("Entity")
                        .HasForeignKey("Generita.Domain.Models.Entity", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Songs", "Song")
                        .WithOne("Entity")
                        .HasForeignKey("Generita.Domain.Models.Entity", "SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("Generita.Domain.Models.RefreshTokens", b =>
                {
                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.HasOne("Generita.Domain.Models.SongCategory", "Category")
                        .WithMany("Songs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Generita.Domain.Models.Transactions", b =>
                {
                    b.HasOne("Generita.Domain.Models.Plans", "Plan")
                        .WithMany("Transactions")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Views", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("Views")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("Views")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Entities");
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.Navigation("Entity")
                        .IsRequired();

                    b.Navigation("Views");
                });

            modelBuilder.Entity("Generita.Domain.Models.BookCategory", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Generita.Domain.Models.Plans", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Generita.Domain.Models.SongCategory", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.Navigation("Entity")
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("Transactions");

                    b.Navigation("Views");
                });
#pragma warning restore 612, 618
        }
    }
}
```
## File: src\Generita.Infrustructure\Migrations\20250803180541_ChangePasswordLimit.cs
```csharp
﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangePasswordLimit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
```
## File: src\Generita.Infrustructure\Migrations\20250803180541_ChangePasswordLimit.Designer.cs
```csharp
﻿// <auto-generated />
using System;
using Generita.Infrustructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    [DbContext(typeof(GeneritaDbContext))]
    [Migration("20250803180541_ChangePasswordLimit")]
    partial class ChangePasswordLimit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookSongs", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SongsId")
                        .HasColumnType("uuid");

                    b.HasKey("BooksId", "SongsId");

                    b.HasIndex("SongsId");

                    b.ToTable("BookSongs");
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("age")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Authors", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Access")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("PublishedDate")
                        .HasColumnType("date");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.BookCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("BookCategories", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.PrimitiveCollection<string[]>("Descriptions")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SongId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.HasIndex("SongId")
                        .IsUnique();

                    b.ToTable("Entity", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Plans", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Plans", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.RefreshTokens", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpiresOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.SongCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SongCategories", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Songs", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Transactions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uuid");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<string>("States")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Views", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ViewAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Views", (string)null);
                });

            modelBuilder.Entity("BookSongs", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Songs", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.OwnsOne("Generita.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("AuthorId")
                                .HasColumnType("uuid");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)");

                            b1.Property<string>("firtName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)");

                            b1.HasKey("AuthorId");

                            b1.ToTable("Authors");

                            b1.WithOwner()
                                .HasForeignKey("AuthorId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.HasOne("Generita.Domain.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.BookCategory", "BookCategory")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("BookCategory");
                });

            modelBuilder.Entity("Generita.Domain.Models.Entity", b =>
                {
                    b.HasOne("Generita.Domain.Models.Author", null)
                        .WithMany("Entities")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithOne("Entity")
                        .HasForeignKey("Generita.Domain.Models.Entity", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Songs", "Song")
                        .WithOne("Entity")
                        .HasForeignKey("Generita.Domain.Models.Entity", "SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("Generita.Domain.Models.RefreshTokens", b =>
                {
                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.HasOne("Generita.Domain.Models.SongCategory", "Category")
                        .WithMany("Songs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Generita.Domain.Models.Transactions", b =>
                {
                    b.HasOne("Generita.Domain.Models.Plans", "Plan")
                        .WithMany("Transactions")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Views", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("Views")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("Views")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Entities");
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.Navigation("Entity")
                        .IsRequired();

                    b.Navigation("Views");
                });

            modelBuilder.Entity("Generita.Domain.Models.BookCategory", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Generita.Domain.Models.Plans", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Generita.Domain.Models.SongCategory", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.Navigation("Entity")
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("Transactions");

                    b.Navigation("Views");
                });
#pragma warning restore 612, 618
        }
    }
}
```
## File: src\Generita.Infrustructure\Migrations\20250803221827_adduserbooks.cs
```csharp
﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class adduserbooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookUser",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUser", x => new { x.BooksId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_BookUser_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookUser_UsersId",
                table: "BookUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookUser");
        }
    }
}
```
## File: src\Generita.Infrustructure\Migrations\20250803221827_adduserbooks.Designer.cs
```csharp
﻿// <auto-generated />
using System;
using Generita.Infrustructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    [DbContext(typeof(GeneritaDbContext))]
    [Migration("20250803221827_adduserbooks")]
    partial class adduserbooks
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookSongs", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SongsId")
                        .HasColumnType("uuid");

                    b.HasKey("BooksId", "SongsId");

                    b.HasIndex("SongsId");

                    b.ToTable("BookSongs");
                });

            modelBuilder.Entity("BookUser", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("BooksId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("BookUser");
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("age")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Authors", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Access")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("PublishedDate")
                        .HasColumnType("date");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.BookCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("BookCategories", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.PrimitiveCollection<string[]>("Descriptions")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SongId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.HasIndex("SongId")
                        .IsUnique();

                    b.ToTable("Entity", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Plans", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Plans", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.RefreshTokens", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpiresOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.SongCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SongCategories", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Songs", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Transactions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uuid");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<string>("States")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Views", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ViewAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Views", (string)null);
                });

            modelBuilder.Entity("BookSongs", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Songs", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookUser", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.OwnsOne("Generita.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("AuthorId")
                                .HasColumnType("uuid");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)");

                            b1.Property<string>("firtName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)");

                            b1.HasKey("AuthorId");

                            b1.ToTable("Authors");

                            b1.WithOwner()
                                .HasForeignKey("AuthorId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.HasOne("Generita.Domain.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.BookCategory", "BookCategory")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("BookCategory");
                });

            modelBuilder.Entity("Generita.Domain.Models.Entity", b =>
                {
                    b.HasOne("Generita.Domain.Models.Author", null)
                        .WithMany("Entities")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithOne("Entity")
                        .HasForeignKey("Generita.Domain.Models.Entity", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Songs", "Song")
                        .WithOne("Entity")
                        .HasForeignKey("Generita.Domain.Models.Entity", "SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("Generita.Domain.Models.RefreshTokens", b =>
                {
                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.HasOne("Generita.Domain.Models.SongCategory", "Category")
                        .WithMany("Songs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Generita.Domain.Models.Transactions", b =>
                {
                    b.HasOne("Generita.Domain.Models.Plans", "Plan")
                        .WithMany("Transactions")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Views", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("Views")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("Views")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Entities");
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.Navigation("Entity")
                        .IsRequired();

                    b.Navigation("Views");
                });

            modelBuilder.Entity("Generita.Domain.Models.BookCategory", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Generita.Domain.Models.Plans", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Generita.Domain.Models.SongCategory", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.Navigation("Entity")
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("Transactions");

                    b.Navigation("Views");
                });
#pragma warning restore 612, 618
        }
    }
}
```
## File: src\Generita.Infrustructure\Migrations\20250805203313_AddParagraphTableEditEntityTable.cs
```csharp
﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class AddParagraphTableEditEntityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Books_BookId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Songs_SongId",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_BookId",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_SongId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Descriptions",
                table: "Entity");

            migrationBuilder.RenameColumn(
                name: "SongId",
                table: "Entity",
                newName: "ParagraphId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Entity",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Entity",
                newName: "MusicId");

            migrationBuilder.Sql(@"
    ALTER TABLE ""Plans""
    ALTER COLUMN ""Duration"" TYPE integer
    USING EXTRACT(DAY FROM ""Duration"")::int;
");


            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Entity",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "sample",
                table: "Entity",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Paragraphs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    AgeClass = table.Column<string>(type: "text", nullable: false),
                    MusicSense = table.Column<string>(type: "text", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    SongId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paragraphs_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paragraphs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entity_MusicId",
                table: "Entity",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_ParagraphId",
                table: "Entity",
                column: "ParagraphId");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_BookId",
                table: "Paragraphs",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_SongId",
                table: "Paragraphs",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Paragraphs_ParagraphId",
                table: "Entity",
                column: "ParagraphId",
                principalTable: "Paragraphs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Songs_MusicId",
                table: "Entity",
                column: "MusicId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Paragraphs_ParagraphId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Songs_MusicId",
                table: "Entity");

            migrationBuilder.DropTable(
                name: "Paragraphs");

            migrationBuilder.DropIndex(
                name: "IX_Entity_MusicId",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_ParagraphId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "sample",
                table: "Entity");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Entity",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ParagraphId",
                table: "Entity",
                newName: "SongId");

            migrationBuilder.RenameColumn(
                name: "MusicId",
                table: "Entity",
                newName: "BookId");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Plans",
                type: "interval",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string[]>(
                name: "Descriptions",
                table: "Entity",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Entity_BookId",
                table: "Entity",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entity_SongId",
                table: "Entity",
                column: "SongId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Books_BookId",
                table: "Entity",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Songs_SongId",
                table: "Entity",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
```
## File: src\Generita.Infrustructure\Migrations\20250805203313_AddParagraphTableEditEntityTable.Designer.cs
```csharp
﻿// <auto-generated />
using System;
using Generita.Infrustructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    [DbContext(typeof(GeneritaDbContext))]
    [Migration("20250805203313_AddParagraphTableEditEntityTable")]
    partial class AddParagraphTableEditEntityTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookSongs", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SongsId")
                        .HasColumnType("uuid");

                    b.HasKey("BooksId", "SongsId");

                    b.HasIndex("SongsId");

                    b.ToTable("BookSongs");
                });

            modelBuilder.Entity("BookUser", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("BooksId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("BookUser");
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("age")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Authors", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Access")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("PublishedDate")
                        .HasColumnType("date");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.BookCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("BookCategories", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MusicId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ParagraphId")
                        .HasColumnType("uuid");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<string>("sample")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("MusicId");

                    b.HasIndex("ParagraphId");

                    b.ToTable("Entity", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Paragraph", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AgeClass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<string>("MusicSense")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SongId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("SongId");

                    b.ToTable("Paragraphs", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Plans", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Plans", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.RefreshTokens", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpiresOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.SongCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SongCategories", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Songs", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Transactions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uuid");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<string>("States")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Views", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ViewAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Views", (string)null);
                });

            modelBuilder.Entity("BookSongs", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Songs", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookUser", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.OwnsOne("Generita.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("AuthorId")
                                .HasColumnType("uuid");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)");

                            b1.Property<string>("firtName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)");

                            b1.HasKey("AuthorId");

                            b1.ToTable("Authors");

                            b1.WithOwner()
                                .HasForeignKey("AuthorId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.HasOne("Generita.Domain.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.BookCategory", "BookCategory")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("BookCategory");
                });

            modelBuilder.Entity("Generita.Domain.Models.Entity", b =>
                {
                    b.HasOne("Generita.Domain.Models.Author", null)
                        .WithMany("Entities")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Generita.Domain.Models.Songs", "Songs")
                        .WithMany("Entity")
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Paragraph", "Paragraph")
                        .WithMany("Entities")
                        .HasForeignKey("ParagraphId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paragraph");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Generita.Domain.Models.Paragraph", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("Paragraphs")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Songs", "Songs")
                        .WithMany("Paragraphs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Generita.Domain.Models.RefreshTokens", b =>
                {
                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.HasOne("Generita.Domain.Models.SongCategory", "Category")
                        .WithMany("Songs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Generita.Domain.Models.Transactions", b =>
                {
                    b.HasOne("Generita.Domain.Models.Plans", "Plan")
                        .WithMany("Transactions")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Views", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("Views")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("Views")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Entities");
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.Navigation("Paragraphs");

                    b.Navigation("Views");
                });

            modelBuilder.Entity("Generita.Domain.Models.BookCategory", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Generita.Domain.Models.Paragraph", b =>
                {
                    b.Navigation("Entities");
                });

            modelBuilder.Entity("Generita.Domain.Models.Plans", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Generita.Domain.Models.SongCategory", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.Navigation("Entity");

                    b.Navigation("Paragraphs");
                });

            modelBuilder.Entity("Generita.Domain.Models.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("Transactions");

                    b.Navigation("Views");
                });
#pragma warning restore 612, 618
        }
    }
}
```
## File: src\Generita.Infrustructure\Migrations\20250807175148_EditUserBookTable.cs
```csharp
﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class EditUserBookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookUser");

            migrationBuilder.CreateTable(
                name: "BookLikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookLikes_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBook",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBook_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBook_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookLikes_BookId",
                table: "BookLikes",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLikes_UserId_BookId",
                table: "BookLikes",
                columns: new[] { "UserId", "BookId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBook_BookId",
                table: "UserBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBook_UserId",
                table: "UserBook",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLikes");

            migrationBuilder.DropTable(
                name: "UserBook");

            migrationBuilder.CreateTable(
                name: "BookUser",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUser", x => new { x.BooksId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_BookUser_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookUser_UsersId",
                table: "BookUser",
                column: "UsersId");
        }
    }
}
```
## File: src\Generita.Infrustructure\Migrations\20250807175148_EditUserBookTable.Designer.cs
```csharp
﻿// <auto-generated />
using System;
using Generita.Infrustructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    [DbContext(typeof(GeneritaDbContext))]
    [Migration("20250807175148_EditUserBookTable")]
    partial class EditUserBookTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookSongs", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SongsId")
                        .HasColumnType("uuid");

                    b.HasKey("BooksId", "SongsId");

                    b.HasIndex("SongsId");

                    b.ToTable("BookSongs");
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("age")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Authors", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Access")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("PublishedDate")
                        .HasColumnType("date");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.BookCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("BookCategories", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.BookLikes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId", "BookId")
                        .IsUnique();

                    b.ToTable("BookLikes", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MusicId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ParagraphId")
                        .HasColumnType("uuid");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<string>("sample")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("MusicId");

                    b.HasIndex("ParagraphId");

                    b.ToTable("Entity", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Paragraph", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AgeClass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<string>("MusicSense")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SongId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("SongId");

                    b.ToTable("Paragraphs", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Plans", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Plans", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.RefreshTokens", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpiresOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.SongCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SongCategories", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Songs", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Transactions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uuid");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<string>("States")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.UserBook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBook", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Views", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ViewAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Views", (string)null);
                });

            modelBuilder.Entity("BookSongs", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Songs", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.OwnsOne("Generita.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("AuthorId")
                                .HasColumnType("uuid");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)");

                            b1.Property<string>("firtName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)");

                            b1.HasKey("AuthorId");

                            b1.ToTable("Authors");

                            b1.WithOwner()
                                .HasForeignKey("AuthorId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.HasOne("Generita.Domain.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.BookCategory", "BookCategory")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("BookCategory");
                });

            modelBuilder.Entity("Generita.Domain.Models.BookLikes", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("BookLikes")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("BookLikes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Entity", b =>
                {
                    b.HasOne("Generita.Domain.Models.Author", null)
                        .WithMany("Entities")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Generita.Domain.Models.Songs", "Songs")
                        .WithMany("Entity")
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Paragraph", "Paragraph")
                        .WithMany("Entities")
                        .HasForeignKey("ParagraphId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paragraph");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Generita.Domain.Models.Paragraph", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("Paragraphs")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Songs", "Songs")
                        .WithMany("Paragraphs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Generita.Domain.Models.RefreshTokens", b =>
                {
                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.HasOne("Generita.Domain.Models.SongCategory", "Category")
                        .WithMany("Songs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Generita.Domain.Models.Transactions", b =>
                {
                    b.HasOne("Generita.Domain.Models.Plans", "Plan")
                        .WithMany("Transactions")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.UserBook", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("UserBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("UserBooks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Views", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("Views")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("Views")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Entities");
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.Navigation("BookLikes");

                    b.Navigation("Paragraphs");

                    b.Navigation("UserBooks");

                    b.Navigation("Views");
                });

            modelBuilder.Entity("Generita.Domain.Models.BookCategory", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Generita.Domain.Models.Paragraph", b =>
                {
                    b.Navigation("Entities");
                });

            modelBuilder.Entity("Generita.Domain.Models.Plans", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Generita.Domain.Models.SongCategory", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.Navigation("Entity");

                    b.Navigation("Paragraphs");
                });

            modelBuilder.Entity("Generita.Domain.Models.User", b =>
                {
                    b.Navigation("BookLikes");

                    b.Navigation("RefreshTokens");

                    b.Navigation("Transactions");

                    b.Navigation("UserBooks");

                    b.Navigation("Views");
                });
#pragma warning restore 612, 618
        }
    }
}
```
## File: src\Generita.Infrustructure\Migrations\20250810114541_removesongcategory.cs
```csharp
﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class removesongcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_SongCategories_CategoryId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "SongCategories");

            migrationBuilder.DropIndex(
                name: "IX_Songs_CategoryId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Songs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Songs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SongCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_CategoryId",
                table: "Songs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_SongCategories_CategoryId",
                table: "Songs",
                column: "CategoryId",
                principalTable: "SongCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
```
## File: src\Generita.Infrustructure\Migrations\20250810114541_removesongcategory.Designer.cs
```csharp
﻿// <auto-generated />
using System;
using Generita.Infrustructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    [DbContext(typeof(GeneritaDbContext))]
    [Migration("20250810114541_removesongcategory")]
    partial class removesongcategory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookSongs", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SongsId")
                        .HasColumnType("uuid");

                    b.HasKey("BooksId", "SongsId");

                    b.HasIndex("SongsId");

                    b.ToTable("BookSongs");
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("age")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Authors", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Access")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("PublishedDate")
                        .HasColumnType("date");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.BookCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("BookCategories", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.BookLikes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId", "BookId")
                        .IsUnique();

                    b.ToTable("BookLikes", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MusicId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ParagraphId")
                        .HasColumnType("uuid");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<string>("sample")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("MusicId");

                    b.HasIndex("ParagraphId");

                    b.ToTable("Entity", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Paragraph", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AgeClass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<string>("MusicSense")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SongId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("SongId");

                    b.ToTable("Paragraphs", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Plans", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Plans", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.RefreshTokens", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpiresOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Songs", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Transactions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uuid");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<string>("States")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.UserBook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBook", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Views", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ViewAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Views", (string)null);
                });

            modelBuilder.Entity("BookSongs", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Songs", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.OwnsOne("Generita.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("AuthorId")
                                .HasColumnType("uuid");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)");

                            b1.Property<string>("firtName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)");

                            b1.HasKey("AuthorId");

                            b1.ToTable("Authors");

                            b1.WithOwner()
                                .HasForeignKey("AuthorId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.HasOne("Generita.Domain.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.BookCategory", "BookCategory")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("BookCategory");
                });

            modelBuilder.Entity("Generita.Domain.Models.BookLikes", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("BookLikes")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("BookLikes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Entity", b =>
                {
                    b.HasOne("Generita.Domain.Models.Author", null)
                        .WithMany("Entities")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Generita.Domain.Models.Songs", "Songs")
                        .WithMany("Entity")
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Paragraph", "Paragraph")
                        .WithMany("Entities")
                        .HasForeignKey("ParagraphId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paragraph");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Generita.Domain.Models.Paragraph", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("Paragraphs")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Songs", "Songs")
                        .WithMany("Paragraphs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Generita.Domain.Models.RefreshTokens", b =>
                {
                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Transactions", b =>
                {
                    b.HasOne("Generita.Domain.Models.Plans", "Plan")
                        .WithMany("Transactions")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.UserBook", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("UserBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("UserBooks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Views", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("Views")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("Views")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Entities");
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.Navigation("BookLikes");

                    b.Navigation("Paragraphs");

                    b.Navigation("UserBooks");

                    b.Navigation("Views");
                });

            modelBuilder.Entity("Generita.Domain.Models.BookCategory", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Generita.Domain.Models.Paragraph", b =>
                {
                    b.Navigation("Entities");
                });

            modelBuilder.Entity("Generita.Domain.Models.Plans", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.Navigation("Entity");

                    b.Navigation("Paragraphs");
                });

            modelBuilder.Entity("Generita.Domain.Models.User", b =>
                {
                    b.Navigation("BookLikes");

                    b.Navigation("RefreshTokens");

                    b.Navigation("Transactions");

                    b.Navigation("UserBooks");

                    b.Navigation("Views");
                });
#pragma warning restore 612, 618
        }
    }
}
```
## File: src\Generita.Infrustructure\Migrations\GeneritaDbContextModelSnapshot.cs
```csharp
﻿// <auto-generated />
using System;
using Generita.Infrustructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    [DbContext(typeof(GeneritaDbContext))]
    partial class GeneritaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookSongs", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SongsId")
                        .HasColumnType("uuid");

                    b.HasKey("BooksId", "SongsId");

                    b.HasIndex("SongsId");

                    b.ToTable("BookSongs");
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("age")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Authors", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Access")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("PublishedDate")
                        .HasColumnType("date");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.BookCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("BookCategories", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.BookLikes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId", "BookId")
                        .IsUnique();

                    b.ToTable("BookLikes", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MusicId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ParagraphId")
                        .HasColumnType("uuid");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<string>("sample")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("MusicId");

                    b.HasIndex("ParagraphId");

                    b.ToTable("Entity", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Paragraph", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AgeClass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<string>("MusicSense")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SongId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("SongId");

                    b.ToTable("Paragraphs", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Plans", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Plans", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.RefreshTokens", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpiresOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Songs", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Transactions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uuid");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<string>("States")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.UserBook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBook", (string)null);
                });

            modelBuilder.Entity("Generita.Domain.Models.Views", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ViewAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Views", (string)null);
                });

            modelBuilder.Entity("BookSongs", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Songs", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.OwnsOne("Generita.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("AuthorId")
                                .HasColumnType("uuid");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)");

                            b1.Property<string>("firtName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)");

                            b1.HasKey("AuthorId");

                            b1.ToTable("Authors");

                            b1.WithOwner()
                                .HasForeignKey("AuthorId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.HasOne("Generita.Domain.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.BookCategory", "BookCategory")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("BookCategory");
                });

            modelBuilder.Entity("Generita.Domain.Models.BookLikes", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("BookLikes")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("BookLikes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Entity", b =>
                {
                    b.HasOne("Generita.Domain.Models.Author", null)
                        .WithMany("Entities")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Generita.Domain.Models.Songs", "Songs")
                        .WithMany("Entity")
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Paragraph", "Paragraph")
                        .WithMany("Entities")
                        .HasForeignKey("ParagraphId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paragraph");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Generita.Domain.Models.Paragraph", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("Paragraphs")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.Songs", "Songs")
                        .WithMany("Paragraphs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Generita.Domain.Models.RefreshTokens", b =>
                {
                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Transactions", b =>
                {
                    b.HasOne("Generita.Domain.Models.Plans", "Plan")
                        .WithMany("Transactions")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.UserBook", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("UserBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("UserBooks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Views", b =>
                {
                    b.HasOne("Generita.Domain.Models.Book", "Book")
                        .WithMany("Views")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Generita.Domain.Models.User", "User")
                        .WithMany("Views")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Generita.Domain.Models.Author", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Entities");
                });

            modelBuilder.Entity("Generita.Domain.Models.Book", b =>
                {
                    b.Navigation("BookLikes");

                    b.Navigation("Paragraphs");

                    b.Navigation("UserBooks");

                    b.Navigation("Views");
                });

            modelBuilder.Entity("Generita.Domain.Models.BookCategory", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Generita.Domain.Models.Paragraph", b =>
                {
                    b.Navigation("Entities");
                });

            modelBuilder.Entity("Generita.Domain.Models.Plans", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Generita.Domain.Models.Songs", b =>
                {
                    b.Navigation("Entity");

                    b.Navigation("Paragraphs");
                });

            modelBuilder.Entity("Generita.Domain.Models.User", b =>
                {
                    b.Navigation("BookLikes");

                    b.Navigation("RefreshTokens");

                    b.Navigation("Transactions");

                    b.Navigation("UserBooks");

                    b.Navigation("Views");
                });
#pragma warning restore 612, 618
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\GeneritaDbContext.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Generita.Infrustructure.Persistance
{
    public class GeneritaDbContext : DbContext
    {
        public GeneritaDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Entity> Entity { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBook> UsersBook { get; set; }
        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<BookLikes> BookLikes { get; set; }
        //public DbSet<SongCategory> SongCategory { get; set; }
        public DbSet<Paragraph> Paragraph { get; set; }
        public DbSet<Views> Views { get; set; }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<RefreshTokens> RefreshTokens { get; set; }
        public DbSet<Plans> Plans { get; set; }
        //public DbSet<BookSong> BookSong { get; set; }
        //public DbSet<UserPlan> UserPlan { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GeneritaDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
```
## File: src\Generita.Infrustructure\Persistance\UnitOfWork.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Generita.Infrustructure.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private GeneritaDbContext _dbContext;

        public UnitOfWork(GeneritaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Configurations\AuthorConfig.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Generita.Infrustructure.Persistance.Configurations
{
    internal class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Books)
                .WithOne(x => x.Author);
            builder.OwnsOne(x => x.Name, name =>
            {
                name.Property(x => x.firtName)
                    .IsRequired()
                    .HasMaxLength(30);
                name.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(30);
            });
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Configurations\BookCategoryConfig.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Generita.Infrustructure.Persistance.Configurations
{
    internal class BookCategoryConfig : IEntityTypeConfiguration<Domain.Models.BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.ToTable("BookCategories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CategoryName)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Configurations\BookConfig.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace Generita.Infrustructure.Persistance.Configurations
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Title).IsRequired()
                .HasMaxLength(30);
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x=>x.AuthorId);
            builder.HasOne(b => b.BookCategory)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.CategoryId);
            builder.Property(x => x.FilePath)
                .IsRequired();
            builder.Property(x=>x.Access)
                .HasConversion<string>()
                .IsRequired();
            builder.HasMany(x => x.UserBooks)
                .WithOne(x => x.Book);
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Configurations\BookLikesConfig.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Generita.Infrustructure.Persistance.Configurations
{
    public class BookLikesConfig : IEntityTypeConfiguration<BookLikes>
    {
        public void Configure(EntityTypeBuilder<BookLikes> builder)
        {
            builder.ToTable("BookLikes");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.UserId, x.BookId })
                .IsUnique();
            builder.HasOne(x => x.User)
                .WithMany(x => x.BookLikes)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Book)
                .WithMany(x => x.BookLikes)
                .HasForeignKey(x => x.BookId);
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Configurations\EntityConfig.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Generita.Infrustructure.Persistance.Configurations
{
    public class EntityConfig : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.ToTable("Entity");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Paragraph)
                .WithMany(x => x.Entities)
                .HasForeignKey(x => x.ParagraphId);
            builder.HasOne(x => x.Songs)
                .WithMany(x => x.Entity)
                .HasForeignKey(x => x.MusicId);


        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Configurations\ParagraphConfig.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace Generita.Infrustructure.Persistance.Configurations
{
    internal class ParagraphConfig : IEntityTypeConfiguration<Paragraph>
    {
        public void Configure(EntityTypeBuilder<Paragraph> builder)
        {
            builder.ToTable("Paragraphs");
            builder.HasKey(p => p.Id);
            builder.HasOne(x => x.Book)
                .WithMany(x => x.Paragraphs)
                .HasForeignKey(x => x.BookId);
            builder.HasOne(x => x.Songs)
                .WithMany(x => x.Paragraphs)
                .HasForeignKey(x => x.SongId);
            builder.HasMany(x => x.Entities)
                .WithOne(x => x.Paragraph);
            builder.Property(x => x.MusicSense)
                .HasConversion<string>();
            builder.Property(x=>x.AgeClass)
                .HasConversion<string>();
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Configurations\PlansConfig.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Generita.Infrustructure.Persistance.Configurations
{
    public class PlansConfig : IEntityTypeConfiguration<Plans>
    {
        public void Configure(EntityTypeBuilder<Plans> builder)
        {
            builder.ToTable("Plans");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Transactions)
                .WithOne(x => x.Plan);

        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Configurations\RefreshTokenConfig.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Generita.Infrustructure.Persistance.Configurations
{
    internal class RefreshTokenConfig : IEntityTypeConfiguration<RefreshTokens>
    {
        public void Configure(EntityTypeBuilder<RefreshTokens> builder)
        {
            builder.ToTable("RefreshTokens");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x=>x.Token).IsUnique();
            builder.Property(x => x.Token).HasMaxLength(200);
            builder.HasOne(x => x.User)
                .WithMany(x => x.RefreshTokens)
                .HasForeignKey(x => x.UserId);
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Configurations\SongCategoryConfig.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Generita.Infrustructure.Persistance.Configurations
{
    //internal class SongCategoryConfig : IEntityTypeConfiguration<Domain.Models.SongCategory>
    //{
    //    public void Configure(EntityTypeBuilder<SongCategory> builder)
    //    {
    //        builder.ToTable("SongCategories");
    //        builder.HasKey(x => x.Id);
    //        builder.HasMany(x => x.Songs)
    //            .WithOne(Songs => Songs.Category);
    //    }
    //}
}
```
## File: src\Generita.Infrustructure\Persistance\Configurations\SongConfig.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace Generita.Infrustructure.Persistance.Configurations
{
    public class SongConfig : IEntityTypeConfiguration<Songs>
    {
        public void Configure(EntityTypeBuilder<Songs> builder)
        {
            builder.ToTable("Songs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Owner)
                .IsRequired()
                .HasConversion<string>();
            builder.HasMany(x => x.Books)
                .WithMany(x => x.Songs);
            //builder.HasOne(x => x.Category)
            //    .WithMany(x => x.Songs)
            //    .HasForeignKey(x => x.CategoryId);
            builder.Property(x => x.FilePath)
                .IsRequired();
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Configurations\TransactionsConfig.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Generita.Infrustructure.Persistance.Configurations
{
    public class TransactionsConfig : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Plan)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.PlanId);
            builder.Property(x => x.States)
                .HasConversion<string>();
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Configurations\UserBookConfig.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace Generita.Infrustructure.Persistance.Configurations
{
    public class UserBookConfig : IEntityTypeConfiguration<UserBook>
    {

        public void Configure(EntityTypeBuilder<UserBook> builder)
        {
            builder.ToTable("UserBook");
            builder.HasKey(t => t.Id);
            builder.HasOne(x => x.User)
                .WithMany(x => x.UserBooks)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Book)
                .WithMany(x => x.UserBooks)
                .HasForeignKey(x => x.BookId);
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Configurations\UserConfig.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace Generita.Infrustructure.Persistance.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x=> x.Email)
                .IsRequired()
                .HasMaxLength(30);
            builder.HasIndex(x => x.Email)
                .IsUnique();
            builder.Property(x => x.Password)
                .IsRequired();
            builder.HasMany(x => x.UserBooks)
                .WithOne(x => x.User);

        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Configurations\ViewsConfig.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Generita.Infrustructure.Persistance.Configurations
{
    internal class ViewsConfig : IEntityTypeConfiguration<Views>
    {
        public void Configure(EntityTypeBuilder<Views> builder)
        {
            builder.ToTable("Views");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User)
                .WithMany(x => x.Views)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Book)
                .WithMany(x => x.Views)
                .HasForeignKey(x => x.BookId);
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Repositories\AuthorRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Generita.Infrustructure.Persistance.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private GeneritaDbContext _dbContext;

        public AuthorRepository(GeneritaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Author value)
        {
            await _dbContext.Author.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var author = await _dbContext.Author.FindAsync(id);
            if (author is null)
                return false;
            _dbContext.Author.Remove(author);
            return true;
        }

        public async Task<ICollection<Author>> GetAll()
        {
            return await _dbContext.Author.ToListAsync();
        }

        public async Task<Author> GetById(Guid id)
        {
            return await _dbContext.Author.FirstOrDefaultAsync(a => a.Id == id);
        }

        public Task<bool> Update(Author value)
        {
            _dbContext.Update(value);
            return Task.FromResult(true);
        }
        public async Task<Author?> GetByAuthorName(string authorName)
        {
            return await _dbContext.Author
                .Include(x => x.Books)
                .Where(x =>
                    EF.Functions.Like((x.Name.firtName + " " + x.Name.LastName).ToLower(), $"%{authorName.ToLower()}%"))
                .FirstOrDefaultAsync();
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Repositories\BookCategoryRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Http.Logging;

namespace Generita.Infrustructure.Persistance.Repositories
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private GeneritaDbContext _dbContext;

        public BookCategoryRepository(GeneritaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(BookCategory value)
        {
            await _dbContext.BookCategory.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var category = await _dbContext.BookCategory.FindAsync(id);
            if (category is null)
                return false;
            _dbContext.BookCategory.Remove(category);
            return true;
        }

        public async Task<ICollection<BookCategory>> GetAll()
        {
            return await _dbContext.BookCategory.ToListAsync();
        }

        public async Task<BookCategory> GetById(Guid id) => await _dbContext.BookCategory.FirstOrDefaultAsync(c => c.Id == id);

        public Task<bool> Update(BookCategory value)
        {
            _dbContext.BookCategory.Update(value);
            return Task.FromResult(true);
        }

        public async Task<ICollection<BookCategory>> GetByName(string name)
        {
            return await _dbContext.BookCategory
                .Include(x => x.Books)
                .Where(x => EF.Functions.Like(x.CategoryName, $"%{name}%"))
                .ToListAsync();
        }


    }
}
```
## File: src\Generita.Infrustructure\Persistance\Repositories\BookRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Dtos;
using Generita.Domain.Common.Enums;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Generita.Infrustructure.Persistance.Repositories
{
    internal class BookRepository : IBookRepository
    {
        private GeneritaDbContext _db;

        public BookRepository(GeneritaDbContext db)
        {
            _db = db;
        }

        public async Task Add(Book value)
        {
            await _db.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var book = await _db.Book.FindAsync(id);
            if (book is null)
                return false;

            _db.Book.Remove(book);
            return true;
        }

        public async Task<ICollection<Book>> GetAll()
        {
            return await _db.Book.ToListAsync();
        }

        public async Task<Book> GetById(Guid id)
        {
            return await _db.Book.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Dictionary<Guid, int>> GetLikesNumber(IEnumerable<Guid> bookIds)
        {
            return await _db.BookLikes
                .Where(bl => bookIds.Contains(bl.BookId))
                .GroupBy(bl => bl.BookId)
                .Select(g => new { BookId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.BookId, x => x.Count);
        }


        public async Task<ICollection<Book>> SearchBook(string bookName)
        {
            return await _db.Book
                .Where(b => EF.Functions.Like(b.Title.ToLower(), $"%{bookName.ToLower()}%"))
                .ToListAsync();
        }

        public Task<bool> Update(Book value)
        {
            _db.Book.Update(value);
            return Task.FromResult(true);
        }
        public async Task<ICollection<Book>> GetByPublishedDate(DateOnly dateOnly)
        {
            return await _db.Book
                .Include(b => b.Author)
                .Where(x => x.PublishedDate == dateOnly)
                .ToListAsync();
        }
        public async Task<ICollection<Book>> GetNewestBooks()
        {
            return await _db.Book.Include(b => b.Author).Include(b => b.BookCategory).OrderByDescending(x=>x.PublishedDate).Take(10).ToListAsync();
        }
        public async Task<ICollection<Book>> GetSubscriptionOnly()
        {
            return await _db.Book.Include(x => x.Author).Include(x => x.BookCategory).Where(x => x.Access == BookAccess.Subscription).ToListAsync();
        }
        public async Task<ICollection<Book>> GetFreeOnly()
        {
            return await _db.Book.Include(x => x.Author).Include(x => x.BookCategory).Where(x => x.Access == BookAccess.Free).ToListAsync();
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Repositories\EntityRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Generita.Infrustructure.Persistance.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private GeneritaDbContext _context;

        public EntityRepository(GeneritaDbContext context)
        {
            _context = context;
        }

        public async Task Add(Entity value)
        {
            await _context.Entity.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = _context.Entity.FirstOrDefaultAsync(x=>x.Id==id);
            if (entity is null)
                return false;

             _context.Remove(id);
            return true;
        }

        public async Task<ICollection<Entity>> GetAll()
        {
            return await _context.Entity.ToListAsync();
        }

        public async Task<Entity> GetById(Guid id)
        {
            return await _context.Entity.FirstOrDefaultAsync(x => x.Id==id);
        }

        public Task<Entity> GetEntityByBookId(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Entity value)
        {
            _context.Entity.Update(value);
            return Task.FromResult(true);
        }
        public async Task<Entity> GetByType(string type)
        {
            return await _context.Entity.Include(x => x.Songs).FirstOrDefaultAsync(x => x.type == type);
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Repositories\ParagraphRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Common.Enums;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Generita.Infrustructure.Persistance.Repositories
{
    public class ParagraphRepository : IParagraphRepository
    {
        private GeneritaDbContext _context;

        public ParagraphRepository(GeneritaDbContext context)
        {
            _context = context;
        }

        public async Task Add(Paragraph value)
        {
            await  _context.Paragraph.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var paragraph=await _context.Paragraph.FirstOrDefaultAsync(x=>x.Id == id);
            if (paragraph is null)
                return false;
            _context.Paragraph.Remove(paragraph);
            return true;

        }

        public async Task<ICollection<Paragraph>> GetAll()
        {
            return await _context.Paragraph.ToListAsync();
        }

        public async Task<Paragraph> GetById(Guid id)
        {
            return await _context.Paragraph.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> Update(Paragraph value)
        {
            _context.Paragraph.Update(value);
            return Task.FromResult(true);
        }
        public async Task<ICollection<Paragraph>> GetByBookId(Guid bookId)
        {
            return await _context.Paragraph.Include(x=>x.Entities).Where(x=>x.BookId == bookId).ToListAsync();
        }
        public async Task<Paragraph> GetBySenseAndAge(MusicSense  sense,AgeClasses age)
        {
            return await _context.Paragraph.Include(x=>x.Songs).FirstOrDefaultAsync(x => x.AgeClass == age && x.MusicSense == sense);
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Repositories\PlansRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Generita.Infrustructure.Persistance.Repositories
{
    internal class PlansRepository : IPlansRepository
    {
        private GeneritaDbContext _db;

        public PlansRepository(GeneritaDbContext db)
        {
            _db = db;
        }

        public async Task Add(Plans value)
        {
            await _db.Plans.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var plans=await _db.Plans.FindAsync(id);
            if(plans is null)
                return false;
             _db.Plans.Remove(plans);
            return true;
        }

        public async Task<ICollection<Plans>> GetAll()
        {
            return await _db.Plans.ToListAsync();
        }

        public async Task<Plans> GetById(Guid id)
        {
            return await _db.Plans.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Plans> GetPlanByName(string name)
        {
            return await _db.Plans.FirstOrDefaultAsync(x=>EF.Functions.Like(x.Name,$"%{name}%"));
        }

        public Task<bool> Update(Plans value)
        {
            _db.Plans.Update(value);
            return Task.FromResult(true);
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Repositories\RefreshTokenRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Generita.Infrustructure.Persistance.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private GeneritaDbContext _context;

        public RefreshTokenRepository(GeneritaDbContext context)
        {
            _context = context;
        }

        public async Task Add(RefreshTokens value)
        {
            await _context.RefreshTokens.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var rt=await _context.RefreshTokens.FirstOrDefaultAsync(x=>x.Id==id);
            if(rt is null) return false;
            _context.RefreshTokens.Remove(rt);
            return true;
        }

        public async Task<ICollection<RefreshTokens>> GetAll()
        {
            return await _context.RefreshTokens.ToListAsync();
        }

        public async Task<RefreshTokens> GetById(Guid id)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<RefreshTokens> GetByToken(string token)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(x=>x.Token==token);
        }

        public Task<bool> Update(RefreshTokens value)
        {
            _context.RefreshTokens.Update(value);
            return Task.FromResult(true);
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Repositories\SongCategoryRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Generita.Infrustructure.Persistance.Repositories
{
    //public class SongCategoryRepository : ISongCategoryRepository
    //{
    //    private GeneritaDbContext _context;

    //    public SongCategoryRepository(GeneritaDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task Add(SongCategory value)
    //    {
    //        await _context.SongCategory.AddAsync(value);
    //    }

    //    public async  Task<bool> Delete(Guid id)
    //    {
    //        var cat = await _context.SongCategory.FindAsync(id);
    //        if (cat is null)
    //            return false;
    //        _context.SongCategory.Remove(cat);
    //        return true;

    //    }

    //    public async Task<ICollection<SongCategory>> GetAll()
    //    {
    //        return await _context.SongCategory.ToListAsync();
    //    }

    //    public async Task<SongCategory> GetById(Guid id)
    //    {
    //        return await _context.SongCategory.FirstOrDefaultAsync(x => x.Id == id);
    //    }

    //    public Task<bool> Update(SongCategory value)
    //    {
    //        _context.Update(value);
    //        return Task.FromResult(true);
    //    }
    //}
}
```
## File: src\Generita.Infrustructure\Persistance\Repositories\SongsRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Generita.Infrustructure.Persistance.Repositories
{
    public class SongsRepository : ISongRepository
    {
        private GeneritaDbContext _dbContext;

        public SongsRepository(GeneritaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Songs value)
        {
            await _dbContext.Songs.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var song = await _dbContext.Songs.FindAsync(id);
            if (song is null)
                return false;
            _dbContext.Songs.Remove(song);
            return true;
        }

        public async Task<ICollection<Songs>> GetAll()
        {
            return await _dbContext.Songs.ToListAsync(); 
        }

        public async Task<Songs> GetById(Guid id)
        {
            return await _dbContext.Songs.FirstOrDefaultAsync(x => x.Id==id);
        }

        public Task<bool> Update(Songs value)
        {
            _dbContext.Songs.Update(value);
            return Task.FromResult(true);
        }
    }
}
```
## File: src\Generita.Infrustructure\Persistance\Repositories\TransactionRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Generita.Infrustructure.Persistance.Repositories
{
    class TransactionRepository : ITransactionsRepository
    {
        private GeneritaDbContext _context;

        public TransactionRepository(GeneritaDbContext context)
        {
            _context = context;
        }

        public async Task Add(Transactions value)
        {
            await  _context.Transactions.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var transaction=await _context.Transactions.FindAsync(id);
            if (transaction is null)
                return false;
            _context.Transactions.Remove(transaction);
            return true;
        }

        public async Task<ICollection<Transactions>> GetAll()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transactions> GetById(Guid id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> Update(Transactions value)
        {
            _context.Transactions.Update(value);
            return Task.FromResult(true);
        }
        public async Task<Transactions> GetByUserId(Guid userId)
        {
            var Trans=await _context.Transactions.Include(x=>x.Plan).OrderBy(x=>x.CreateAt).FirstOrDefaultAsync(x=>x.UserId==userId);
            return Trans;

        }

    }
}
```
## File: src\Generita.Infrustructure\Persistance\Repositories\UserRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Generita.Infrustructure.Persistance.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private GeneritaDbContext _dbContext;

        public UserRepository(GeneritaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(User value)
        {
            await _dbContext.Users.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user is null)
                return false;
            _dbContext.Users.Remove(user);
            return true;
        }

        public async Task<ICollection<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => EF.Functions.Like(x.Email, $"{email}%"));
        }

        public Task<bool> Update(User value)
        {
            _dbContext.Users.Update(value);
            return Task.FromResult(true);
        }
        public async Task<bool> IsExistsByEmail(string email)
        {
            var res = await _dbContext.Users.AnyAsync(x => x.Email.ToLower() == email.ToLower());
            return res;
        }
        public async Task<ICollection<UserBook>> GetByIdWithBooks(Guid id)
        {
            return await _dbContext.UsersBook.Include(x => x.Book).Where(x => x.UserId == id).ToListAsync();
        }
        public async Task AddBookToLibrary(UserBook userbook)
        {
            await _dbContext.UsersBook.AddAsync(userbook);
        }
        public async Task<bool> DeleteBookFromLibrary(Guid bookId, Guid UserId)
        {
            var item = await _dbContext.UsersBook.FirstOrDefaultAsync(x => x.UserId == UserId && x.BookId == bookId);
            if (item == null)
                return false;
            _dbContext.UsersBook.Remove(item);
            return true;
        }
        public async Task<ICollection<BannerBookDto>> GetPopularBooks()
        {
            var popularBooks = await _dbContext.UsersBook
                .Include(x => x.Book)
            .GroupBy(ub => ub.Book) 
            .Select(g => new BannerBookDto
            {
                Book = g.Key,
                UserCount = g.Count()
            })
            .OrderByDescending(g => g.UserCount)
            .Take(10)
            .ToListAsync();
            return popularBooks;
        }
    }
}
```
## File: src\Generita.Infrustructure\Authentication\TokenGenerator\JwtSettings.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Infrustructure.Authentication.TokenGenerator
{
    public class JwtSettings
    {
        public string Secret { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public int ExpiryMinutes { get; set; }
    }

}
```
## File: src\Generita.Infrustructure\Authentication\TokenGenerator\TokenGenerator.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

//using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces;
using Generita.Domain.Models;

using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Generita.Infrustructure.Authentication.TokenGenerator
{
    public class TokenGenerator : ITokenGenerator
    {
        private IConfiguration _configuration;

        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            string secretKey = _configuration["JwtSettings:Secret"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JwtSettings:ExpiryMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        public string RefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        }
    }
}
```
## File: src\Generita.Domain\Models\Author.cs
```csharp
﻿using Generita.Domain.Common.Abstractions;
using Generita.Domain.ValueObjects;

namespace Generita.Domain.Models;

public class Author:AggregateRoot
{
    public Author(Guid id) : base(id)
    {
    }

    public Name Name { get; set; }
    public DateOnly BirthDate { get;}
    public int age { get; set; }
    public string Nationality { get; set;} 
    public virtual ICollection<Book> Books { get; set; }
    public virtual ICollection<Entity> Entities { get; set; }
}
```
## File: src\Generita.Domain\Models\Book.cs
```csharp
﻿using Generita.Domain.Common.Abstractions;
using Generita.Domain.Common.Enums;

namespace Generita.Domain.Models;

public class Book:AggregateRoot
{
    public Book(Guid Id) : base(Id)
    {
    }

    public string Title { get; set; }
    public DateOnly PublishedDate { get; set; }
    public Guid AuthorId { get; set; }
    public Guid CategoryId { get; set; }
    public string Synopsis { get; set; }
    public string Cover {  get; set; }
    public BookAccess Access { get; set; }
    public virtual Author Author { get; set; }
    public virtual BookCategory BookCategory { get; set; }
    public string FilePath { get; set; }
    public string ImagePath { get; set; }
    public virtual ICollection<Songs> Songs { get; set; }
    public virtual ICollection<Paragraph> Paragraphs { get; set; }
    public virtual ICollection<Views> Views { get; set; }
    public virtual ICollection<UserBook> UserBooks { get; set; }
    public virtual ICollection<BookLikes> BookLikes { get; set; }
}
```
## File: src\Generita.Domain\Models\BookCategory.cs
```csharp
﻿
using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models;

public class BookCategory:BaseEntity
{
    public BookCategory(Guid id) : base(id)
    {
    }

    public string CategoryName { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}
```
## File: src\Generita.Domain\Models\BookLikes.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models
{
    public class BookLikes : BaseEntity
    {
        public BookLikes(Guid id) : base(id)
        {
        }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime CreateAt { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }

    }
}
```
## File: src\Generita.Domain\Models\BookSong.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models
{
    public class BookSong:BaseEntity
    {
        public BookSong(Guid id) : base(id)
        {
        }

        public Guid BookId { get; set; }
        public Guid SongId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Songs Song { get; set; }
    }
}
```
## File: src\Generita.Domain\Models\Diagram.mmd
```
classDiagram
    class Songs {
        +Guid Id
        +Name Name
        +TimeSpan Duration
        +DateOnly CreateAt
        +DateOnly UpdateAt
        +string FilePath
        +ICollection~BookSong~ BookSongs
    }
    class User {
        +Guid UserId
        +Name Name
        +DateOnly CreateAt
        +DateOnly UpdateAt
        +string Email
        +string Password
        +string Salt
        +ICollection~Transactions~ Transactions
    }

    class Author {
        +Guid Id
        +Name Name
        +DateOnly BirthDate
        +string Nationality
        +ICollection~Books~ Books
    }
    class Books{
        +string Title 
        +Guid Id 
        +DateOnly PublishedDate 
        +Guid AuthorId 
        +int CategoryId 
        +Author Author 
        +Category Category 
        +string FilePath 
        +string ImagePath 
        +ICollection<BookSong> BookSongs 
    }
    class BookSong {
        Guid Id
        Guid BookId
        Guid SongId
        +Books Book
        +Songs Song
    }

    class Category {
        int id
        string CategoryName
        +ICollection<Books> Books
    }

    class Plans {
        int Id
        string Name
        string Description
        int Price
        int Duration
        +ICollection<UserPlan> UserPlans
    }
    class Transactions {
        Guid Id
        Guid UserId
        DateOnly CreateAt
        DateOnly UpdateAt
        int Price
        States States
        +User User
    }

    class UserPlan {
        Guid Id
        Guid PlanId
        Guid TransationId
        DateOnly CreateAt
        DateOnly EndsAt
        +Plans Plan
        +Transactions Transactions
    }

    class Views {
        Guid UserId
        Guid BookId
        DateTime ViewAt
    }
    Songs --> BookSong :"One-To-Many"
    BookSong --> Books :"Many-to-One"
    Books --> Author :"One-To-One"
    Books --> Category :One-to-One"
    User --> Transactions :"many-to-one"
    UserPlan --> Plans :"one-to-one"
    UserPlan --> Transactions :"one-to-one"
```
## File: src\Generita.Domain\Models\Entity.cs
```csharp
﻿using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models;

public class Entity:BaseEntity
{
    public Entity(Guid Id) : base(Id)
    {
    }

    public string type { get; set; }
    public string sample { get; set; }
    public int Position { get; set; }
    public Guid ParagraphId { get; set; }
    public Guid MusicId { get; set; }
    public virtual Paragraph Paragraph { get; set; }
    public virtual Songs Songs { get; set; }

    //public virtual Songs Songs { get; set; }
}
```
## File: src\Generita.Domain\Models\Paragraph.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;
using Generita.Domain.Common.Enums;

namespace Generita.Domain.Models
{
    public class Paragraph : BaseEntity
    {
        public Paragraph(Guid id) : base(id)
        {
        }
        public string Text { get; set; }
        public AgeClasses AgeClass { get; set; }
        public MusicSense MusicSense { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; } 
        public Guid SongId { get; set; }
        public Songs Songs { get; set; }
        public ICollection<Entity> Entities { get; set; }
    }
}
```
## File: src\Generita.Domain\Models\Plans.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models
{
    public class Plans:AggregateRoot
    {
        public Plans(Guid Id) : base(Id)
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        //Duration is in Days 
        public int Duration { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
```
## File: src\Generita.Domain\Models\RefreshTokens.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models
{
    public class RefreshTokens : BaseEntity
    {
        public RefreshTokens(Guid id) : base(id)
        {
        }

        public string Token {  get; set; }
        public Guid UserId { get; set; }
        public DateTime ExpiresOnUtc {  get; set; }
        public virtual User User { get; set; }
    }
}
```
## File: src\Generita.Domain\Models\SongCategory.cs
```csharp
﻿using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models;

public class SongCategory:BaseEntity
{
    public SongCategory(Guid id) : base(id)
    {
    }

    public string Name { get; set; }
    public virtual ICollection<Songs> Songs { get; set; }
}
```
## File: src\Generita.Domain\Models\Songs.cs
```csharp
﻿using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.Marshalling;
using System.Security.AccessControl;

using Generita.Domain.Common.Abstractions;
using Generita.Domain.Enums;
using Generita.Domain.ValueObjects;

namespace Generita.Domain.Models;

public class Songs:AggregateRoot
{
    public Songs(Guid Id) : base(Id)
    {
    }

    public string Name { get; set; }
    //public Guid CategoryId { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public string FilePath { get; set; }
    public OwnerShip Owner { get; set; }
    public ICollection<Paragraph> Paragraphs { get; set; }
    public ICollection<Entity> Entity { get; set; }
    public virtual ICollection<Book> Books { get; set; }
    //public virtual SongCategory Category { get; set; }
}
```
## File: src\Generita.Domain\Models\Transactions.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;
using Generita.Domain.Enums;

namespace Generita.Domain.Models
{
    public class Transactions:BaseEntity
    {
        public Transactions(Guid Id) : base(Id)
        {
        }

        public Guid UserId { get; set; }
        public Guid PlanId { get; set; }
        public DateTime CreateAt {  get; set; }
        public int Price { get; set; }
        public States States { get; set; }
        public virtual User User { get; set; }
        public virtual Plans Plan { get; set; }
    }
}
```
## File: src\Generita.Domain\Models\User.cs
```csharp
﻿using Generita.Domain.Common.Abstractions;
using Generita.Domain.ValueObjects;

namespace Generita.Domain.Models;

public class User:AggregateRoot
{
    public User(Guid Id) : base(Id)
    {
    }

    public string Name { get; set; }
    public DateTime CreateAt{ get; set; }
    public DateTime UpdateAt { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public virtual ICollection<Transactions> Transactions { get; set; }
    public virtual ICollection<Views> Views { get; set; }
    public virtual ICollection<RefreshTokens> RefreshTokens { get; set; }
    public virtual ICollection<UserBook> UserBooks { get; set; }
    public virtual ICollection<BookLikes> BookLikes { get; set; }
}
```
## File: src\Generita.Domain\Models\UserBook.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models
{
    public class UserBook : BaseEntity
    {
        public UserBook(Guid id) : base(id)
        {
        }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime AddedAt { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
    }
}
```
## File: src\Generita.Domain\Models\UserPlan.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models
{
    public class UserPlan:AggregateRoot
    {
        public UserPlan(Guid Id) : base(Id)
        {
        }

        public Guid PlanId { get; set; }
        public Guid TransationId { get; set; }
        public DateOnly CreateAt { get; set; }
        public DateOnly EndsAt { get; set; }
        public virtual Plans Plan { get; set; }
        public virtual Transactions Transactions { get; set; }

    }
}
```
## File: src\Generita.Domain\Models\Views.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models
{
    public class Views:BaseEntity
    {
        public Views(Guid id) : base(id)
        {
        }

        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime ViewAt { get; set; }
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
```
## File: src\Generita.Domain\Common\Abstractions\AggregateRoot.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Interfaces;

namespace Generita.Domain.Common.Abstractions
{
    public  class AggregateRoot:BaseEntity
    {

        protected readonly List<IDomainEvent> _domainEvents = new();

        protected AggregateRoot(Guid id) : base(id)
        {
        }

        public List<IDomainEvent> PopDomainEvents()
        {
            var copy = _domainEvents.ToList();
            _domainEvents.Clear();

            return copy;
        }
    }
}
```
## File: src\Generita.Domain\Common\Abstractions\BaseEntity.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Domain.Common.Abstractions
{
    public class BaseEntity
    {
        public Guid Id;
        protected BaseEntity(Guid id)
        {
            this.Id = id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            return ((Entity)obj).Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
```
## File: src\Generita.Domain\Common\Enums\AgeClasses.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Domain.Common.Enums
{
    public enum AgeClasses
    {
       AncientAndOldAge,
       Natural,
       TechnologyAndModernAge
    }
}
```
## File: src\Generita.Domain\Common\Enums\BookAccess.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Domain.Common.Enums
{
    public enum BookAccess
    {
        Free,
        Subscription

    }
}
```
## File: src\Generita.Domain\Common\Enums\MusicSense.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Domain.Common.Enums
{
    public enum MusicSense
    {
        NormalAndNatural,
        LoveAndRomantic,
        WarAndCombat,
        FantasyAndMythodlogy,
        HonorAndRespect,
        DramaAndTragedy,
        CityAndCrowd,
        MountainAndTheheights,
        DesertAndDunes,
        SeaAndTides,
        ForestAndTrees,
    }
}
```
## File: src\Generita.Domain\Common\Enums\OwnerShip.cs
```csharp
﻿namespace Generita.Domain.Enums;

public enum OwnerShip
{
    Genrerated,
    Author,
}
```
## File: src\Generita.Domain\Common\Enums\States.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Domain.Enums
{
    public enum States
    {
        Success,
        Failed,
        Cancelled,
        Pending
    }
}
```
## File: src\Generita.Domain\Common\Interfaces\IDomainEvent.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Generita.Domain.Common.Interfaces
{
    public interface IDomainEvent:INotification
    {
    }
}
```
## File: src\Generita.Domain\Common\Interfaces\IUnitOfWork.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Domain.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
        void Rollback();
    }
}
```
## File: src\Generita.Domain\Common\ValueObjects\Name.cs
```csharp
﻿namespace Generita.Domain.ValueObjects;

public record Name(string firtName, string LastName);
```
## File: src\Generita.Application\Users\Commands\AddBookToLibrary\AddUserLibrarayResponse.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Users.Commands.AddBookToLibrary
{
    public class AddUserLibrarayResponse
    {
        public ICollection<Guid> LibraryBookIds { get; set; }
    }
}
```
## File: src\Generita.Application\Users\Commands\AddBookToLibrary\AddUserLibraryHandler.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Common.Enums;
using Generita.Domain.Common.Interfaces;
using Generita.Domain.Models;

namespace Generita.Application.Users.Commands.AddBookToLibrary
{
    internal class AddUserLibraryHandler : IQueryHandler<AddUserLibraryQuery, AddUserLibrarayResponse>
    {
        private IUserRepository _userRepository;
        private IBookRepository _bookRepository;
        private IUnitOfWork _unitOfWork;
        private ITransactionsRepository _transactionsRepository;

        public AddUserLibraryHandler(IUserRepository userRepository, IBookRepository bookRepository, IUnitOfWork unitOfWork, ITransactionsRepository transactionsRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _transactionsRepository = transactionsRepository;
        }

        public async  Task<ErrorOr<AddUserLibrarayResponse>> Handle(AddUserLibraryQuery request, CancellationToken cancellationToken)
        {
            bool HasSubscription=true;
            //check if user hasnt got subscipriton and the book isnt free return error
            var book = await _bookRepository.GetById(request.GetUserLibraryRequest.BookId);
            if (book is null)
                return Error.NotFound(description: "Book doesn't found");
            var transaction = await _transactionsRepository.GetByUserId(request.GetUserLibraryRequest.UserId);
            if (transaction is null)
                HasSubscription = false;
            else HasSubscription = transaction.CreateAt.AddDays(transaction.Plan.Duration) >= DateTime.UtcNow;
            if (book.Access == BookAccess.Free)
            {

                UserBook userbook = new(Guid.NewGuid())
                {
                    BookId = request.GetUserLibraryRequest.BookId,
                    UserId = request.GetUserLibraryRequest.UserId,
                };
                await _userRepository.AddBookToLibrary(userbook);
                await _unitOfWork.CommitAsync(cancellationToken);
                var newbooks = await _userRepository.GetByIdWithBooks(request.GetUserLibraryRequest.UserId);
                AddUserLibrarayResponse res = new()
                { LibraryBookIds = newbooks.Select(x => x.BookId).ToList() };
                return res;

            }
            else if (book.Access == BookAccess.Subscription && HasSubscription == false)
                return Error.Forbidden(description: "User doesn't have active subscription");
            else
            {
                UserBook userbook = new(Guid.NewGuid())
                {
                    BookId = request.GetUserLibraryRequest.BookId,
                    UserId = request.GetUserLibraryRequest.UserId,
                };
                await _userRepository.AddBookToLibrary(userbook);
                await _unitOfWork.CommitAsync();
                var newbooks =await  _userRepository.GetByIdWithBooks(request.GetUserLibraryRequest.UserId);
                AddUserLibrarayResponse res = new()
                { LibraryBookIds = newbooks.Select(x => x.BookId).ToList() };
                return res;
            }
        }
    }
}
```
## File: src\Generita.Application\Users\Commands\AddBookToLibrary\AddUserLibraryQuery.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;

namespace Generita.Application.Users.Commands.AddBookToLibrary
{
    public record AddUserLibraryQuery(AddUserLibraryRequest GetUserLibraryRequest) : IQuery<AddUserLibrarayResponse>
    {
    }
}
```
## File: src\Generita.Application\Users\Commands\AddBookToLibrary\AddUserLibraryRequest.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Users.Commands.AddBookToLibrary
{
    public class AddUserLibraryRequest
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
```
## File: src\Generita.Application\Users\Commands\RemvoeBookFromLibrary\RemoveBookFromLibraryHandler.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Application.Users.Commands.AddBookToLibrary;
using Generita.Domain.Common.Interfaces;

namespace Generita.Application.Users.Commands.RemvoeBookFromLibrary
{
    internal class RemoveBookFromLibraryHandler : IQueryHandler<RemoveBookFromLibraryQuery, AddUserLibrarayResponse>
    {
        private IUserRepository _userRepository;
        private IBookRepository _bookRepository;
        private IUnitOfWork _unitOfWork;

        public RemoveBookFromLibraryHandler(IUserRepository userRepository, IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async  Task<ErrorOr<AddUserLibrarayResponse>> Handle(RemoveBookFromLibraryQuery request, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetById(request.addUserLibraryRequest.UserId) is null)
                return Error.NotFound();
            if (await _bookRepository.GetById(request.addUserLibraryRequest.BookId) is null)
                return Error.NotFound();
            await _userRepository.DeleteBookFromLibrary(request.addUserLibraryRequest.BookId, request.addUserLibraryRequest.UserId);
            await _unitOfWork.CommitAsync();
            var userbooks = await _userRepository.GetByIdWithBooks(request.addUserLibraryRequest.UserId);
            AddUserLibrarayResponse  res = new() { LibraryBookIds = userbooks.Select(x => x.BookId).ToList() };
            return res;
        }
    }
}
```
## File: src\Generita.Application\Users\Commands\RemvoeBookFromLibrary\RemoveBookFromLibraryQuery.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;
using Generita.Application.Users.Commands.AddBookToLibrary;

namespace Generita.Application.Users.Commands.RemvoeBookFromLibrary
{
    public record RemoveBookFromLibraryQuery(AddUserLibraryRequest addUserLibraryRequest):IQuery<AddUserLibrarayResponse>
    {
    }
}
```
## File: src\Generita.Application\Home\Query\HomeHandler.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Models;

namespace Generita.Application.Home.Query
{
    public class HomeHandler : IQueryHandler<HomeQuery, HomeResponse>
    {
        private IBookRepository _bookRepository;
        private IUserRepository _userRepository;
        private IAuthorRepository _authorRepository;
        private IBookCategoryRepository _bookCategoryRepository;

        public HomeHandler(IBookRepository bookRepository, IUserRepository userRepository, IAuthorRepository authorRepository, IBookCategoryRepository bookCategoryRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _authorRepository = authorRepository;
            _bookCategoryRepository = bookCategoryRepository;
        }

        public async Task<ErrorOr<HomeResponse>> Handle(HomeQuery request, CancellationToken cancellationToken)
        {
           var  bannerbooks =await _userRepository.GetPopularBooks();
            var featuredbooks = await _bookRepository.GetNewestBooks();
            var subsciptiononly = await _bookRepository.GetSubscriptionOnly();
            var freeonly=await _bookRepository.GetFreeOnly();
            var bannerhomebooks = new List<HomeBookDto>();

            foreach (var x in bannerbooks)
            {
                var author = await _authorRepository.GetById(x.Book.AuthorId);
                var category = await _bookCategoryRepository.GetById(x.Book.CategoryId);

                bannerhomebooks.Add(new HomeBookDto
                {
                    AuthorName = author.Name.firtName + " " + author.Name.LastName,
                    Title = x.Book.Title,
                    Access = x.Book.Access.ToString(),
                    CategoryName = category.CategoryName,
                    Cover = x.Book.Cover,
                    FilePath = x.Book.FilePath,
                    Id = x.Book.Id,
                    ImagePath = x.Book.ImagePath,
                    PublishedDate = x.Book.PublishedDate,
                    Synopsis = x.Book.Synopsis
                });
            }
            HomeResponse res = new HomeResponse()
            {
                BannerBook=bannerhomebooks,
                Featured=featuredbooks.Select(x=>
                {
                    return new HomeBookDto()
                    {
                        AuthorName = x.Author.Name.firtName + ' ' + x.Author.Name.LastName,
                        Title = x.Title,
                        Access = x.Access.ToString(),
                        CategoryName = x.BookCategory.CategoryName,
                        Cover = x.Cover,
                        FilePath = x.FilePath,
                        Id = x.Id,
                        ImagePath = x.ImagePath,
                        PublishedDate = x.PublishedDate,
                        Synopsis = x.Synopsis
                    };
                }).ToList(),
                SubscriptionOnly=subsciptiononly.Select(x=>
                {
                    return new HomeBookDto()
                    {
                        AuthorName = x.Author.Name.firtName + ' ' + x.Author.Name.LastName,
                        Title = x.Title,
                        Access = x.Access.ToString(),
                        CategoryName = x.BookCategory.CategoryName,
                        Cover = x.Cover,
                        FilePath = x.FilePath,
                        Id = x.Id,
                        ImagePath = x.ImagePath,
                        PublishedDate = x.PublishedDate,
                        Synopsis = x.Synopsis
                    };
                }).ToList(),
                FreeOnly=freeonly.Select(x=>
                {
                    return new HomeBookDto()
                    {
                        AuthorName = x.Author.Name.firtName + ' ' + x.Author.Name.LastName,
                        Title = x.Title,
                        Access = x.Access.ToString(),
                        CategoryName = x.BookCategory.CategoryName,
                        Cover = x.Cover,
                        FilePath = x.FilePath,
                        Id = x.Id,
                        ImagePath = x.ImagePath,
                        PublishedDate = x.PublishedDate,
                        Synopsis = x.Synopsis
                    };
                }).ToList(),
            };
            return res;
        }
    }
}
```
## File: src\Generita.Application\Home\Query\HomeQuery.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;

namespace Generita.Application.Home.Query
{
    public record HomeQuery:IQuery<HomeResponse>
    {
    }
}
```
## File: src\Generita.Application\Home\Query\HomeResponse.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Dtos;
using Generita.Domain.Models;

namespace Generita.Application.Home.Query
{
    public class HomeResponse
    {
        public ICollection<HomeBookDto> BannerBook { get; set; }
        public ICollection<HomeBookDto> Featured {  get; set; }
        public ICollection<HomeBookDto> SubscriptionOnly { get; set; }
        public ICollection<HomeBookDto> FreeOnly { get; set; }
    }
}
```
## File: src\Generita.Application\Common\Behaviors\ValidationPipelineBehavior.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using FluentValidation;

using MediatR;

namespace Generita.Application.Common.Behaviors
{
    internal class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<ErrorOr<TResponse>>
        where TResponse : class
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var failures = _validators
                    .Select(v => v.Validate(context))
                    .SelectMany(result => result.Errors)
                    .Where(f => f != null)
                    .ToList();

                if (failures.Count != 0)
                    throw new ValidationException(failures);
            }

            return await next(cancellationToken);
        }
    }
}
```
## File: src\Generita.Application\Common\Dtos\AddBookDto.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Books.Commands.AddBook;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Common.Enums;
using Generita.Domain.Models;

namespace Generita.Application.Dtos
{
    public class AddBookDto 
    {
        public string Title { get; set; }
        public DateOnly PublishedDate { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public string Synopsis { get; set; }
        public string Cover { get; set; }
        public BookAccess Subscription { get; set; }
        public string FilePath { get; set; }
        public string ImagePath { get; set; }
    }
}
```
## File: src\Generita.Application\Common\Dtos\AddTolibraryControllerDto.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Common.Dtos
{
    public class AddTolibraryControllerDto
    {
        public Guid bookId {  get; set; }
    }

}
```
## File: src\Generita.Application\Common\Dtos\AudioTagsDto.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Common.Dtos
{
    public class AudioTagsDto
    {
        public string Age { get; set; }
        public string Sense { get; set;}
    }

}
```
## File: src\Generita.Application\Common\Dtos\AudioTagsResponse.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Common.Dtos
{
    public class AudioTagsResponse
    {
        public string Url { get; set; }
    }
}
```
## File: src\Generita.Application\Common\Dtos\BannerBookDto.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Enums;
using Generita.Domain.Models;

namespace Generita.Application.Common.Dtos
{
    public class BannerBookDto
    {
          public int UserCount {  get; set; }
        public Book Book { get; set; }
    }
}
```
## File: src\Generita.Application\Common\Dtos\EntitiesDto.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Common.Dtos
{
    public class EntitiesDto
    {
        public string Type { get; set; }    
        public string Sample { get; set; }
        public int Start_pos { get; set; }
    }
}
```
## File: src\Generita.Application\Common\Dtos\EntityDto.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Dtos
{
    //this will have entity name , desc , addiction to music that is optional and will chose from defaults if its null
    internal class EntityDto
    {
    }
}
```
## File: src\Generita.Application\Common\Dtos\GetAudioTagsDto.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Common.Dtos
{
    public class GetAudioTagsDto
    {
        public  string Age { get; set; }
        public string Sense {  get; set; }
    }
}
```
## File: src\Generita.Application\Common\Dtos\GetBookDto.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.ValueObjects;

namespace Generita.Application.Dtos
{
    public class GetBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }  
        public string Cover { get; set; }
        public string synopsis { get; set; }
        public string access { get; set; }
    }
}
```
## File: src\Generita.Application\Common\Dtos\HomeBookDto.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Enums;
using Generita.Domain.Models;

namespace Generita.Application.Common.Dtos
{
    public class HomeBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateOnly PublishedDate { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public string Synopsis { get; set; }
        public string Cover { get; set; }
        public string Access { get; set; }
        public string FilePath { get; set; }
        public string ImagePath { get; set; }
    }
}
```
## File: src\Generita.Application\Common\Dtos\LoginDto.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Dtos
{
    public class LoginDto
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
```
## File: src\Generita.Application\Common\Dtos\ParagraphDto.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Common.Dtos
{
    public class ParagraphDto
    {
        public string Text { get; set; }
        public AudioTagsDto AudioTags { get; set; }
        public ICollection<EntitiesDto> Entities { get; set; }
    }
}
```
## File: src\Generita.Application\Common\Dtos\RefreshDto.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Dtos
{
    public class RefreshDto
    {
        public string refreshToken {  get; set; }
    }
}
```
## File: src\Generita.Application\Common\Dtos\RegisterDto.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Dtos
{
    public class RegisterDto
    {
        public string name {  get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
```
## File: src\Generita.Application\Common\Dtos\RegisterResponse.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Dtos
{
    public class RegisterResponse
    {
        public string Message {  get; set; }
    }
}
```
## File: src\Generita.Application\Common\Dtos\SearchBookDto.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Books.Queries.SearchBook;

namespace Generita.Application.Common.Dtos
{
    public class SearchBookDto
    {
        public SearchMode SearchMode { get; set; }
        public SearchResultOrder Order { get; set; }
        public DateOnly PublishedDate { get; set; }
    }
}
```
## File: src\Generita.Application\Common\Interfaces\IPasswordHasher.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

namespace Generita.Application.Common.Interfaces
{
    public interface IPasswordHasher
    {
        public ErrorOr<string> HashPassword(string password);
        bool IsCorrectPassword(string password, string hash);
    }
}
```
## File: src\Generita.Application\Common\Interfaces\ITokenGenerator.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
        string RefreshToken();

    }
}
```
## File: src\Generita.Application\Common\Messaging\ICommand.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using MediatR;

namespace Generita.Application.Common.Messaging
{
    interface ICommand:IRequest<ErrorOr<Success>>
    {
    }
    interface ICommand<TResponse>:IRequest<ErrorOr<TResponse>>;
}
```
## File: src\Generita.Application\Common\Messaging\ICommandHandler.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using MediatR;

namespace Generita.Application.Common.Messaging
{
    internal interface ICommandHandler<TRequest>:IRequestHandler<TRequest,ErrorOr<Success>>
        where TRequest: IRequest<ErrorOr<Success>>
    {
    }
    internal interface ICommandHandler<TRequest,TResponse>:IRequestHandler<TRequest,ErrorOr<TResponse>>
        where TRequest:IRequest<ErrorOr<TResponse>>
    { }
}
```
## File: src\Generita.Application\Common\Messaging\IQuery.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using MediatR;

namespace Generita.Application.Common.Messaging
{
    public interface IQuery<TResponse>:IRequest<ErrorOr<TResponse>>
    {
    }
}
```
## File: src\Generita.Application\Common\Messaging\IQueryHandler.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using MediatR;

namespace Generita.Application.Common.Messaging
{
    public interface IQueryHandler<TRequest, TResponse>
        : IRequestHandler<TRequest, ErrorOr<TResponse>>
        where TRequest : IRequest<ErrorOr<TResponse>>
    {
    }
}
```
## File: src\Generita.Application\Common\Interfaces\Repository\IAuthorRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<Author?> GetByAuthorName(string authorName);
    }
}
```
## File: src\Generita.Application\Common\Interfaces\Repository\IBookCategoryRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IBookCategoryRepository : IGenericRepository<BookCategory>
    {
        public Task<ICollection<BookCategory>> GetByName(string name);
    }
}
```
## File: src\Generita.Application\Common\Interfaces\Repository\IBookRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Dtos;
using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IBookRepository :IGenericRepository<Book>
    {
        Task<ICollection<Book>> SearchBook(string bookName);
        public Task<Dictionary<Guid, int>> GetLikesNumber(IEnumerable<Guid> bookIds);
        Task<ICollection<Book>> GetByPublishedDate(DateOnly dateOnly);
        Task<ICollection<Book>> GetNewestBooks();
        Task<ICollection<Book>> GetSubscriptionOnly();
        Task<ICollection<Book>> GetFreeOnly();
    }
}
```
## File: src\Generita.Application\Common\Interfaces\Repository\IEntityRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IEntityRepository:IGenericRepository<Entity>
    {
        Task<Entity> GetByType(string type);
        Task<Entity> GetEntityByBookId(int bookId);
    }
}
```
## File: src\Generita.Application\Common\Interfaces\Repository\IGenericRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IGenericRepository<T>
     where T : class
    {
        Task Add(T value);
        Task<bool> Delete(Guid id);
        Task<bool> Update(T value);
        Task<ICollection<T>> GetAll();
        Task<T> GetById(Guid id);

    }
}
```
## File: src\Generita.Application\Common\Interfaces\Repository\IParagraphRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Enums;
using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IParagraphRepository : IGenericRepository<Paragraph>
    {
        Task<ICollection<Paragraph>> GetByBookId(Guid bookId);
        Task<Paragraph> GetBySenseAndAge(MusicSense sense, AgeClasses age);
    }
}
```
## File: src\Generita.Application\Common\Interfaces\Repository\IPlansRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IPlansRepository:IGenericRepository<Plans>
    {
        Task<Plans> GetPlanByName(string name);
    }
}
```
## File: src\Generita.Application\Common\Interfaces\Repository\IRefreshTokenRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IRefreshTokenRepository:IGenericRepository<RefreshTokens>
    {
        public Task<RefreshTokens> GetByToken(string token);
    }
}
```
## File: src\Generita.Application\Common\Interfaces\Repository\ISongCategoryRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface ISongCategoryRepository:IGenericRepository<SongCategory>
    {
    }
}
```
## File: src\Generita.Application\Common\Interfaces\Repository\ISongRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface ISongRepository:IGenericRepository<Songs>
    {
    }
}
```
## File: src\Generita.Application\Common\Interfaces\Repository\ITransactionsRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface ITransactionsRepository : IGenericRepository<Transactions>
    {
        Task<Transactions> GetByUserId(Guid userId);
    }
}
```
## File: src\Generita.Application\Common\Interfaces\Repository\IUserRepository.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Dtos;
using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task AddBookToLibrary(UserBook userbook);
        Task<bool> DeleteBookFromLibrary(Guid bookId, Guid UserId);
        Task<ICollection<UserBook>> GetByIdWithBooks(Guid id);
        Task<ICollection<BannerBookDto>> GetPopularBooks();
        Task<User> GetUserByEmail(string email);
        Task<bool> IsExistsByEmail(string email);
    }
}
```
## File: src\Generita.Application\Books\Queries\GetBookById\GetBookByIdHandler.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Application.Dtos;

using Microsoft.IdentityModel.Tokens;

namespace Generita.Application.Books.Queries.GetBookById
{
    internal class GetBookByIdHandler : IQueryHandler<GetBookByIdQuery, GetBookDto>
    {
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;
        private IBookCategoryRepository _bookCategoryRepository;

        public GetBookByIdHandler(IBookRepository bookRepository, IAuthorRepository authorRepository, IBookCategoryRepository bookCategoryRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _bookCategoryRepository = bookCategoryRepository;
        }

        public async Task<ErrorOr<GetBookDto>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book =await _bookRepository.GetById(request.Id);
            if (book is null)
            {
                return Error.NotFound("404NotFound", "Book with these id isnt found");
            }
            var author=await _authorRepository.GetById(book.AuthorId);
            var bookcategory=await _bookCategoryRepository.GetById(book.CategoryId);
            var res = new GetBookDto()
            {
                Id = book.Id,
                Title = book.Title,
                Author = author.Name.firtName+' '+author.Name.LastName,
                synopsis = book.Synopsis,
                Category = bookcategory.CategoryName,
                Cover=book.Cover,
                access=book.Access.ToString(),
            };
            return res;
        }
    }
}
```
## File: src\Generita.Application\Books\Queries\GetBookById\GetBookByIdQuery.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;
using Generita.Application.Dtos;

namespace Generita.Application.Books.Queries.GetBookById
{
    public record GetBookByIdQuery(Guid Id):IQuery<GetBookDto>
    {
    }
}
```
## File: src\Generita.Application\Books\Queries\GetBookContent\BookConentResponse.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Dtos;

namespace Generita.Application.Books.Queries.GetBookContent
{
    public class BookConentResponse
    {
        public string Title { get; set; }
        public ICollection<ParagraphDto> Paragraphs { get; set; }
    }
}
```
## File: src\Generita.Application\Books\Queries\GetBookContent\GetBookByContentHandler.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Common.Interfaces;

namespace Generita.Application.Books.Queries.GetBookContent
{
    internal class GetBookByContentHandler : IQueryHandler<GetBookByContentQuery, BookConentResponse>
    {
        private IBookRepository _bookRepository;
        private IParagraphRepository _paragraphRepository;
        private IEntityRepository _entityRepository;
        private IUnitOfWork _unitOfWork;

        public GetBookByContentHandler(IBookRepository bookRepository, IParagraphRepository paragraphRepository, IEntityRepository entityRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _paragraphRepository = paragraphRepository;
            _entityRepository = entityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<BookConentResponse>> Handle(GetBookByContentQuery request, CancellationToken cancellationToken)
        {
            var book =await _bookRepository.GetById(request.bookId);
            var paragraphs = await _paragraphRepository.GetByBookId(request.bookId);
            var result = new BookConentResponse()
            {
                Title = book.Title,
                Paragraphs = paragraphs.Select(paragraph =>
                    new ParagraphDto()
                    {
                        AudioTags = new AudioTagsDto
                        {
                            Age = paragraph.AgeClass.ToString(),
                            Sense = paragraph.MusicSense.ToString()
                        },
                        Text = paragraph.Text,
                        Entities = paragraph.Entities.Select(entity => new EntitiesDto
                        {
                            Sample = entity.sample,
                            Start_pos = entity.Position,
                            Type = entity.type
                        }).ToList()
                    }
                ).ToList()
            };

            return result;



        }
    }
}
```
## File: src\Generita.Application\Books\Queries\GetBookContent\GetBookByContentQuery.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;

using MediatR;

namespace Generita.Application.Books.Queries.GetBookContent
{
    public record GetBookByContentQuery(Guid bookId):IQuery<BookConentResponse>
    {
    }
}
```
## File: src\Generita.Application\Books\Queries\GetBookContent\GetBookContentValidator.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace Generita.Application.Books.Queries.GetBookContent
{
    internal class GetBookContentValidator:AbstractValidator<GetBookByContentQuery>
    {
        public GetBookContentValidator()
        {
            RuleFor(x=>x.bookId).NotEmpty();
        }
    }
}
```
## File: src\Generita.Application\Books\Queries\SearchBook\SearchBookHandler.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Application.Dtos;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore.Metadata;

namespace Generita.Application.Books.Queries.SearchBook
{
    public class SearchBookHandler : IQueryHandler<SearchBookQuery, ICollection<GetBookDto>>
    {
        private IBookCategoryRepository _categoryRepository;
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;

        public SearchBookHandler(IBookCategoryRepository categoryRepository, IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public async Task<ErrorOr<ICollection<GetBookDto>>> Handle(SearchBookQuery request, CancellationToken cancellationToken)
        {
            if (request.BookRequest.SearchMode == SearchMode.ByTitle)
            {
                var books = await _bookRepository.SearchBook(request.BookRequest.Name);
                if (!books.Any())
                {
                    return Array.Empty<GetBookDto>();
                }
                var likes=await _bookRepository.GetLikesNumber(books.Select(x=>x.Id));
                books = request.BookRequest.Order switch
                {
                    SearchResultOrder.ByOldest => books.OrderBy(b => b.PublishedDate).ToList(),
                    SearchResultOrder.ByNewest => books.OrderByDescending(b => b.PublishedDate).ToList(),
                    SearchResultOrder.MostLikes => [.. books.OrderByDescending(b => likes.TryGetValue(b.Id, out var likeCount) ? likeCount : 0)],
                    SearchResultOrder.Random => books.OrderBy(_ => Guid.NewGuid()).ToList(),
                    _ => books
                };
                var result = await Task.WhenAll(
                    books.Select(async book =>
                    {
                        var author = await _authorRepository.GetById(book.AuthorId);
                        //var category = await _categoryRepository.GetById(book.CategoryId);
                        return new GetBookDto()
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Author = author.Name.firtName + ' ' + author.Name.LastName,
                            Cover = book.Cover,
                            access = book.Access.ToString(),
                        };
                    }
                    ));
                return result;

            }
            else if (request.BookRequest.SearchMode == SearchMode.ByCategory)
            {
                var catbooks = await _categoryRepository.GetByName(request.BookRequest.Name);
                var books = catbooks.SelectMany(x=>x.Books).ToList();
                var likes = await _bookRepository.GetLikesNumber(books.Select(x => x.Id));
                books = request.BookRequest.Order switch
                {
                    SearchResultOrder.ByOldest => books.OrderBy(b => b.PublishedDate).ToList(),
                    SearchResultOrder.ByNewest => books.OrderByDescending(b => b.PublishedDate).ToList(),
                    SearchResultOrder.MostLikes => [.. books.OrderByDescending(b => likes.TryGetValue(b.Id, out var likeCount) ? likeCount : 0)],
                    SearchResultOrder.Random => books.OrderBy(_ => Guid.NewGuid()).ToList(),
                    _ => books
                };
                var result = await Task.WhenAll(
                    books.Select(async book =>
                    {
                        var author = await _authorRepository.GetById(book.AuthorId);
                        return new GetBookDto()
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Author = author.Name.firtName + ' ' + author.Name.LastName,
                            Cover = book.Cover,
                            access = book.Access.ToString()
                        };

                    }));
                return result;
            }
            else if(request.BookRequest.SearchMode==SearchMode.ByAuthorName)
            {
                var authors = await _authorRepository.GetByAuthorName(request.BookRequest.Name);
                var books = authors.Books;
                var likes = await _bookRepository.GetLikesNumber(books.Select(x => x.Id));
                books = request.BookRequest.Order switch
                {
                    SearchResultOrder.ByOldest => books.OrderBy(b => b.PublishedDate).ToList(),
                    SearchResultOrder.ByNewest => books.OrderByDescending(b => b.PublishedDate).ToList(),
                    SearchResultOrder.MostLikes => [.. books.OrderByDescending(b => likes.TryGetValue(b.Id, out var likeCount) ? likeCount : 0)],
                    SearchResultOrder.Random => books.OrderBy(_ => Guid.NewGuid()).ToList(),
                    _ => books
                };
                var result = await Task.WhenAll((
                    books.Select(async book =>
                    {
                        return new GetBookDto()
                        {
                            Author = authors.Name.firtName + ' ' + authors.Name.LastName,
                            Title = book.Title,
                            Cover = book.Cover,
                            access = book.Access.ToString(),
                        };

                    })));
                return result;
            }
            else if (request.BookRequest.SearchMode == SearchMode.ByPublishedDate)
            {
                var books = await _bookRepository.GetByPublishedDate(request.BookRequest.PublishedDate);
                var likes = await _bookRepository.GetLikesNumber(books.Select(x => x.Id));
                books = request.BookRequest.Order switch
                {
                    SearchResultOrder.ByOldest => books.OrderBy(b => b.PublishedDate).ToList(),
                    SearchResultOrder.ByNewest => books.OrderByDescending(b => b.PublishedDate).ToList(),
                    SearchResultOrder.MostLikes => [.. books.OrderByDescending(b => likes.TryGetValue(b.Id, out var likeCount) ? likeCount : 0)],
                    SearchResultOrder.Random => books.OrderBy(_ => Guid.NewGuid()).ToList(),
                    _ => books
                };
                var result = await Task.WhenAll((
                    books.Select(async book =>
                    {
                        return new GetBookDto()
                        {
                            Author = book.Author.Name.firtName + ' ' + book.Author.Name.LastName,
                            Title = book.Title,
                            Cover = book.Cover,
                            access = book.Access.ToString(),
                        };

                    })));
                return result;
            }
            return Error.NotFound(description: "SearchMode is invalid");
        }
    }
}
```
## File: src\Generita.Application\Books\Queries\SearchBook\SearchBookQuery.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;
using Generita.Application.Dtos;
using Generita.Domain.Models;

namespace Generita.Application.Books.Queries.SearchBook
{
    public record SearchBookQuery(SearchBookRequest BookRequest) : IQuery<ICollection<GetBookDto>>
    {
    }
}
```
## File: src\Generita.Application\Books\Queries\SearchBook\SearchBookRequest.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Books.Queries.SearchBook
{
    public class SearchBookRequest
    {
        public string Name { get; set; }
        public DateOnly PublishedDate { get; set; }
        public SearchMode SearchMode { get; set; }
        public SearchResultOrder Order { get; set; }
    }
}
```
## File: src\Generita.Application\Books\Queries\SearchBook\SearchBookValidator.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace Generita.Application.Books.Queries.SearchBook
{
    internal class SearchBookValidator:AbstractValidator<SearchBookQuery>
    {
        public SearchBookValidator()
        {
            RuleFor(x => (int)x.BookRequest.Order)
                .InclusiveBetween(0, 4).NotEmpty();
            RuleFor(x=>(int)x.BookRequest.SearchMode)
                .InclusiveBetween(0,3).NotEmpty();
            RuleFor(x => x)
                .Must(x => !string.IsNullOrWhiteSpace(x.BookRequest.Name) || x.BookRequest.PublishedDate != DateOnly.MinValue)
                .WithMessage("Either Name or Date must be provided.");
            

        }
    }
}
```
## File: src\Generita.Application\Books\Queries\SearchBook\SearchMode.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Books.Queries.SearchBook
{
    public enum SearchMode
    {
        ByPublishedDate,
        ByTitle,
        ByAuthorName,
        ByCategory,
    }
}
```
## File: src\Generita.Application\Books\Queries\SearchBook\SearchResultOrder.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Books.Queries.SearchBook
{
    public enum SearchResultOrder
    {
        ByOldest,
        ByNewest,
        Random,
        MostLikes,
        MostUsersHave,

    }
}
```
## File: src\Generita.Application\Books\Commands\AddBook\AddBookCommand.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Generita.Application.Dtos;

namespace Generita.Application.Books.Commands.AddBook
{
    public record AddBookCommand(AddBookDto AddBookDto):Application.Common.Messaging.ICommand
    {
    }
}
```
## File: src\Generita.Application\Books\Commands\AddBook\AddBookHandler.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Models;

namespace Generita.Application.Books.Commands.AddBook
{
    public class AddBookHandler : ICommandHandler<AddBookCommand>
    {
        private IBookRepository _bookRepository;

        public AddBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ErrorOr<Success>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(Guid.NewGuid())
            {
                Title = request.AddBookDto.Title,
                Synopsis = request.AddBookDto.Synopsis,
                PublishedDate = request.AddBookDto.PublishedDate,
                AuthorId = request.AddBookDto.AuthorId,
                Cover = request.AddBookDto.Cover,
                FilePath = request.AddBookDto.FilePath,
                ImagePath = request.AddBookDto.ImagePath,
                CategoryId = request.AddBookDto.CategoryId,
                Access = request.AddBookDto.Subscription,
            };
            await _bookRepository.Add(book);
            return Result.Success;

        }
    }
}
```
## File: src\Generita.Application\Books\Commands\RemoveBook\RemoveBookCommand.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;

namespace Generita.Application.Books.Commands.RemoveBook
{
    public record RemoveBookCommand(Guid Id):ICommand
    {
    }
}
```
## File: src\Generita.Application\Books\Commands\RemoveBook\RemoveBookHandler.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Books.Commands.RemoveBook
{
    public class RemoveBookHandler : ICommandHandler<RemoveBookCommand>
    {
        private IBookRepository _bookRepository;

        public RemoveBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ErrorOr<Success>> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _bookRepository.Delete(request.Id);
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Error.Failure(description:ex.Message);
            }


        }
    }
}
```
## File: src\Generita.Application\Books\Commands\UpdateBook\UpdateBookCommand.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Books.Commands.UpdateBook
{
    public record UpdateBookCommand(Book books):Application.Common.Messaging.ICommand
    {
    }
}
```
## File: src\Generita.Application\Books\Commands\UpdateBook\UpdateBookHandler.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Books.Commands.UpdateBook
{
    public class UpdateBookHandler : ICommandHandler<UpdateBookCommand>
    {
        private IBookRepository _bookRepository;

        public UpdateBookHandler(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        public async Task<ErrorOr<Success>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _bookRepository.Update(request.books);
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Error.Failure("UpdateFails",ex.Message);
            }

        }
    }
}
```
## File: src\Generita.Application\Authentication\Login\LoginCommand.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Generita.Application.Common.Messaging;
using Generita.Application.Dtos;

namespace Generita.Application.Authentication.Login
{
    public record LoginCommand(LoginDto LoginDto) :ICommand<LoginResponse>
    {
    }
}
```
## File: src\Generita.Application\Authentication\Login\LoginHandler.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Common.Interfaces;
using Generita.Domain.Models;

namespace Generita.Application.Authentication.Login
{
    internal class LoginHandler : ICommandHandler<LoginCommand, LoginResponse>
    {
        private IUserRepository _userRepository;
        private IPasswordHasher _passwordHasher;
        private ITokenGenerator _tokenGenerator;
        private IUnitOfWork _unitOfWork;
        private IRefreshTokenRepository _refreshTokenRepository;

        public LoginHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenGenerator tokenGenerator, IUnitOfWork unitOfWork, IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
            _unitOfWork = unitOfWork;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async  Task<ErrorOr<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (!await _userRepository.IsExistsByEmail(request.LoginDto.email))
            {
                return Error.Unauthorized(description: "Email Doesn't Exists");
            }
            var user=await _userRepository.GetUserByEmail(request.LoginDto.email);
            if(!_passwordHasher.IsCorrectPassword(request.LoginDto.password,user.Password))
            {
                return Error.Conflict(description: "Password is incorrect");
            }
            var token = _tokenGenerator.GenerateToken(user);
            var refreshtoken = _tokenGenerator.RefreshToken();
            RefreshTokens rtmodel = new(Guid.NewGuid())
            {
                ExpiresOnUtc = DateTime.UtcNow.AddDays(7),
                UserId = user.Id,
                Token = refreshtoken,
            };
            await _refreshTokenRepository.Add(rtmodel);
            await _unitOfWork.CommitAsync();
            return new LoginResponse() { accessToken=token,refreshToken=refreshtoken} ;

        }
    }
}
```
## File: src\Generita.Application\Authentication\Login\LoginResponse.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32.SafeHandles;

namespace Generita.Application.Authentication.Login
{
    public class LoginResponse
    {
        public string accessToken {get;set;}
        public string refreshToken { get;set;}

    }
}
```
## File: src\Generita.Application\Authentication\Me\MeCommand.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;

namespace Generita.Application.Authentication.Me
{
    public record MeCommand(Guid Id):ICommand<MeResponse>
    {
    }
}
```
## File: src\Generita.Application\Authentication\Me\MeHandler.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Authentication.Refresh;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Common.Interfaces;

using MediatR;

namespace Generita.Application.Authentication.Me
{
    public class MeHandler : ICommandHandler<MeCommand, MeResponse>
    {
        private IUserRepository _userRepository;
        private IBookRepository _bookRepository;
        private IUnitOfWork _unitOfWork;
        private ITransactionsRepository _transactionsRepository;

        public MeHandler(IUserRepository userRepository, IBookRepository bookRepository, IUnitOfWork unitOfWork, ITransactionsRepository transactionsRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _transactionsRepository = transactionsRepository;
        }
        public async Task<ErrorOr<MeResponse>> Handle(MeCommand request, CancellationToken cancellationToken)
        {
            var userbook = await _userRepository.GetByIdWithBooks(request.Id);
            var user = await _userRepository.GetById(request.Id);
            if (user == null)
            {
                return Error.NotFound(description: "user with these information doesn't found");
            }
            var trans = await _transactionsRepository.GetByUserId(request.Id);
            string Subscriptionstatus;
            if (trans is not null)
            {

                if (trans.CreateAt.AddDays(trans.Plan.Duration) > DateTime.UtcNow)
                    Subscriptionstatus = "InActive";
                else
                    Subscriptionstatus = "Active";
                MeResponseSubscription MeResponseSubscription = new() { status = Subscriptionstatus, ExpiryDate = DateOnly.FromDateTime(trans.CreateAt.AddDays(trans.Plan.Duration)) };
                MeResponse res = new()
                {
                    Id = request.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Subscription = MeResponseSubscription,
                    LibraryBookIds = userbook.Select(x => x.BookId).ToList(),
                };
                return res;
            }
            else
            {
                MeResponse res = new()
                {
                    Id = request.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Subscription = null,
                    LibraryBookIds = userbook.Select(x => x.BookId).ToList(),
                };
            return res;
            }
        }


    }
}
```
## File: src\Generita.Application\Authentication\Me\MeResponse.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Authentication.Me
{
    public class MeResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public MeResponseSubscription? Subscription { get; set; }
        public ICollection<Guid> LibraryBookIds { get; set; }
    }
}
```
## File: src\Generita.Application\Authentication\Me\MeResponseSubscription.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Authentication.Me
{
    public class MeResponseSubscription
    {
        public string status { get; set; }
        public DateOnly ExpiryDate { get; set; }
    }
}
```
## File: src\Generita.Application\Authentication\Refresh\RefreshCommand.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Generita.Application.Common.Messaging;

namespace Generita.Application.Authentication.Refresh
{
    public record RefreshCommand(RefreshRequest refreshRequest):ICommand<RefreshResponse>
    {
    }
}
```
## File: src\Generita.Application\Authentication\Refresh\RefreshHandler.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Authentication.Refresh
{
    public class RefreshHandler : ICommandHandler<RefreshCommand, RefreshResponse>
    {
        private IRefreshTokenRepository _refreshRepository;
        private ITokenGenerator _tokenGenerator;
        private IUserRepository _userRepository;

        public RefreshHandler(IRefreshTokenRepository refreshRepository, ITokenGenerator tokenGenerator, IUserRepository userRepository)
        {
            _refreshRepository = refreshRepository;
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<RefreshResponse>> Handle(RefreshCommand request, CancellationToken cancellationToken)
        {
            var savedtoken =await  _refreshRepository.GetByToken(request.refreshRequest.refreshToken);
            if (savedtoken == null || savedtoken.ExpiresOnUtc < DateTime.UtcNow)
            {
                return Error.Unauthorized(description: "Refresh Token is invalid");
            }
            var  user =await _userRepository.GetById(savedtoken.UserId);
            if (user == null)
            {
                return Error.Unauthorized(description: "User Not found");
            }
            var newtoken=_tokenGenerator.GenerateToken(user);
            return new RefreshResponse() { accessToken = newtoken };

        }
    }
}
```
## File: src\Generita.Application\Authentication\Refresh\RefreshRequest.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Authentication.Refresh
{
    public class RefreshRequest
    {
        public string refreshToken { get; set; }
    }
}
```
## File: src\Generita.Application\Authentication\Refresh\RefreshResponse.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Authentication.Refresh
{
    public class RefreshResponse
    {
        public string accessToken { get; set; }
    }
}
```
## File: src\Generita.Application\Authentication\Register\RegisterCommand.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;
using Generita.Application.Dtos;

namespace Generita.Application.Authentication.Register
{
    public record RegisterCommand(RegisterDto registerDto):ICommand<RegisterResponse>
    {
    }
}
```
## File: src\Generita.Application\Authentication\Register\RegisterCommandValidator.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using FluentValidation;

namespace Generita.Application.Authentication.Register
{
    public  partial  class RegisterCommandValidator:AbstractValidator<RegisterCommand>
    {
        private static readonly Regex StrongPasswordRegex = new Regex(
            "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            RegexOptions.Compiled);
        public RegisterCommandValidator()
        {
            RuleFor(x=>x.registerDto.email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.registerDto.password)
                .NotEmpty()
                .Matches(StrongPasswordRegex)
                .WithMessage("Password must be at least 8 characters, contain uppercase, lowercase, number and special character.");


            RuleFor(x => x.registerDto.name)
                .NotEmpty()
                .MinimumLength(50);

        }
    }
}
```
## File: src\Generita.Application\Authentication\Register\RegisterHandler.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Application.Dtos;
using Generita.Domain.Common.Interfaces;
using Generita.Domain.Models;

namespace Generita.Application.Authentication.Register
{
    internal class RegisterHandler : ICommandHandler<RegisterCommand, RegisterResponse>
    {
        private ITokenGenerator _tokenGenerator;
        private IUserRepository _userRepository;
        private IPasswordHasher _passwordHasher;
        private IUnitOfWork _unitOfWork;
        public RegisterHandler(ITokenGenerator tokenGenerator, IUserRepository userRepository, IPasswordHasher passwordHasher, IUnitOfWork unitOfWork)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.IsExistsByEmail(request.registerDto.email))
                return Error.Conflict(description: "Email Exists!");
            var hashedpassword = _passwordHasher.HashPassword(request.registerDto.password);
            if(hashedpassword.IsError)
                return Error.Failure(description:hashedpassword.FirstError.Description);
            //maybe change that in future
            var user = new User(Guid.NewGuid())
            {
                Password = hashedpassword.Value,
                Email = request.registerDto.email,
                CreateAt = DateTime.UtcNow,
                UpdateAt=DateTime.UtcNow,
                Name=request.registerDto.name,
            };
            await _userRepository.Add(user);
            await _unitOfWork.CommitAsync(cancellationToken);
            var registereduser =await _userRepository.GetUserByEmail(request.registerDto.email);
            var token = _tokenGenerator.GenerateToken(registereduser);
            return new RegisterResponse() { Message=token};

        }
    }
}
```
## File: src\Generita.Application\Audios\Queries\GetEntityAudioTags\GetEntityAudioHandler.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Audios.Queries.GetEntityAudioTags
{
    public class GetEntityAudioHandler : IQueryHandler<GetEntityAudioQuery, AudioTagsResponse>
    {
        private IEntityRepository _entityRepository;

        public GetEntityAudioHandler(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<ErrorOr<AudioTagsResponse>> Handle(GetEntityAudioQuery request, CancellationToken cancellationToken)
        {
            var entity = await _entityRepository.GetByType(request.type);
            if (entity is null)
                return Error.NotFound(description: "Entity Type Doesn't Found");
            var res = new AudioTagsResponse()
            { Url=entity.Songs.FilePath};
            return res;
        }
    }
}
```
## File: src\Generita.Application\Audios\Queries\GetEntityAudioTags\GetEntityAudioQuery.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Audios.Queries.GetParagraphAudioTags;
using Generita.Application.Common.Dtos;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Audios.Queries.GetEntityAudioTags
{
    public record GetEntityAudioQuery(string type):IQuery<AudioTagsResponse>
    {
    }
}
```
## File: src\Generita.Application\Audios\Queries\GetEntityAudioTags\GetEntityAudioValidator.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace Generita.Application.Audios.Queries.GetEntityAudioTags
{
    internal class GetEntityAudioValidator:AbstractValidator<GetEntityAudioQuery>
       
    {
        public GetEntityAudioValidator()
        {
            RuleFor(x=>x.type).NotEmpty();
        }
    }
}
```
## File: src\Generita.Application\Audios\Queries\GetParagraphAudioTags\AudioTagsRequest.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Audios.Queries.GetParagraphAudioTags
{
    public class AudioTagsRequest
    {
        public string Age {  get; set; }
        public string Sense {  get; set; }
    }
}
```
## File: src\Generita.Application\Audios\Queries\GetParagraphAudioTags\GetAudioTagsHandler.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Common.Enums;

namespace Generita.Application.Audios.Queries.GetParagraphAudioTags
{
    public class GetAudioTagsHandler : IQueryHandler<GetAudioTagsQuery, AudioTagsResponse>
    {
        private IParagraphRepository _paragraphRepository;
        private ISongRepository _songRepository;

        public GetAudioTagsHandler(IParagraphRepository paragraphRepository, ISongRepository songRepository)
        {
            _paragraphRepository = paragraphRepository;
            _songRepository = songRepository;
        }

        public async Task<ErrorOr<AudioTagsResponse>> Handle(GetAudioTagsQuery request, CancellationToken cancellationToken)
        {
            AgeClasses age =(AgeClasses) Enum.Parse(typeof(AgeClasses), request.AudioTagsRequest.Age);
            MusicSense sense=(MusicSense) Enum.Parse(typeof(MusicSense), request.AudioTagsRequest.Sense);
            var res=await _paragraphRepository.GetBySenseAndAge(sense,age);
            if (res is null)
                return Error.NotFound(description: "Age Or Sense doesn't found");
            AudioTagsResponse response= new AudioTagsResponse() { Url=res.Songs.FilePath };
            return response;

        }
    }
}
```
## File: src\Generita.Application\Audios\Queries\GetParagraphAudioTags\GetAudioTagsQuery.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Audios.Queries.GetParagraphAudioTags
{
    public record GetAudioTagsQuery(AudioTagsRequest AudioTagsRequest):IQuery<AudioTagsResponse >
    {
    }
}
```
## File: src\Generita.Application\Audios\Queries\GetParagraphAudioTags\GetAudioTagValidator.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

using Generita.Application.Books.Queries.SearchBook;
using Generita.Domain.Common.Enums;

namespace Generita.Application.Audios.Queries.GetParagraphAudioTags
{
    internal class GetAudioTagValidator:AbstractValidator<GetAudioTagsQuery>
    {
        public GetAudioTagValidator()
        {

            RuleFor(x => x.AudioTagsRequest.Age)
                .Must(value => Enum.TryParse<AgeClasses>(value, true, out var result)
                               && Enum.IsDefined(typeof(AgeClasses), result))
                .WithMessage("Invalid order value.");
            RuleFor(x => x.AudioTagsRequest.Age)
                .Must(value => Enum.TryParse<AgeClasses>(value, true, out var result)
                               && Enum.IsDefined(typeof(AgeClasses), result))
                .WithMessage("Invalid order value.");

        }
    }
}
```
## File: src\Generita.Api\Controllers\ApiController.cs
```csharp
﻿using ErrorOr;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generita.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            var firstError = errors.First();

            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(
                statusCode: statusCode,
                title: firstError.Code,
                detail: firstError.Description);
        }
    }
}
```
## File: src\Generita.Api\Controllers\AudioController.cs
```csharp
﻿using Generita.Application.Audios.Queries.GetEntityAudioTags;
using Generita.Application.Audios.Queries.GetParagraphAudioTags;
using Generita.Application.Common.Dtos;

using MediatR;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Generita.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AudioController:ApiController
    {
        private IMediator _mediator;

        public AudioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Audio/tags")]
        public async Task<IActionResult> GetAudioTags([FromQuery] string age, [FromQuery] string sense)
        {
            AudioTagsRequest model = new()
            {
                Age=age,
                Sense=sense
            };
            var query = new GetAudioTagsQuery(model);
            var result = await _mediator.Send(query);
            return result.Match(Ok, Problem);
        }
        [HttpGet("Audio/entity")]
        public async Task<IActionResult> GetEntityTags([FromQuery] string type)
        {
            var query=new GetEntityAudioQuery(type);
            var result=await _mediator.Send(query);
            return result.Match(Ok, Problem);
        }
    }
}
```
## File: src\Generita.Api\Controllers\AuthController.cs
```csharp
﻿using System.ComponentModel.Design;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using ErrorOr;

using Generita.Application.Authentication.Login;
using Generita.Application.Authentication.Me;
using Generita.Application.Authentication.Refresh;
using Generita.Application.Authentication.Register;
using Generita.Application.Dtos;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generita.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ApiController
    {
        private IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterDto registerDto)
        {
            var command=new RegisterCommand(registerDto);
            var result=await _mediator.Send(command);
            return result.Match(Ok, Problem);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var command=new LoginCommand(loginDto);
            var result=await _mediator.Send(command);
            return result.Match(Ok, Problem);
        }
        [HttpPost]
        public async Task<IActionResult> Refresh(RefreshRequest refreshRequest)
        {
            var command = new RefreshCommand(refreshRequest);
            var result=await _mediator.Send(command);
            return (result.Match(Ok, Problem));
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var command =new MeCommand(Guid.Parse(userId!));
            var result=await _mediator.Send(command);
            return result.Match(Ok,Problem);
        }

    }
}
```
## File: src\Generita.Api\Controllers\BooksController.cs
```csharp
﻿using Generita.Application.Books.Queries.GetBookById;
using Generita.Application.Books.Queries.GetBookContent;
using Generita.Application.Books.Queries.SearchBook;
using Generita.Application.Common.Dtos;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generita.Api.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController : ApiController
    {
        private IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search")]
        [Authorize]
        public async Task<IActionResult> Search([FromQuery(Name = "q")] string Name,SearchBookDto searchBook)
        {

            SearchBookRequest searchBookRequest = new()
            {
                Name = Name,
                Order = searchBook.Order,
                SearchMode = searchBook.SearchMode,
                PublishedDate = searchBook.PublishedDate,
            };
            var query = new SearchBookQuery(searchBookRequest);
            var result = await _mediator.Send(query);
            return result.Match(Ok,Problem);
        }
        [HttpGet("{id}")]
        [Authorize]

        public async Task<IActionResult> GetBookById(Guid id) 
        {
            var query = new GetBookByIdQuery(id);
            var result=await _mediator.Send(query);
            return result.Match(Ok,Problem);
        }
        [HttpGet("{bookId}/content")]
        public async Task<IActionResult> GetBookContent(Guid bookId)
        {
            var query = new GetBookByContentQuery(bookId);
            var result=await _mediator.Send(query);
            return result.Match(Ok,Problem);
        }


    }
}
```
## File: src\Generita.Api\Controllers\HomeController.cs
```csharp
﻿using Generita.Application.Home.Query;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generita.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ApiController
    {
        private IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Home()
        {
            var query = new HomeQuery();
            var res=await _mediator.Send(query);
            return res.Match(Ok, Problem);
        }

    }
}
```
## File: src\Generita.Api\Controllers\UsersController.cs
```csharp
﻿using System.Security.Claims;

using Generita.Application.Common.Dtos;
using Generita.Application.Users.Commands.AddBookToLibrary;
using Generita.Application.Users.Commands.RemvoeBookFromLibrary;
using Generita.Domain.Models;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generita.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ApiController
    {
        private IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Library")]
        [Authorize]
        public async Task<IActionResult> AddToLibrary([FromBody]AddTolibraryControllerDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AddUserLibraryRequest request = new()
            {
                BookId = dto.bookId,
                UserId=Guid.Parse(userId!),
            };
            var query=new AddUserLibraryQuery(request);
            var result=await _mediator.Send(query); 
            return result.Match(Ok,Problem);

        }
        [HttpDelete("Library/{bookId}")]
        public async Task<IActionResult> Library([FromRoute] Guid bookId)
        {
             var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AddUserLibraryRequest request = new()
            {
                BookId = bookId,
                UserId = Guid.Parse(userId!),
            };
            var query=new RemoveBookFromLibraryQuery(request);
            var result=await _mediator.Send(query);
            return result.Match(Ok,Problem);

        }



    }
}
```
## File: src\Generita.Api\Properties\launchSettings.json
```json
{
  "profiles": {
    "http": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      },
      "dotnetRunMessages": true,
      "applicationUrl": "http://localhost:5062"
    },
    "https": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      },
      "dotnetRunMessages": true,
      "applicationUrl": "https://localhost:7161;http://localhost:5062"
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "Container (Dockerfile)": {
      "commandName": "Docker",
      "launchBrowser": true,
      "launchUrl": "{Scheme}://{ServiceHost}:{ServicePort}/swagger",
      "environmentVariables": {
        "ASPNETCORE_HTTPS_PORTS": "8081",
        "ASPNETCORE_HTTP_PORTS": "8080"
      },
      "publishAllPorts": true,
      "useSSL": true
    }
  },
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:16945",
      "sslPort": 44386
    }
  }
}
```
