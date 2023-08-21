﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230820215915_GroupInstructionAndTimersTogether")]
    partial class GroupInstructionAndTimersTogether
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0-preview.6.23329.4");

            modelBuilder.Entity("Domain.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Recipe.Recipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CookTimeSeconds")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PrepTimeSeconds")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Servings")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SourceUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Domain.Entities.Recipe.Recipe", b =>
                {
                    b.OwnsMany("Domain.Entities.Recipe.RecipeDescriptionGroup", "DescriptionGroups", b1 =>
                        {
                            b1.Property<long>("RecipeId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Body")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Title")
                                .HasColumnType("TEXT");

                            b1.HasKey("RecipeId", "Id");

                            b1.ToTable("Recipes");

                            b1.ToJson("DescriptionGroups");

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");
                        });

                    b.OwnsMany("Domain.Entities.Recipe.RecipeIngredientGroup", "IngredientGroups", b1 =>
                        {
                            b1.Property<long>("RecipeId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .HasColumnType("TEXT");

                            b1.HasKey("RecipeId", "Id");

                            b1.ToTable("Recipes");

                            b1.ToJson("IngredientGroups");

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");

                            b1.OwnsMany("Domain.Entities.Recipe.RecipeIngredient", "Ingredients", b2 =>
                                {
                                    b2.Property<long>("RecipeIngredientGroupRecipeId")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("RecipeIngredientGroupId")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAddOrUpdate()
                                        .HasColumnType("INTEGER");

                                    b2.Property<string>("Name")
                                        .HasColumnType("TEXT");

                                    b2.Property<int?>("Quantity")
                                        .HasColumnType("INTEGER");

                                    b2.Property<string>("QuantityType")
                                        .IsRequired()
                                        .HasColumnType("TEXT");

                                    b2.HasKey("RecipeIngredientGroupRecipeId", "RecipeIngredientGroupId", "Id");

                                    b2.ToTable("Recipes");

                                    b2.WithOwner()
                                        .HasForeignKey("RecipeIngredientGroupRecipeId", "RecipeIngredientGroupId");
                                });

                            b1.Navigation("Ingredients");
                        });

                    b.OwnsMany("Domain.Entities.Recipe.RecipeInstructionGroup", "InstructionGroups", b1 =>
                        {
                            b1.Property<long>("RecipeId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .HasColumnType("TEXT");

                            b1.HasKey("RecipeId", "Id");

                            b1.ToTable("Recipes");

                            b1.ToJson("InstructionGroups");

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");

                            b1.OwnsMany("Domain.Entities.Recipe.RecipeInstruction", "Instructions", b2 =>
                                {
                                    b2.Property<long>("RecipeInstructionGroupRecipeId")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("RecipeInstructionGroupId")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAddOrUpdate()
                                        .HasColumnType("INTEGER");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasColumnType("TEXT");

                                    b2.HasKey("RecipeInstructionGroupRecipeId", "RecipeInstructionGroupId", "Id");

                                    b2.ToTable("Recipes");

                                    b2.WithOwner()
                                        .HasForeignKey("RecipeInstructionGroupRecipeId", "RecipeInstructionGroupId");

                                    b2.OwnsMany("Domain.Entities.Recipe.RecipeTimer", "Timers", b3 =>
                                        {
                                            b3.Property<long>("RecipeInstructionGroupRecipeId")
                                                .HasColumnType("INTEGER");

                                            b3.Property<int>("RecipeInstructionGroupId")
                                                .HasColumnType("INTEGER");

                                            b3.Property<int>("RecipeInstructionId")
                                                .HasColumnType("INTEGER");

                                            b3.Property<int>("Id")
                                                .ValueGeneratedOnAddOrUpdate()
                                                .HasColumnType("INTEGER");

                                            b3.Property<string>("Name")
                                                .HasColumnType("TEXT");

                                            b3.Property<int>("TotalTimeInSeconds")
                                                .HasColumnType("INTEGER");

                                            b3.HasKey("RecipeInstructionGroupRecipeId", "RecipeInstructionGroupId", "RecipeInstructionId", "Id");

                                            b3.ToTable("Recipes");

                                            b3.WithOwner()
                                                .HasForeignKey("RecipeInstructionGroupRecipeId", "RecipeInstructionGroupId", "RecipeInstructionId");
                                        });

                                    b2.Navigation("Timers");
                                });

                            b1.Navigation("Instructions");
                        });

                    b.OwnsMany("Domain.Entities.Recipe.RecipeTipsAndTricksGroup", "TipsAndTricksGroups", b1 =>
                        {
                            b1.Property<long>("RecipeId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Body")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Title")
                                .HasColumnType("TEXT");

                            b1.HasKey("RecipeId", "Id");

                            b1.ToTable("Recipes");

                            b1.ToJson("TipsAndTricksGroups");

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");
                        });

                    b.Navigation("DescriptionGroups");

                    b.Navigation("IngredientGroups");

                    b.Navigation("InstructionGroups");

                    b.Navigation("TipsAndTricksGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
